using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using FluentAssertions;
using ERP.EvaluationManagement.Api.Controllers;
using AutoMapper;
using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using ERP.EvaluationManagement.Core.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using ERP.EvaluationManagement.Core.Entity;
using ERP.EvaluationManagement.Core.DTOs.Requests;


namespace ERP.EvaluationManagement.Api.Tests.Controllers
{
    public class FirstExaminerModuleOfferingControllerTest
    {
        private readonly IFixture _fixture;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly FirstExaminerModuleOfferingController _controller;

        public FirstExaminerModuleOfferingControllerTest()
        {
            _fixture = new Fixture();
            _unitOfWorkMock = _fixture.Freeze<Mock<IUnitOfWork>>();
            _mapperMock = _fixture.Freeze<Mock<IMapper>>();

            _controller = new FirstExaminerModuleOfferingController(_unitOfWorkMock.Object, _mapperMock.Object);
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task GetAllFirstExaminerModuleOffering_ShouldReturnOkResponse_WhenDataFound()
        {
            //Arrange
            var firstExaminerModuleMock = _fixture.Create<IEnumerable<ModuleOfferingFirstExaminer>>();
            object value = _unitOfWorkMock.Setup(x => x.FirstExaminerModuleOfferings.GetAllAsync()).ReturnsAsync(firstExaminerModuleMock);

            var firstExaminerModuleListMock = _fixture.Create<IEnumerable<GetAllFirstExaminerModuleOfferingResponse>>();
            object listValue = _mapperMock.Setup(x => x.Map<IEnumerable<GetAllFirstExaminerModuleOfferingResponse>>(firstExaminerModuleMock)).Returns(firstExaminerModuleListMock);

            //Act
            var result = await _controller.GetAllFirstExaminerModuleOffering().ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().NotBeNull().And.BeAssignableTo<IEnumerable<GetAllFirstExaminerModuleOfferingResponse>>();
            _unitOfWorkMock.Verify(x => x.FirstExaminerModuleOfferings.GetAllAsync(), Times.Once);
            _mapperMock.Verify(x => x.Map<IEnumerable<GetAllFirstExaminerModuleOfferingResponse>>(firstExaminerModuleMock), Times.Once);

        }

        [Fact]
        public async Task GetAllFirstExaminerModuleOffering_ShouldReturnNotFound_WhenNoDataFound()
        {
            //Arrange
            List<ModuleOfferingFirstExaminer> response = null;
            object value = _unitOfWorkMock.Setup(x => x.FirstExaminerModuleOfferings.GetAllAsync()).ReturnsAsync(response);

            //Act
            var result = await _controller.GetAllFirstExaminerModuleOffering().ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NotFoundResult>();
            _unitOfWorkMock.Verify(x => x.FirstExaminerModuleOfferings.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task AddFirstExaminerModuleOffering_ShouldReturnOkResponse_WhenValidRequest()
        {
            //Arrange
            var request = _fixture.Create<CreateFirstExaminerModulesRequest>();
            var response = _fixture.Create<ModuleOfferingFirstExaminer>();

            _mapperMock.Setup(x => x.Map<ModuleOfferingFirstExaminer>(request)).Returns(response);
            _unitOfWorkMock.Setup(x => x.FirstExaminerModuleOfferings.AddAsync(response)).ReturnsAsync(true);
            _unitOfWorkMock.Setup(x => x.CompleteAsync()).ReturnsAsync(true);

            //Act
            var result = await _controller.AddFirstExaminerModuleOffering(request).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkResult>();
            _mapperMock.Verify(x => x.Map<ModuleOfferingFirstExaminer>(request), Times.Once);
            _unitOfWorkMock.Verify(x => x.FirstExaminerModuleOfferings.AddAsync(response), Times.Once);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Once);
        }

        [Fact]
        public async Task AddFirstExaminerModuleOffering_ShouldReturnbadResponse_WhenInvalidRequest()
        {
            //Arrange
            var request = _fixture.Create<CreateFirstExaminerModulesRequest>();
            _controller.ModelState.AddModelError("ModuleOfferingId", "The ModuleOffering Id field is required.");
            _controller.ModelState.AddModelError("TeacherId", "The Teacher Id field is required.");
            var response = _fixture.Create<ModuleOfferingFirstExaminer>();

            _mapperMock.Setup(x => x.Map<ModuleOfferingFirstExaminer>(request)).Returns(response);
            _unitOfWorkMock.Setup(x => x.FirstExaminerModuleOfferings.AddAsync(response)).ReturnsAsync(true);
            _unitOfWorkMock.Setup(x => x.CompleteAsync()).ReturnsAsync(true);

            //Act
            var result = await _controller.AddFirstExaminerModuleOffering(request).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestResult>();
            _mapperMock.Verify(x => x.Map<ModuleOfferingFirstExaminer>(request), Times.Never);
            _unitOfWorkMock.Verify(x => x.FirstExaminerModuleOfferings.AddAsync(response), Times.Never);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Never);
        }

        [Fact]
        public async Task GetFirstExaminerModules_ShouldReturnOkResponse_WhenDataFound()
        {
            //Arrange
            var firstExaminerModuleMock = _fixture.Create<IEnumerable<ModuleOfferingFirstExaminer>>();
            var firstExaminerId = _fixture.Create<Guid>();
            object listvalue = _unitOfWorkMock.Setup(x => x.FirstExaminerModuleOfferings.GetFirstExaminerModulesAsync(firstExaminerId)).ReturnsAsync(firstExaminerModuleMock);

            var firstExaminerModuleListMock = _fixture.Create<IEnumerable<GetParticularFirstExaminerModuleOfferingResponse>>();
            object value = _mapperMock.Setup(x => x.Map<IEnumerable<GetParticularFirstExaminerModuleOfferingResponse>>(firstExaminerModuleMock)).Returns(firstExaminerModuleListMock);

            //Act
            var result = await _controller.GetFirstExaminerModules(firstExaminerId).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().NotBeNull().And.BeAssignableTo<IEnumerable<GetParticularFirstExaminerModuleOfferingResponse>>();
            _unitOfWorkMock.Verify(x => x.FirstExaminerModuleOfferings.GetFirstExaminerModulesAsync(firstExaminerId), Times.Once);
            _mapperMock.Verify(x => x.Map<IEnumerable<GetParticularFirstExaminerModuleOfferingResponse>>(firstExaminerModuleMock), Times.Once);

        }
        [Fact]
        public async Task GetFirstExaminerModules_ShouldReturnNotFound_WhenNoDataFound()
        {
            //Arrange
            IEnumerable<ModuleOfferingFirstExaminer> response = null;
            var firstExaminerId = _fixture.Create<Guid>();
            object value = _unitOfWorkMock.Setup(x => x.FirstExaminerModuleOfferings.GetFirstExaminerModulesAsync(firstExaminerId)).ReturnsAsync(response);

            //Act
            var result = await _controller.GetFirstExaminerModules(firstExaminerId).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NotFoundResult>();
            _unitOfWorkMock.Verify(x => x.FirstExaminerModuleOfferings.GetFirstExaminerModulesAsync(firstExaminerId), Times.Once);

        }
    }
}
