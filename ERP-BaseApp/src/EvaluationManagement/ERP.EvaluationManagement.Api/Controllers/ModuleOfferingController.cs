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
    [Route("{teacherId:guid}")]
    public async Task<IActionResult> GetTeacherModuleOffering(Guid teacherId)
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
}