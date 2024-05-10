using AutoMapper;
using ERP.RequestManagement.Core.DTOs.Requests;
using ERP.RequestManagement.Core.DTOs.Responses;
using ERP.RequestManagement.Core.Entity;
using ERP.RequestManagement.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.RequestManagement.Api.Controllers
{
    public class TeacherRequestController : BaseController
    {
        public TeacherRequestController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeacherRequests()
        {
            var teacherRequests = await _unitOfWork.TeacherRequests.GetAllAsync();
            var results = _mapper.Map<IEnumerable<GetTeacherMessagesResponse>>(teacherRequests);
            return Ok(results);
        }

        [HttpPost]
        [Route("{senderId:guid}/{recieverId:guid}")]
        public async Task<IActionResult> AddTeacherRequest([FromBody] CreateTeacherMessageRequest messageRequest, Guid senderId, Guid recieverId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var requestEntity = new TeacherRequest()
            {
                Message = messageRequest.Message,
                Header = messageRequest.Header,
                SenderId = senderId,
                RecieverId = recieverId,
                IsChecked = true,
                Status = 1 ,
            };

            await _unitOfWork.TeacherRequests.AddAsync(requestEntity);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        [HttpGet]
        [Route("/TeacherRequests/{teacherId:guid}")]
        public async Task<IActionResult> GetTeacherRequestsByTeacherId(Guid teacherId)   // teacher is the sender
        {
            var teacherRequests = await _unitOfWork.TeacherRequests.GetTeacherRequestsByTeacherIdAsync(teacherId);
            var results = _mapper.Map<IEnumerable<GetTeacherMessagesResponse>>(teacherRequests);
            return Ok(results);
        }


        [HttpGet]
        [Route("{requestId:guid}/")]
        public async Task<IActionResult> GetTeacherRequestByRequestId(Guid requestId)   // teacher is the reciever
        {
            var teacherRequest = await _unitOfWork.TeacherRequests.GetTeacherRequestByRequestIdAsync(requestId);
            var results = _mapper.Map<GetTeacherMessagesResponse>(teacherRequest);
            return Ok(results);
        }

    }
}
