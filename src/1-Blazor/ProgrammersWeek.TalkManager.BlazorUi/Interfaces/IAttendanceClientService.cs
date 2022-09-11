using ProgrammersWeek.TalkManager.Shared.Dto;
using ProgrammersWeek.TalkManager.Shared.Dto.Requests;

namespace ProgrammersWeek.TalkManager.BlazorUi.Interfaces
{
    public interface IAttendanceClientService
    {
        Task<ServiceResponse<List<int>>?> GetTalkIdsForAsync(string participantId);
        Task<ServiceResponse<int>?> RegisterParticipantAsync(AttendanceRequest payload);
    }
}