using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using FluentAssertions;
using ERP.EvaluationManagement.Api.Controllers;
using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using AutoMapper;
using ERP.EvaluationManagement.Core.Entity;
using ERP.EvaluationManagement.Core.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using ERP.EvaluationManagement.Core.DTOs.Requests;

namespace ERP.EvaluationManagement.Api.Tests.Controllers
{
    public class ModuleControllerTest
    {
        private readonly IFixture _fixture;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ModuleController _controller;

        public ModuleControllerTest()
        {
            _fixture = new Fixture();
            _unitOfWorkMock = _fixture.Freeze<Mock<IUnitOfWork>>();
            _mapperMock = _fixture.Freeze<Mock<IMapper>>();

            _controller = new ModuleController(_unitOfWorkMock.Object, _mapperMock.Object);
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task GetAllModules_ShouldReturnOkResponse_WhenDataFound()
        {
            //Arrange
            var moduleMock = _fixture.Create<IEnumerable<Module>>();
            object value = _unitOfWorkMock.Setup(x => x.Modules.GetAllAsync()).ReturnsAsync(moduleMock);

            var moduleListMock = _fixture.Create<IEnumerable<GetModuleResponse>>();
            object listValue = _mapperMock.Setup(x => x.Map<IEnumerable<GetModuleResponse>>(moduleMock)).Returns(moduleListMock);

            //Act
            var result = await _controller.GetAllModule().ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            //result.Should().BeAssignableTo<ActionResult<IEnumerable<Batch>>>();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(moduleListMock.GetType());
            _unitOfWorkMock.Verify(x => x.Modules.GetAllAsync(), Times.Once);
            _mapperMock.Verify(x => x.Map<IEnumerable<GetModuleResponse>>(moduleMock), Times.Once);

        }

        [Fact]
        public async Task GetAllModules_ShouldReturnNotFound_WhenNoDataFound()
        {
            //Arrange
            List<Module> response = null;
            object value = _unitOfWorkMock.Setup(x => x.Modules.GetAllAsync()).ReturnsAsync(response);

            //Act
            var result = await _controller.GetAllModule().ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NotFoundResult>();
            _unitOfWorkMock.Verify(x => x.Modules.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task AddModule_ShouldReturnOkResponse_WhenValidRequest()
        {
            //Arrange
            var request = _fixture.Create<CreateModuleRequest>();
            var response = _fixture.Create<Module>();

            _mapperMock.Setup(x => x.Map<Module>(request)).Returns(response);
            _unitOfWorkMock.Setup(x => x.Modules.AddAsync(response)).ReturnsAsync(true);
            _unitOfWorkMock.Setup(x => x.CompleteAsync()).ReturnsAsync(true);

            //Act
            var result = await _controller.AddModule(request).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkResult>();
            _mapperMock.Verify(x => x.Map<Module>(request), Times.Once);
            _unitOfWorkMock.Verify(x => x.Modules.AddAsync(response), Times.Once);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Once);
        }

        [Fact]
        public async Task AddModule_ShouldReturnbadResponse_WhenInvalidRequest()
        {
            //Arrange
            var request = _fixture.Create<CreateModuleRequest>();
            _controller.ModelState.AddModelError("BatchName", "The BatchName field is required.");
            var response = _fixture.Create<Module>();

            _mapperMock.Setup(x => x.Map<Module>(request)).Returns(response);
            _unitOfWorkMock.Setup(x => x.Modules.AddAsync(response)).ReturnsAsync(true);
            _unitOfWorkMock.Setup(x => x.CompleteAsync()).ReturnsAsync(true);

            //Act
            var result = await _controller.AddModule(request).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestResult>();
            _mapperMock.Verify(x => x.Map<Module>(request), Times.Never);
            _unitOfWorkMock.Verify(x => x.Modules.AddAsync(response), Times.Never);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Never);
        }

        [Fact]
        public async Task DeleteBatch_ShouldReturnNoContent_WhenBatchDeleted()
        {
            //Arrange
            var moduleId = _fixture.Create<Guid>();
            var response = _fixture.Create<Module>();

            _unitOfWorkMock.Setup(x => x.Modules.GetAsync(moduleId)).ReturnsAsync(response);
            _unitOfWorkMock.Setup(x => x.Modules.DeleteAsync(moduleId)).ReturnsAsync(true);
            _unitOfWorkMock.Setup(x => x.CompleteAsync()).ReturnsAsync(true);

            //Act
            var result = await _controller.DeleteModule(moduleId).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NoContentResult>();
            _unitOfWorkMock.Verify(x => x.Modules.GetAsync(moduleId), Times.Once);
            _unitOfWorkMock.Verify(x => x.Modules.DeleteAsync(moduleId), Times.Once);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteModule_ShouldReturnNotFound_WhenNoDataFound()
        {
            //Arrange
            var moduleId = _fixture.Create<Guid>();
            Module moduleResponse = null;

            _unitOfWorkMock.Setup(x => x.Modules.GetAsync(moduleId)).ReturnsAsync(moduleResponse);

            //Act
            var result = await _controller.DeleteModule(moduleId).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NotFoundResult>();
            _unitOfWorkMock.Verify(x => x.Modules.GetAsync(moduleId), Times.Once);
            _unitOfWorkMock.Verify(x => x.Modules.DeleteAsync(moduleId), Times.Never);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Never);
        }
    }
}
