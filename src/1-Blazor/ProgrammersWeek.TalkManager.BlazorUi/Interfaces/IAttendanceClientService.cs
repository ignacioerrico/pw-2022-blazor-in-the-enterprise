using ProgrammersWeek.TalkManager.Shared.Dto;
using ProgrammersWeek.TalkManager.Shared.Dto.Requests;
using ProgrammersWeek.TalkManager.Shared.Dto.Responses;

namespace ProgrammersWeek.TalkManager.BlazorUi.Interfaces
{
    public interface IAttendanceClientService
    {
        Task<ServiceResponse<List<int>>?> GetTalkIdsForAsync(string participantId);
        Task<ServiceResponse<int>?> RegisterParticipantAsync(AttendanceRequest payload);
        Task<ServiceResponse<List<MyTalkResponse>>?> GetTalksForAsync(string participantId);
    }
}