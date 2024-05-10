using AutoMapper;
using ERP.RequestManagement.Core.DTOs.Requests;
using ERP.RequestManagement.Core.DTOs.Responses;
using ERP.RequestManagement.Core.Entity;
using ERP.RequestManagement.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.RequestManagement.Api.Controllers;

public class StudentController : BaseController
{
    public StudentController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudent()
    {
        var students = await _unitOfWork.Students.GetAllAsync();
        var results = _mapper.Map<IEnumerable<GetStudentResponse>>(students);
        return Ok(results);
    }

    [HttpGet]
    [Route("{batchId:guid}/{advisorId:guid}")]
    public async Task<IActionResult> GetAcademicAdvicees(Guid batchId, Guid advisorId)
    {
        var students = await _unitOfWork.Students.GetAcademicAdviceeListAsync(batchId, advisorId);
        var results = _mapper.Map<IEnumerable<GetStudentResponse>>(students);
        return Ok(results);
    }

    [HttpGet]
    [Route("{batchId:guid}")]
    public async Task<IActionResult> GetBatchStudents(Guid batchId)
    {
        var students = await _unitOfWork.Students.GetBatchStudentsAsync(batchId);
        var results = _mapper.Map<IEnumerable<GetStudentResponse>>(students);
        return Ok(results);
    }


    [HttpPost("")]
    public async Task<IActionResult> AddStudent([FromBody] CreateStudentRequest student)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var studentEntity = _mapper.Map<Student>(student);
        
        await _unitOfWork.Students.AddAsync(studentEntity);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("{studentId:guid}")]
    public async Task<IActionResult> DeleteStudent(Guid studentId)
    {
        var student = await _unitOfWork.Students.GetAsync(studentId);
        if (student == null)
        {
            return NotFound();
        }

        await _unitOfWork.Students.DeleteAsync(studentId);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }
}