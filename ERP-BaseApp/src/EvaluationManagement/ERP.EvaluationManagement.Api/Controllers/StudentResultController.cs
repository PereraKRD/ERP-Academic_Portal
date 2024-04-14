using AutoMapper;
using ERP.EvaluationManagement.Core.DTOs.Requests;
using ERP.EvaluationManagement.Core.DTOs.Responses;
using ERP.EvaluationManagement.Core.Entity;
using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.EvaluationManagement.Api.Controllers;

public class StudentResultController : BaseController
{
    public StudentResultController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllStudentResults()
    {
        var studentResults = await _unitOfWork.StudentResults.GetAllAsync();
        var results = _mapper.Map<IEnumerable<GetStudentResultResponse>>(studentResults);
        return Ok(results);
    }
    
    
    [HttpPost("")]
    public async Task<IActionResult> AddStudentResult([FromBody] CreateStudentResultRequest studentResult)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var studentResultEntity = _mapper.Map<StudentResult>(studentResult);

        await _unitOfWork.StudentResults.AddAsync(studentResultEntity);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }
    

    [HttpDelete]
    [Route("{teacherId:guid}")]
    public async Task<IActionResult> DeleteStudentResult(Guid studentResultId)
    {
        var teacher = await _unitOfWork.Teachers.GetAsync(studentResultId);
        
        if (teacher == null)
        {
            return NotFound();
        }
        
        await _unitOfWork.Teachers.DeleteAsync(studentResultId);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }
    
    [HttpGet]
    [Route("{evaluationId:guid}/results")]
    public async Task<IActionResult> GetEvaluationResults(Guid evaluationId)
    {
        var studentResults = await _unitOfWork.StudentResults.GetEvaluationResultAsync(evaluationId);
        var results = _mapper.Map<IEnumerable<GetEvaluationResultListResponse>>(studentResults);
        return Ok(results);
    }
}