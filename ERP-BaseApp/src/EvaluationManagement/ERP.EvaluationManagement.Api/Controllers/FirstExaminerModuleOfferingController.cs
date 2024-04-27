using AutoMapper;
using ERP.EvaluationManagement.Core.DTOs.Requests;
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
}