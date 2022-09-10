using ProgrammersWeek.TalkManager.Shared.Dto;
using ProgrammersWeek.TalkManager.Shared.Dto.Responses;

namespace ProgrammersWeek.TalkManager.BlazorUi.Interfaces;

public interface ITalkClientService
{
    Task<ServiceResponse<List<TalkResponse>>?> GetAllAsync();
    Task<ServiceResponse<TalkResponse>?> GetByIdAsync(int id);
}