using ProgrammersWeek.TalkManager.Shared.Dto;

namespace ProgrammersWeek.TalkManager.BlazorUi.Services
{
    public interface ICallEndpoint
    {
        public Task<ServiceResponse<T>?> HttpGetAsync<T>(string requestUri);
        public Task<ServiceResponse<T>?> HttpPostAsync<T, TPayload>(string requestUri, TPayload payload);
    }
}
