using AutoMapper;
using ClosedXML.Excel;
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

    [HttpGet]
    [Route("{evaluationId:guid}/exports/results")]
    public async Task<IActionResult> GenerateAndDownloadExcel()
    {
        try
        {
            var studentResults = await _unitOfWork.StudentResults.GetAllAsync();
            var results = _mapper.Map<IEnumerable<GetStudentResultResponse>>(studentResults);

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Results");
            var headerStyle = workbook.Style;
            headerStyle.Font.Bold = true;
            headerStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            worksheet.Cell(1, 1).Value = "RegNo.";
            worksheet.Cell(1, 2).Value = "Name";
            worksheet.Cell(1, 3).Value = "Marks";

            worksheet.Row(1).Style = headerStyle;

            var row = 2;
            foreach (var result in results)
            {
                worksheet.Cell(row, 1).Value = result.RegistrationNum;
                worksheet.Cell(row, 2).Value = result.FullName;
                worksheet.Cell(row, 3).Value = result.StudentScore;
                row++;
            }

            var range = worksheet.Range("A1:C" + (row - 1)); // Define the range for the table
            var table = range.CreateTable();

            table.ShowAutoFilter = true;

            var headerRow = table.HeadersRow();
            headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            headerRow.Style.Font.Bold = true;

            var dataRows = table.DataRange.Rows();
            dataRows.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

            using var memoryStream = new MemoryStream();
            workbook.SaveAs(memoryStream);
            memoryStream.Position = 0;


            return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Results.xlsx");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while generating the Excel file.");
        }
    }
}