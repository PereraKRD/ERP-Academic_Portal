using AutoMapper;
using ERP.RequestManagement.Api.Controllers;
using ERP.RequestManagement.Core.DTOs.Requests;
using ERP.RequestManagement.Core.DTOs.Responses;
using ERP.RequestManagement.Core.Entity;
using ERP.RequestManagement.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.RequestManagement.Api.Controllers
{
    public class BatchController : BaseController
    {
        public BatchController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBatches()
        {
            var batches = await _unitOfWork.Batches.GetAllAsync();
            var results = _mapper.Map<IEnumerable<GetBatchResponse>>(batches);
            return Ok(results);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBatch([FromBody] CreateBatchRequest batch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var batchEntity = _mapper.Map<Batch>(batch);

            await _unitOfWork.Batches.AddAsync(batchEntity);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("{batchId:guid}")]
        public async Task<IActionResult> DeleteBatch(Guid batchId)
        {
            var student = await _unitOfWork.Batches.GetAsync(batchId);
            if (student == null)
            {
                return NotFound();
            }

            await _unitOfWork.Batches.DeleteAsync(batchId);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

    }
}
