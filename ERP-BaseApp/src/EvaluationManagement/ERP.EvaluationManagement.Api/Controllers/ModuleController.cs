using AutoMapper;
using ERP.EvaluationManagement.Core.DTOs.Requests;
using ERP.EvaluationManagement.Core.DTOs.Responses;
using ERP.EvaluationManagement.Core.Entity;
using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.EvaluationManagement.Api.Controllers;

public class ModuleController : BaseController
{
    public ModuleController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllModule()
    {
        var modules = await _unitOfWork.Modules.GetAllAsync();
        if (modules == null || !modules.Any())
        {
            return NotFound();
        }
        var results = _mapper.Map<IEnumerable<GetModuleResponse>>(modules);
        return Ok(results);
    }


    [HttpPost("")]
    public async Task<IActionResult> AddModule([FromBody] CreateModuleRequest module)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var moduleEntity = _mapper.Map<Module>(module);
        await _unitOfWork.Modules.AddAsync(moduleEntity);
        await _unitOfWork.CompleteAsync();
        return Ok();

    }

    [HttpDelete]
    [Route("{moduleId:guid}")]
    public async Task<IActionResult> DeleteModule(Guid moduleId)
    {
        var module = await _unitOfWork.Modules.GetAsync(moduleId);

        if (module == null)
        {
            return NotFound();
        }

        await _unitOfWork.Modules.DeleteAsync(moduleId);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }
}