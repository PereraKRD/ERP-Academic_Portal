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
    public class SecondExaminerModuleOfferingControllerTest
    {
        private readonly IFixture _fixture;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly SecondExaminerModuleOfferingController _controller;

        public SecondExaminerModuleOfferingControllerTest()
        {
            _fixture = new Fixture();
            _unitOfWorkMock = _fixture.Freeze<Mock<IUnitOfWork>>();
            _mapperMock = _fixture.Freeze<Mock<IMapper>>();

            _controller = new SecondExaminerModuleOfferingController(_unitOfWorkMock.Object, _mapperMock.Object);
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task GetAllSecondExaminerModuleOffering_ShouldReturnOkResponse_WhenDataFound()
        {
            //Arrange
            var secondExaminerModuleMock = _fixture.Create<IEnumerable<ModuleOfferingSecondExaminer>>();
            object value = _unitOfWorkMock.Setup(x => x.SecondExaminerModuleOfferings.GetAllAsync()).ReturnsAsync(secondExaminerModuleMock);

            var secondExaminerModuleListMock = _fixture.Create<IEnumerable<GetAllSecondExaminerModuleOfferingResponse>>();
            object listValue = _mapperMock.Setup(x => x.Map<IEnumerable<GetAllSecondExaminerModuleOfferingResponse>>(secondExaminerModuleMock)).Returns(secondExaminerModuleListMock);

            //Act
            var result = await _controller.GetAllSecondExaminerModuleOffering().ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().NotBeNull().And.BeAssignableTo<IEnumerable<GetAllSecondExaminerModuleOfferingResponse>>();
            _unitOfWorkMock.Verify(x => x.SecondExaminerModuleOfferings.GetAllAsync(), Times.Once);
            _mapperMock.Verify(x => x.Map<IEnumerable<GetAllSecondExaminerModuleOfferingResponse>>(secondExaminerModuleMock), Times.Once);

        }

        [Fact]
        public async Task GetAllSecondExaminerModuleOffering_ShouldReturnNotFound_WhenNoDataFound()
        {
            //Arrange
            List<ModuleOfferingSecondExaminer> response = null;
            object value = _unitOfWorkMock.Setup(x => x.SecondExaminerModuleOfferings.GetAllAsync()).ReturnsAsync(response);

            //Act
            var result = await _controller.GetAllSecondExaminerModuleOffering().ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NotFoundResult>();
            _unitOfWorkMock.Verify(x => x.SecondExaminerModuleOfferings.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task AddSecondExaminerModuleOffering_ShouldReturnOkResponse_WhenValidRequest()
        {
            //Arrange
            var request = _fixture.Create<CreateSecondExaminerModulesRequest>();
            var response = _fixture.Create<ModuleOfferingSecondExaminer>();

            _mapperMock.Setup(x => x.Map<ModuleOfferingSecondExaminer>(request)).Returns(response);
            _unitOfWorkMock.Setup(x => x.SecondExaminerModuleOfferings.AddAsync(response)).ReturnsAsync(true);
            _unitOfWorkMock.Setup(x => x.CompleteAsync()).ReturnsAsync(true);

            //Act
            var result = await _controller.AddSecondExaminerModuleOffering(request).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkResult>();
            _mapperMock.Verify(x => x.Map<ModuleOfferingSecondExaminer>(request), Times.Once);
            _unitOfWorkMock.Verify(x => x.SecondExaminerModuleOfferings.AddAsync(response), Times.Once);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Once);
        }

        [Fact]
        public async Task AddSecondExaminerModuleOffering_ShouldReturnbadResponse_WhenInvalidRequest()
        {
            //Arrange
            var request = _fixture.Create<CreateSecondExaminerModulesRequest>();
            _controller.ModelState.AddModelError("ModuleOfferingId", "The ModuleOffering Id field is required.");
            _controller.ModelState.AddModelError("TeacherId", "The Teacher Id field is required.");
            var response = _fixture.Create<ModuleOfferingSecondExaminer>();

            _mapperMock.Setup(x => x.Map<ModuleOfferingSecondExaminer>(request)).Returns(response);
            _unitOfWorkMock.Setup(x => x.SecondExaminerModuleOfferings.AddAsync(response)).ReturnsAsync(true);
            _unitOfWorkMock.Setup(x => x.CompleteAsync()).ReturnsAsync(true);

            //Act
            var result = await _controller.AddSecondExaminerModuleOffering(request).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestResult>();
            _mapperMock.Verify(x => x.Map<ModuleOfferingSecondExaminer>(request), Times.Never);
            _unitOfWorkMock.Verify(x => x.SecondExaminerModuleOfferings.AddAsync(response), Times.Never);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Never);
        }

        [Fact]
        public async Task GetSecondExaminerModules_ShouldReturnOkResponse_WhenDataFound()
        {
            //Arrange
            var secondExaminerModuleMock = _fixture.Create<IEnumerable<ModuleOfferingSecondExaminer>>();
            var secondExaminerId = _fixture.Create<Guid>();
            object listvalue = _unitOfWorkMock.Setup(x => x.SecondExaminerModuleOfferings.GetSecondExaminerModulesAsync(secondExaminerId)).ReturnsAsync(secondExaminerModuleMock);

            var secondExaminerModuleListMock = _fixture.Create<IEnumerable<GetParticularSecondExaminerModuleOfferingResponse>>();
            object value = _mapperMock.Setup(x => x.Map<IEnumerable<GetParticularSecondExaminerModuleOfferingResponse>>(secondExaminerModuleMock)).Returns(secondExaminerModuleListMock);

            //Act
            var result = await _controller.GetSecondExaminerModules(secondExaminerId).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().NotBeNull().And.BeAssignableTo<IEnumerable<GetParticularSecondExaminerModuleOfferingResponse>>();
            _unitOfWorkMock.Verify(x => x.SecondExaminerModuleOfferings.GetSecondExaminerModulesAsync(secondExaminerId), Times.Once);
            _mapperMock.Verify(x => x.Map<IEnumerable<GetParticularSecondExaminerModuleOfferingResponse>>(secondExaminerModuleMock), Times.Once);

        }
        [Fact]
        public async Task GetSecondExaminerModules_ShouldReturnNotFound_WhenNoDataFound()
        {
            //Arrange
            IEnumerable<ModuleOfferingSecondExaminer> response = null;
            var secondExaminerId = _fixture.Create<Guid>();
            object value = _unitOfWorkMock.Setup(x => x.SecondExaminerModuleOfferings.GetSecondExaminerModulesAsync(secondExaminerId)).ReturnsAsync(response);

            //Act
            var result = await _controller.GetSecondExaminerModules(secondExaminerId).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NotFoundResult>();
            _unitOfWorkMock.Verify(x => x.SecondExaminerModuleOfferings.GetSecondExaminerModulesAsync(secondExaminerId), Times.Once);

        }
    }
}
