using AutoMapper;
using ERP.RequestManagement.Core.DTOs.Requests;
using ERP.RequestManagement.Core.DTOs.Responses;
using ERP.RequestManagement.Core.Entity;
using ERP.RequestManagement.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.RequestManagement.Api.Controllers
{
    public class StudentRequestController : BaseController
    {
        public StudentRequestController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentRequests()
        {
            var studentRequests = await _unitOfWork.StudentRequests.GetAllAsync();
            var results = _mapper.Map<IEnumerable<GetStudentMessagesResponse>>(studentRequests);
            return Ok(results);
        }

        [HttpPost]
        [Route("{senderId:guid}/{recieverId:guid}")]
        public async Task<IActionResult> AddStudentRequest([FromBody] CreateStudentMessageRequest messageRequest, Guid senderId, Guid recieverId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var requestEntity = new StudentRequest()
            {
                Message = messageRequest.Message,
                SenderId = senderId,
                RecieverId = recieverId,
                IsChecked = true,
                Status = 1,
            };

            await _unitOfWork.StudentRequests.AddAsync(requestEntity);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        [HttpGet]
        [Route("/requests/{teacherId:guid}")]
        public async Task<IActionResult> GetStudentRequestsByTeacherId(Guid teacherId)   // teacher is the reciever
        {
            var studentRequests = await _unitOfWork.StudentRequests.GetStudentRequestsByTeacherIdAsync(teacherId);
            var results = _mapper.Map<IEnumerable<GetStudentMessagesResponse>>(studentRequests);
            return Ok(results);
        }

        [HttpGet]
        [Route("{requestId:guid}/")]
        public async Task<IActionResult> GetStudentRequestByRequestId(Guid requestId)   // teacher is the reciever
        {
            var studentRequest = await _unitOfWork.StudentRequests.GetStudentRequestByRequestIdAsync(requestId);
            var results = _mapper.Map<GetStudentMessagesResponse>(studentRequest);
            return Ok(results);
        }

    }
}
