using AutoMapper;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2016.Presentation.Command;
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

    [HttpPost]
    [Route("{moduleOfferingId:guid}/{evaluationId:guid}")]
    public async Task<IActionResult> AddStudentResult(Guid evaluationId, Guid moduleOfferingId)
    {
        var moduleRegistrations = await _unitOfWork.ModuleRegistrations.GetModuleRegistrationByModuleOfferingAsync(moduleOfferingId);
        foreach (var registration in moduleRegistrations)
        {
            var resultEntity = new StudentResult();
            resultEntity.StudentId = registration.Student.Id;
            resultEntity.EvaluationId = evaluationId;
            resultEntity.StudentScore = 0;
            resultEntity.Status = 1;
            await _unitOfWork.StudentResults.AddAsync(resultEntity);
        }
        await _unitOfWork.CompleteAsync();
        return Ok();
    }

    [HttpPut]
    [Route("{moduleOfferingId}/{evaluationId:guid}/importexcel")]
    public async Task<IActionResult> UpdateResult([FromRoute] Guid moduleOfferingId, [FromRoute] Guid evaluationId, [FromForm] IFormFile formFile)
    {
        try
        {
            var moduleOffering = await _unitOfWork.ModuleOfferings.GetAsync(moduleOfferingId);
            var evaluation = await _unitOfWork.Evaluations.GetByEvaluationIdAsync(evaluationId);
            string evaluationName;

            var list = new List<StudentResult>();
            using (var stream = new MemoryStream())
            {
                await formFile.OpenReadStream().CopyToAsync(stream);
                using (var workbook = new XLWorkbook(stream))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rowCount = worksheet.RangeUsed().RowCount();

                    var moduleCode = worksheet.Cell(3, 3).GetValue<String>();
                    evaluationName = worksheet.Cell(6, 3).GetValue<String>();

                    if (moduleOffering.Module.Code != moduleCode)
                    {
                        return StatusCode(StatusCodes.Status406NotAcceptable, "Uploaded file does not matched to this module.");
                    }
                    if (evaluation.Name != evaluationName)
                    {
                        return StatusCode(StatusCodes.Status406NotAcceptable, "Uploaded file does not matched to this evaluation.");
                    }
                    for (int row = 10; row <= rowCount; row++)
                    {
                        string registrationNumber = worksheet.Cell(row, 1).GetValue<String>();
                        double studentScore = Convert.ToDouble(worksheet.Cell(row, 3).GetValue<String>());

                        if (studentScore <= 0 || studentScore > evaluation.Marks)
                        {
                            return StatusCode(StatusCodes.Status406NotAcceptable, "Marks are not in the valid range.");
                        }

                        var student = await _unitOfWork.Students.GetStudentByRegNum(registrationNumber);
                        var studentResult = await _unitOfWork.StudentResults.GetStudentResultIdAsync(evaluationId, student.Id);

                        if (student != null)
                        {
                            list.Add(new StudentResult
                            {
                                Id = studentResult.Id,
                                StudentId = student.Id,
                                EvaluationId = evaluationId,
                                StudentScore = studentScore,
                            });
                        }
                    }
                }
            }
            foreach (var result in list)
            {
                await _unitOfWork.StudentResults.UpdateAsync(result);

            }
            await _unitOfWork.CompleteAsync();
            return Ok($"{evaluation.Name}, {evaluationName}");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the Excel file.");
        }
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
    [Route("{moduleOfferingId}/{evaluationId:guid}/exports/results")]
    public async Task<IActionResult> GenerateAndDownloadExcel([FromRoute] Guid moduleOfferingId, [FromRoute] Guid evaluationId)
    {
        try
        {
            var studentResults = await _unitOfWork.StudentResults.GetEvaluationResultAsync(evaluationId);
            var moduleOffering = await _unitOfWork.ModuleOfferings.GetAsync(moduleOfferingId);
            var evaluation = await _unitOfWork.Evaluations.GetByEvaluationIdAsync(evaluationId);
            var results = _mapper.Map<IEnumerable<GetStudentResultResponse>>(studentResults);

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Results");
            var headerStyle = workbook.Style;
            headerStyle.Font.Bold = true;
            headerStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            worksheet.Range("A1:H1").Merge().Value = "Faculty of Engineering, University of Ruhuna";
            worksheet.Cell("A1").Style
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Font.SetBold()
                .Font.FontSize = 20;

            worksheet.Cell(3, 2).Value = "Module Code";
            worksheet.Cell(4, 2).Value = "Module Name";
            worksheet.Cell(5, 2).Value = "Semester";
            worksheet.Cell(6, 2).Value = "Evaluation";
            worksheet.Cell(7, 2).Value = "Cordinator";

            worksheet.Cell(3, 3).Value = moduleOffering.Module.Code;
            worksheet.Cell(4, 3).Value = moduleOffering.Module.Name;
            worksheet.Cell(5, 3).Value = moduleOffering.Module.Semester;
            worksheet.Cell(6, 3).Value = evaluation.Name;
            worksheet.Cell(7, 3).Value = moduleOffering.Coordinator.FirstName + " " + moduleOffering.Coordinator.LastName;


            worksheet.Cell(9, 1).Value = "Reg. No.";
            worksheet.Cell(9, 2).Value = "Name";
            worksheet.Cell(9, 3).Value = "Marks";

            worksheet.Row(9).Style = headerStyle;

            var row = 10;
            foreach (var result in results)
            {
                worksheet.Cell(row, 1).Value = result.RegistrationNum;
                worksheet.Cell(row, 2).Value = result.FullName;
                var cell = worksheet.Cell(row, 3);
                cell.Value = result.StudentScore;
                cell.Style.Protection.Locked = false;
                row++;
            }

            worksheet.Column("A").Style.Protection.Locked = true;
            worksheet.Column("B").Style.Protection.Locked = true;
            worksheet.Protect("password");

            worksheet.Columns().AdjustToContents();

            var range = worksheet.Range("A9:C" + (row - 1));
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