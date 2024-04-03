using AutoMapper;
using ERP.EvaluationManagement.Core.DTOs.Requests;
using ERP.EvaluationManagement.Core.DTOs.Responses;
using ERP.EvaluationManagement.Core.Entity;
using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.EvaluationManagement.Api.Controllers;

public class ModuleOfferingController : BaseController
{

    public ModuleOfferingController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    

    [HttpGet]
    [Route("{teacherId:guid}/modules")]
    public async Task<IActionResult> GetTeacherModules(Guid teacherId)
    {
        var modules = await _unitOfWork.ModuleOfferings.GetTeacherModulesAsync(teacherId);
        var results = _mapper.Map<IEnumerable<GetTeacherModulesResponse>>(modules);
        return Ok(results);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllModuleOffering()
    {
        
        var modules = await _unitOfWork.ModuleOfferings.GetAllAsync();
        var results = _mapper.Map<IEnumerable<GetModuleOfferingResponse>>(modules);
        return Ok(results);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddModuleOffering([FromBody] CreateModuleOfferingRequest moduleOffering)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var moduleOfferingEntity = _mapper.Map<ModuleOffering>(moduleOffering);
        await _unitOfWork.ModuleOfferings.AddAsync(moduleOfferingEntity);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }
    
    [HttpGet]
    [Route("{moduleOfferingId:guid}")]
    public async Task<IActionResult> GetModuleOfferingDetailsById(Guid moduleOfferingId)
    {
        var moduleOffering = await _unitOfWork.ModuleOfferings.GetAsync(moduleOfferingId);
        var result = _mapper.Map<GetModuleOfferingDetailsResponse>(moduleOffering);
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
}