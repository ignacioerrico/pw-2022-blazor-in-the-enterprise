using ProgrammersWeek.TalkManager.BlazorUi.Interfaces;
using ProgrammersWeek.TalkManager.Shared.Dto;
using ProgrammersWeek.TalkManager.Shared.Dto.Responses;
using ProgrammersWeek.TalkManager.Shared.Services;

namespace ProgrammersWeek.TalkManager.BlazorUi.Services
{
    public class TalkClientService : ITalkClientService
    {
        private readonly ICallEndpoint _callEndpoint;

        public TalkClientService(ICallEndpoint callEndpoint)
        {
            _callEndpoint = callEndpoint;
        }

        public async Task<ServiceResponse<List<TalkResponse>>?> GetAllAsync()
        {
            var talks = await _callEndpoint.HttpGetAsync<List<TalkResponse>>(ServiceEndpoints.GetAll);
            return talks;
        }

        public async Task<ServiceResponse<TalkResponse>?> GetByIdAsync(int id)
        {
            var talk = await _callEndpoint.HttpGetAsync<TalkResponse>(ServiceEndpoints.GetById(id));
            return talk;
        }
    }
}
