using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammersWeek.TalkManager.Shared.Dto;
using ProgrammersWeek.TalkManager.Shared.Dto.Requests;
using ProgrammersWeek.TalkManager.Shared.Dto.Responses;
using ProgrammersWeek.TalkManager.WebApi.Services;

namespace ProgrammersWeek.TalkManager.WebApi.Controllers
{
    [Route("api/attendance")]
    [ApiController]
    [Authorize]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet("talk-ids/{participantId}")]
        [ProducesResponseType(typeof(ServiceResponse<List<int>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTalkIdsForAsync(string participantId)
        {
            var talkIds = await _attendanceService.GetTalkIdsForAsync(participantId);
            var response = new ServiceResponse<List<int>>
            {
                Response = talkIds
            };
            return Ok(response);
        }

        [HttpGet("my-talks/{participantId}")]
        [ProducesResponseType(typeof(ServiceResponse<List<MyTalkResponse>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTalksForAsync(string participantId)
        {
            var myTalks = await _attendanceService.GetTalksForAsync(participantId);
            var response = new ServiceResponse<List<MyTalkResponse>>
            {
                Response = myTalks
            };
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResponse<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterParticipantAsync([FromBody] AttendanceRequest request)
        {
            var rowsInserted = await _attendanceService.RegisterParticipantAsync(request);
            var response = new ServiceResponse<int>
            {
                Response = rowsInserted
            };

            if (rowsInserted <= 0)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = "Failed to record attendance.";
            }

            return Ok(response);
        }
    }
}
