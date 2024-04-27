using AutoMapper;
using ERP.EvaluationManagement.Core.DTOs.Requests;
using ERP.EvaluationManagement.Core.DTOs.Responses;
using ERP.EvaluationManagement.Core.Entity;
using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.EvaluationManagement.Api.Controllers;

public class SecondExaminerModuleOfferingController : BaseController
{
    public SecondExaminerModuleOfferingController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    
    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddSecondExaminerModuleOffering([FromBody] CreateSecondExaminerModulesRequest secondExaminerModuleOffering)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var secondExaminerModuleOfferingEntity = _mapper.Map<ModuleOfferingSecondExaminer>(secondExaminerModuleOffering);
        await _unitOfWork.SecondExaminerModuleOfferings.AddAsync(secondExaminerModuleOfferingEntity);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }
    
    
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllSecondExaminerModuleOffering()
    {
        var secondExaminerModuleOfferings = await _unitOfWork.SecondExaminerModuleOfferings.GetAllAsync();
        var results = _mapper.Map<IEnumerable<GetSecondExaminerModuleOfferingResponse>>(secondExaminerModuleOfferings);
        return Ok(results);
    }
}