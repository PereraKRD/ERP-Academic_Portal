using AutoMapper;
using ERP.EvaluationManagement.Core.DTOs.Requests;
using ERP.EvaluationManagement.Core.DTOs.Responses;
using ERP.EvaluationManagement.Core.Entity;
using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.EvaluationManagement.Api.Controllers;

public class FirstExaminerModuleOfferingController : BaseController
{
    public FirstExaminerModuleOfferingController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpPost("")]
    public async Task<IActionResult> AddFirstExaminerModuleOffering(
        [FromBody] CreateFirstExaminerModulesRequest firstExaminerModuleOffering)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var firstExaminerModuleOfferingEntity = _mapper.Map<ModuleOfferingFirstExaminer>(firstExaminerModuleOffering);

        await _unitOfWork.FirstExaminerModuleOfferings.AddAsync(firstExaminerModuleOfferingEntity);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }
    
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllFirstExaminerModuleOffering()
    {
        var firstExaminerModuleOfferings = await _unitOfWork.FirstExaminerModuleOfferings.GetAllAsync();
        var results = _mapper.Map<IEnumerable<GetAllFirstExaminerModuleOfferingResponse>>(firstExaminerModuleOfferings);
        return Ok(results);
    }
    
    [HttpGet]
    [Route("{firstExaminerId:guid}/modules")]
    public async Task<IActionResult> GetFirstExaminerModules(Guid firstExaminerId)
    {
        var modules = await _unitOfWork.FirstExaminerModuleOfferings.GetFirstExaminerModulesAsync(firstExaminerId);
        var results = _mapper.Map<IEnumerable<GetParticularFirstExaminerModuleOfferingResponse>>(modules);
        return Ok(results);
    }
}