using AutoMapper;
using ERP.EvaluationManagement.Core.DTOs.Requests;
using ERP.EvaluationManagement.Core.DTOs.Responses;
using ERP.EvaluationManagement.Core.Entity;
using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.EvaluationManagement.Api.Controllers;

public class TeacherRegistrationController : BaseController
{
    public TeacherRegistrationController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllTeacher()
    {
        var teachers = await _unitOfWork.Teachers.GetAllAsync();
        var results = _mapper.Map<IEnumerable<GetTeacherResponse>>(teachers);
        return Ok(results);
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
    

    [HttpDelete]
    [Route("{teacherId:guid}")]
    public async Task<IActionResult> DeleteTeacher(Guid teacherId)
    {
        var teacher = await _unitOfWork.Teachers.GetAsync(teacherId);
        
        if (teacher == null)
        {
            return NotFound();
        }
        
        await _unitOfWork.Teachers.DeleteAsync(teacherId);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }
    
    [HttpGet]
    [Route("teachers/{teacherEmail}")]
    public async Task<IActionResult> GetTeacherByEmail(string teacherEmail)
    {
        var teacher = await _unitOfWork.Teachers.GetTeacherByEmailAsync(teacherEmail);
        var result = _mapper.Map<GetTeacherDetailsByEmailResponse>(teacher);
        return Ok(result);
    }
}