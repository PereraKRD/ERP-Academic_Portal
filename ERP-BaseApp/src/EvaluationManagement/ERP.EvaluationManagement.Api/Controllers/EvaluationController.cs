using AutoMapper;
using ERP.EvaluationManagement.Core.DTOs.Requests;
using ERP.EvaluationManagement.Core.DTOs.Responses;
using ERP.EvaluationManagement.Core.Entity;
using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.EvaluationManagement.Api.Controllers;

public class EvaluationController : BaseController
{
    public EvaluationController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEvaluations()
    {
        var evaluations = await _unitOfWork.Evaluations.GetAllAsync();
        var results = _mapper.Map<IEnumerable<GetEvaluationDetailsResponse>>(evaluations);
        return Ok(results);
    }
    
    [HttpGet]
    [Route("{moduleOfferingId:guid}")]
    public async Task<IActionResult> GetEvaluationById(Guid moduleOfferingId)
    {
        var evaluations = await _unitOfWork.Evaluations.GetByIdAsync(moduleOfferingId);
        var result = _mapper.Map<IEnumerable<GetEvaluationDetailsResponse>>(evaluations);
        return Ok(result);
    }
    
    [HttpPost]
    [Route("{moduleOfferingId:guid}")]
    public async Task<IActionResult> AddEvaluation(Guid moduleOfferingId, [FromBody] CreateEvaluationRequest evaluation)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        var evaluationEntity = _mapper.Map<Evaluation>(evaluation);
        evaluationEntity.ModuleOfferingID = moduleOfferingId;
        await _unitOfWork.Evaluations.AddAsync(evaluationEntity);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("{evaluationId:guid}")]
    public async Task<IActionResult> DeleteEvaluation(Guid evaluationId)
    {
        var evaluation = await _unitOfWork.Evaluations.GetAsync(evaluationId);

        if (evaluation == null)
        {
            return NotFound();
        }

        await _unitOfWork.Evaluations.DeleteAsync(evaluationId);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }
}