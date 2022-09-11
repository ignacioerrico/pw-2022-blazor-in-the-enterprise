using ProgrammersWeek.TalkManager.BlazorUi.Interfaces;
using ProgrammersWeek.TalkManager.Shared.Dto;
using ProgrammersWeek.TalkManager.Shared.Dto.Requests;
using ProgrammersWeek.TalkManager.Shared.Services;

namespace ProgrammersWeek.TalkManager.BlazorUi.Services
{
    public class AttendanceClientService : IAttendanceClientService
    {
        private readonly ICallEndpoint _callEndpoint;

        public AttendanceClientService(ICallEndpoint callEndpoint)
        {
            _callEndpoint = callEndpoint;
        }

        public async Task<ServiceResponse<List<int>>?> GetTalkIdsForAsync(string participantId)
        {
            var response = await _callEndpoint.HttpGetAsync<List<int>>(ServiceEndpoints.GetTalkIdsForAsync(participantId));
            return response;
        }

        public async Task<ServiceResponse<int>?> RegisterParticipantAsync(AttendanceRequest payload)
        {
            var rowsInserted = await _callEndpoint.HttpPostAsync<int, AttendanceRequest>(ServiceEndpoints.AttendanceRequest, payload);
            return rowsInserted;
        }
    }
}
