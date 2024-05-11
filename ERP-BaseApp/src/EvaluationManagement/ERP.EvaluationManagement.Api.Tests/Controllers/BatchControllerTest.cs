using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using FluentAssertions;
using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using ERP.EvaluationManagement.Api.Controllers;
using AutoMapper;
using ERP.EvaluationManagement.Core.Entity;
using ERP.EvaluationManagement.Core.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using ERP.EvaluationManagement.Core.DTOs.Requests;

namespace ERP.EvaluationManagement.Api.Tests.Controllers
{
    
    public class BatchControllerTest
    {
        private readonly IFixture _fixture;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly BatchController _controller;

        public BatchControllerTest()
        {
            _fixture = new Fixture();
            _unitOfWorkMock = _fixture.Freeze<Mock<IUnitOfWork>>();
            _mapperMock = _fixture.Freeze<Mock<IMapper>>();

            _controller = new BatchController(_unitOfWorkMock.Object, _mapperMock.Object);
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task GetAllBatches_ShouldReturnOkResponse_WhenDataFound()
        {
            //Arrange
            var batchMock = _fixture.Create<IEnumerable<Batch>>();
            object value = _unitOfWorkMock.Setup(x => x.Batches.GetAllAsync()).ReturnsAsync(batchMock);

            var batchListMock = _fixture.Create<IEnumerable<GetBatchResponse>>();
            object listValue = _mapperMock.Setup(x => x.Map<IEnumerable<GetBatchResponse>>(batchMock)).Returns(batchListMock);

            //Act
            var result = await _controller.GetAllBatches().ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            //result.Should().BeAssignableTo<ActionResult<IEnumerable<Batch>>>();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(batchListMock.GetType());
            _unitOfWorkMock.Verify(x => x.Batches.GetAllAsync(), Times.Once);
            _mapperMock.Verify(x => x.Map<IEnumerable<GetBatchResponse>>(batchMock), Times.Once);

        }

        [Fact]
        public async Task GetAllBatches_ShouldReturnNotFound_WhenNoDataFound()
        {
            //Arrange
            List<Batch> response = null;
            object value = _unitOfWorkMock.Setup(x => x.Batches.GetAllAsync()).ReturnsAsync(response);

            //Act
            var result = await _controller.GetAllBatches().ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NotFoundResult>();
            _unitOfWorkMock.Verify(x => x.Batches.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task AddBatch_ShouldReturnOkResponse_WhenValidRequest()
        {
            //Arrange
            var request = _fixture.Create<CreateBatchRequest>();
            var response = _fixture.Create<Batch>();

            _mapperMock.Setup(x => x.Map<Batch>(request)).Returns(response);
            _unitOfWorkMock.Setup(x => x.Batches.AddAsync(response)).ReturnsAsync(true);
            _unitOfWorkMock.Setup(x => x.CompleteAsync()).ReturnsAsync(true);

            //Act
            var result = await _controller.AddBatch(request).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkResult>();
            _mapperMock.Verify(x => x.Map<Batch>(request), Times.Once);
            _unitOfWorkMock.Verify(x => x.Batches.AddAsync(response), Times.Once);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Once);
        }

        [Fact]
        public async Task AddBatch_ShouldReturnbadResponse_WhenInvalidRequest()
        {
            //Arrange
            var request = _fixture.Create<CreateBatchRequest>();
            _controller.ModelState.AddModelError("BatchName", "The BatchName field is required.");
            var response = _fixture.Create<Batch>();

            _mapperMock.Setup(x => x.Map<Batch>(request)).Returns(response);
            _unitOfWorkMock.Setup(x => x.Batches.AddAsync(response)).ReturnsAsync(true);
            _unitOfWorkMock.Setup(x => x.CompleteAsync()).ReturnsAsync(true);

            //Act
            var result = await _controller.AddBatch(request).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestResult>();
            _mapperMock.Verify(x => x.Map<Batch>(request), Times.Never);
            _unitOfWorkMock.Verify(x => x.Batches.AddAsync(response), Times.Never);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Never);
        }

        [Fact]
        public async Task DeleteBatch_ShouldReturnNoContent_WhenBatchDeleted()
        {
            //Arrange
            var batchId = _fixture.Create<Guid>();
            var response = _fixture.Create<Batch>();

            _unitOfWorkMock.Setup(x => x.Batches.GetAsync(batchId)).ReturnsAsync(response);
            _unitOfWorkMock.Setup(x => x.Batches.DeleteAsync(batchId)).ReturnsAsync(true);
            _unitOfWorkMock.Setup(x => x.CompleteAsync()).ReturnsAsync(true);

            //Act
            var result = await _controller.DeleteBatch(batchId).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NoContentResult>();
            _unitOfWorkMock.Verify(x => x.Batches.GetAsync(batchId), Times.Once);
            _unitOfWorkMock.Verify(x => x.Batches.DeleteAsync(batchId), Times.Once);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteBatch_ShouldReturnNotFound_WhenNoDataFound()
        {
            //Arrange
            var batchId = _fixture.Create<Guid>();
            Batch batchResponse = null;

            _unitOfWorkMock.Setup(x => x.Batches.GetAsync(batchId)).ReturnsAsync(batchResponse);

            //Act
            var result = await _controller.DeleteBatch(batchId).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NotFoundResult>();
            _unitOfWorkMock.Verify(x => x.Batches.GetAsync(batchId), Times.Once);
            _unitOfWorkMock.Verify(x => x.Batches.DeleteAsync(batchId), Times.Never);
            _unitOfWorkMock.Verify(x => x.CompleteAsync(), Times.Never);
        }
    }
}
