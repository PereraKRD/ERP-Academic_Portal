using AutoMapper;
using ERP.RequestManagement.Core.DTOs.Requests;
using ERP.RequestManagement.Core.DTOs.Responses;
using ERP.RequestManagement.Core.Entity;
using ERP.RequestManagement.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.RequestManagement.Api.Controllers
{
    public class StaffRequestController : BaseController
    {
        public StaffRequestController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStaffRequests()
        {
            var staffRequests = await _unitOfWork.StaffRequests.GetAllAsync();
            var results = _mapper.Map<IEnumerable<GetStaffMessageResponse>>(staffRequests);
            return Ok(results);
        }

        [HttpPost]
        [Route("{senderId:guid}/{recieverId:guid}")]
        public async Task<IActionResult> AddStaffRequest([FromBody] CreateStaffMessageRequest messageRequest, Guid senderId, Guid recieverId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var requestEntity = new StaffRequest()
            {
                Message = messageRequest.Message,
                Header = messageRequest.Header,
                SenderId = senderId,
                RecieverId = recieverId,
                IsChecked = true,
                Status = 1,
            };

            await _unitOfWork.StaffRequests.AddAsync(requestEntity);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        [HttpGet]
        [Route("/StaffRequests/Outgoing/{teacherId:guid}")]
        public async Task<IActionResult> GetStaffRequestsBySenderId(Guid teacherId)   // teacher is the sender
        {
            var staffRequests = await _unitOfWork.StaffRequests.GetStaffRequestsBySenderIdAsync(teacherId);
            var results = _mapper.Map<IEnumerable<GetStaffMessageResponse>>(staffRequests);
            return Ok(results);
        }

        [HttpGet]
        [Route("/StaffRequests/Incoming/{teacherId:guid}")]
        public async Task<IActionResult> GetStaffRequestsByRecieverId(Guid teacherId)   // teacher is the sender
        {
            var staffRequests = await _unitOfWork.StaffRequests.GetStaffRequestsByRecieverIdAsync(teacherId);
            var results = _mapper.Map<IEnumerable<GetStaffMessageResponse>>(staffRequests);
            return Ok(results);
        }

        [HttpGet]
        [Route("{requestId:guid}/")]
        public async Task<IActionResult> GetStaffRequestByRequestId(Guid requestId)   // teacher is the reciever
        {
            var staffRequest = await _unitOfWork.StaffRequests.GetStaffRequestByRequestIdAsync(requestId);
            var results = _mapper.Map<GetStaffMessageResponse>(staffRequest);
            return Ok(results);
        }



    }
}
