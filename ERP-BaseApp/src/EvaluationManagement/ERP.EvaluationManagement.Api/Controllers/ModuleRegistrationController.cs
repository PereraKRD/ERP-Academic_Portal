using AutoMapper;
using ERP.EvaluationManagement.Core.DTOs.Requests;
using ERP.EvaluationManagement.Core.DTOs.Responses;
using ERP.EvaluationManagement.Core.Entity;
using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.EvaluationManagement.Api.Controllers;

public class ModuleRegistrationController : BaseController
{
    public ModuleRegistrationController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAllModuleRegistration()
    {
        var moduleRegistrations = await _unitOfWork.ModuleRegistrations.GetAllAsync();
        var results = _mapper.Map<IEnumerable<GetModuleRegistrationResponse>>(moduleRegistrations);
        return Ok(results);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddModuleRegistration(
        [FromBody] CreateModuleRegistrationRequest moduleRegistration)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var moduleRegistrationEntity = _mapper.Map<ModuleRegistration>(moduleRegistration);

        await _unitOfWork.ModuleRegistrations.AddAsync(moduleRegistrationEntity);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("{moduleRegId:guid}")]
    public async Task<IActionResult> DeleteModuleRegistration(Guid moduleRegId)
    {
        var moduleRegistration = await _unitOfWork.ModuleRegistrations.GetAsync(moduleRegId);

        if (moduleRegistration == null)
        {
            return NotFound();
        }

        await _unitOfWork.ModuleRegistrations.DeleteAsync(moduleRegId);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }
}