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
using ERP.EvaluationManagement.Core.DTOs.Responses;
using ERP.EvaluationManagement.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using ERP.EvaluationManagement.Core.DTOs.Requests;


namespace ERP.EvaluationManagement.Api.Tests.Controllers
{
    public class EvaluationControllerTest
    {
        private readonly IFixture _fixture;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly EvaluationController _controller;

        public EvaluationControllerTest()
        {
            _fixture = new Fixture();
            _unitOfWorkMock = _fixture.Freeze<Mock<IUnitOfWork>>();
            _mapperMock = _fixture.Freeze<Mock<IMapper>>();

            _controller = new EvaluationController(_unitOfWorkMock.Object, _mapperMock.Object);
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task GetAllBatches_ShouldReturnOkResponse_WhenDataFound()
        {
            //Arrange
            var evaluationMock = _fixture.Create<IEnumerable<Evaluation>>();
            object value = _unitOfWorkMock.Setup(x => x.Evaluations.GetAllAsync()).ReturnsAsync(evaluationMock);

            var evaluationListMock = _fixture.Create<IEnumerable<GetEvaluationDetailsResponse>>();
            object listValue = _mapperMock.Setup(x => x.Map<IEnumerable<GetEvaluationDetailsResponse>>(evaluationMock)).Returns(evaluationListMock);

            //Act
            var result = await _controller.GetAllEvaluations().ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            //result.Should().BeAssignableTo<ActionResult<IEnumerable<Batch>>>();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(evaluationListMock.GetType());
            _unitOfWorkMock.Verify(x => x.Evaluations.GetAllAsync(), Times.Once);
            _mapperMock.Verify(x => x.Map<IEnumerable<GetEvaluationDetailsResponse>>(evaluationMock), Times.Once);

        }

        [Fact]
        public async Task GetAllBatches_ShouldReturnNotFound_WhenNoDataFound()
        {
            //Arrange
            List<Evaluation> response = null;
            object value = _unitOfWorkMock.Setup(x => x.Evaluations.GetAllAsync()).ReturnsAsync(response);

            //Act
            var result = await _controller.GetAllEvaluations().ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NotFoundResult>();
            _unitOfWorkMock.Verify(x => x.Evaluations.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task GetEvaluationById_ShouldReturnOkResponse_WhenDataFound()
        {
            //Arrange
            var evaluationMock = _fixture.Create<IEnumerable<Evaluation>>();
            var moduleOfferingId = _fixture.Create<Guid>();
            object value = _unitOfWorkMock.Setup(x => x.Evaluations.GetByIdAsync(moduleOfferingId)).ReturnsAsync(evaluationMock);

            var evaluationListMock = _fixture.Create<IEnumerable<GetEvaluationDetailsResponse>>();
            object listValue = _mapperMock.Setup(x => x.Map<IEnumerable<GetEvaluationDetailsResponse>>(evaluationMock)).Returns(evaluationListMock);

            //Act
            var result = await _controller.GetEvaluationById(moduleOfferingId).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().NotBeNull().And.BeAssignableTo<GetEvaluationDetailsResponse>();
            _unitOfWorkMock.Verify(x => x.Evaluations.GetByIdAsync(moduleOfferingId), Times.Once);
            _mapperMock.Verify(x => x.Map<GetEvaluationDetailsResponse>(evaluationMock), Times.Once);

        }
        [Fact]
        public async Task GetEvaluationById_ShouldReturnNotFound_WhenNoDataFound()
        {
            //Arrange
            IEnumerable<Evaluation> response = null;
            var moduleOfferingId = _fixture.Create<Guid>();
            object value = _unitOfWorkMock.Setup(x => x.Evaluations.GetByIdAsync(moduleOfferingId)).ReturnsAsync(response);

            //Act
            var result = await _controller.GetEvaluationById(moduleOfferingId).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NotFoundResult>();
            _unitOfWorkMock.Verify(x => x.Evaluations.GetByIdAsync(moduleOfferingId), Times.Once);

        }

        [Fact]
        public async Task GetByEvaluationId_ShouldReturnOkResponse_WhenDataFound()
        {
            //Arrange
            var evaluationMock = _fixture.Create<Evaluation>();
            var evaluationId = _fixture.Create<Guid>();
            object value = _unitOfWorkMock.Setup(x => x.Evaluations.GetByEvaluationIdAsync(evaluationId)).ReturnsAsync(evaluationMock);

            var evaluationResponseMock = _fixture.Create<GetEvaluationDetailsResponse>();
            object responseValue = _mapperMock.Setup(x => x.Map<GetEvaluationDetailsResponse>(evaluationMock)).Returns(evaluationResponseMock);

            //Act
            var result = await _controller.GetEvaluationById(evaluationId).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().NotBeNull().And.BeAssignableTo<GetEvaluationDetailsResponse>();
            _unitOfWorkMock.Verify(x => x.Evaluations.GetByEvaluationIdAsync(evaluationId), Times.Once);
            _mapperMock.Verify(x => x.Map<GetEvaluationDetailsResponse>(evaluationMock), Times.Once);

        }
        [Fact]
        public async Task GetByEvaluationId_ShouldReturnNotFound_WhenNoDataFound()
        {
            //Arrange
            Evaluation response = null;
            var evaluationId = _fixture.Create<Guid>();
            object value = _unitOfWorkMock.Setup(x => x.Evaluations.GetByEvaluationIdAsync(evaluationId)).ReturnsAsync(response);

            //Act
            var result = await _controller.GetByEvaluationId(evaluationId).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NotFoundResult>();
            _unitOfWorkMock.Verify(x => x.Evaluations.GetByEvaluationIdAsync(evaluationId), Times.Once);

        }

        [Fact]
        public async Task AddEvaluation_ShouldReturnOkResponse_WhenValidRequest()
        {
            //Arrange
            var request = _fixture.Create<CreateEvaluationRequest>();
            var moduleOfferingId = _fixture.Create<Guid>();
            var response = _fixture.Create<Evaluation>();

            _mapperMock.Setup(x => x.Map<Evaluation>(request)).Returns(response);
            _unitOfWorkMock.Setup(x => x.Evaluations.AddAsync(response)).ReturnsAsync(true);
            _unitOfWorkMock.Setup(x => x.CompleteAsync()).ReturnsAsync(true);

            //Act
            var result = await _controller.AddEvaluation(moduleOfferingId, request).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkResult>();
            _mapperMock.Verify(x => x.Map<Evaluation>(request), Times.Once);
            _unitOfWorkMock.Verify(x => x.Evaluations.AddAsync(response), Times.Once);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Once);
        }

        [Fact]
        public async Task AddEvaluation_ShouldReturnbadResponse_WhenInvalidRequest()
        {
            //Arrange
            var moduleOfferingId = _fixture.Create<Guid>();
            var request = _fixture.Create<CreateEvaluationRequest>();
            _controller.ModelState.AddModelError("Name", "The Name field is required.");
            _controller.ModelState.AddModelError("Type", "The Type field is required.");
            _controller.ModelState.AddModelError("FinalMarks", "The Final Marks field is required.");
            _controller.ModelState.AddModelError("Marks", "The Marks field is required.");
            var response = _fixture.Create<Evaluation>();

            _mapperMock.Setup(x => x.Map<Evaluation>(request)).Returns(response);
            _unitOfWorkMock.Setup(x => x.Evaluations.AddAsync(response)).ReturnsAsync(true);
            _unitOfWorkMock.Setup(x => x.CompleteAsync()).ReturnsAsync(true);

            //Act
            var result = await _controller.AddEvaluation(moduleOfferingId, request).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestResult>();
            _mapperMock.Verify(x => x.Map<Evaluation>(request), Times.Never);
            _unitOfWorkMock.Verify(x => x.Evaluations.AddAsync(response), Times.Never);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Never);
        }

        [Fact]
        public async Task DeleteEvaluation_ShouldReturnNoContent_WhenBatchDeleted()
        {
            //Arrange
            var evaluationId = _fixture.Create<Guid>();
            var response = _fixture.Create<Evaluation>();

            _unitOfWorkMock.Setup(x => x.Evaluations.GetAsync(evaluationId)).ReturnsAsync(response);
            _unitOfWorkMock.Setup(x => x.Evaluations.DeleteAsync(evaluationId)).ReturnsAsync(true);
            _unitOfWorkMock.Setup(x => x.CompleteAsync()).ReturnsAsync(true);

            //Act
            var result = await _controller.DeleteEvaluation(evaluationId).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NoContentResult>();
            _unitOfWorkMock.Verify(x => x.Evaluations.GetAsync(evaluationId), Times.Once);
            _unitOfWorkMock.Verify(x => x.Evaluations.DeleteAsync(evaluationId), Times.Once);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteEvaluation_ShouldReturnNotFound_WhenNoDataFound()
        {
            //Arrange
            var evaluationId = _fixture.Create<Guid>();
            Evaluation evaluationResponse = null;

            _unitOfWorkMock.Setup(x => x.Evaluations.GetAsync(evaluationId)).ReturnsAsync(evaluationResponse);

            //Act
            var result = await _controller.DeleteEvaluation(evaluationId).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NotFoundResult>();
            _unitOfWorkMock.Verify(x => x.Evaluations.GetAsync(evaluationId), Times.Once);
            _unitOfWorkMock.Verify(x => x.Evaluations.DeleteAsync(evaluationId), Times.Never);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Never);
        }

        [Fact]
        public async Task UpdateEvaluation_ShouldReturnBadResponse_WhenInvalidRequest()
        {
            //Arange
            var request = _fixture.Create<UpdateEvaluationRequest>();
            //var response = _fixture.Create<Evaluation>();
            _controller.ModelState.AddModelError("Name", "The Name field is required.");
            _controller.ModelState.AddModelError("Type", "The Type field is required.");
            _controller.ModelState.AddModelError("FinalMarks", "The Final Marks field is required.");
            _controller.ModelState.AddModelError("Marks", "The Marks field is required.");


            //Act
            var result = await _controller.UpdateEvaluation(request).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _mapperMock.Verify(x => x.Map<Evaluation>(request), Times.Never);
            _unitOfWorkMock.Verify(x => x.Evaluations.UpdateAsync(It.IsAny<Evaluation>()), Times.Never);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Never);

        }


        [Fact]
        public async Task UpdateEvaluation_ShouldReturnNoContentResponse_WhenValidRequest()
        {
            //Arange
            var request = _fixture.Create<UpdateEvaluationRequest>();
            var response = _fixture.Create<Evaluation>();

            _mapperMock.Setup(x => x.Map<Evaluation>(request)).Returns(response);
            _unitOfWorkMock.Setup(x => x.Evaluations.UpdateAsync(response)).ReturnsAsync(true);
            _unitOfWorkMock.Setup(x => x.CompleteAsync()).ReturnsAsync(true);


            //Act
            var result = await _controller.UpdateEvaluation(request).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NoContentResult>();
            _mapperMock.Verify(x => x.Map<Evaluation>(request), Times.Once);
            _unitOfWorkMock.Verify(x => x.Evaluations.UpdateAsync(response), Times.Once);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Once);

        }
        [Fact]
        public async Task UpdateEvaluation_ShouldReturnStatusCode500_WhenErrorOccursSavingToDatabase()
        {
            //Arange
            var request = _fixture.Create<UpdateEvaluationRequest>();
            var graduateId = _fixture.Create<Guid>();
            var response = _fixture.Create<Evaluation>();

            _mapperMock.Setup(x => x.Map<Evaluation>(request)).Returns(response);
            _unitOfWorkMock.Setup(x => x.Evaluations.UpdateAsync(response)).ReturnsAsync(true);
            _unitOfWorkMock.Setup(x => x.CompleteAsync()).ThrowsAsync(new Exception("Database error occurred"));


            //Act
            var result = await _controller.UpdateEvaluation(request).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ObjectResult>();
            var statusCodeResult = (ObjectResult)result;
            statusCodeResult.StatusCode.Should().Be(500);
            statusCodeResult.Value.Should().Be("An error occurred while updating the evaluation.");
            _mapperMock.Verify(x => x.Map<Evaluation>(request), Times.Once);
            _unitOfWorkMock.Verify(x => x.Evaluations.UpdateAsync(response), Times.Once);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Once);

        }
    }
}
