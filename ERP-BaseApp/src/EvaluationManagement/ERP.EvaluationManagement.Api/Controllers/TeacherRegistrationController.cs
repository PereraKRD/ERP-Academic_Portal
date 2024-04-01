using AutoMapper;
using ERP.EvaluationManagement.Core.DTOs.Requests;
using ERP.EvaluationManagement.Core.Entity;
using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.EvaluationManagement.Api.Controllers;

public class TeacherRegistrationController : BaseController
{
    public TeacherRegistrationController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpPost("")]
    public async Task<IActionResult> AddTeacher([FromBody] CreateTeacherRequest teacher)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var teacherEntity = _mapper.Map<Teacher>(teacher);

        await _unitOfWork.Teachers.AddAsync(teacherEntity);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }
}