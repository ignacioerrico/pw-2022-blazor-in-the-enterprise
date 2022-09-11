using ProgrammersWeek.TalkManager.BlazorUi.Services;
using ProgrammersWeek.TalkManager.Shared.Dto;
using System.Net.Http.Json;

namespace ProgrammersWeek.TalkManager.BlazorServerApp.Services
{
    public class CallEndpoint : ICallEndpoint
    {
        private readonly HttpClient _httpClient;

        public CallEndpoint(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<T>?> HttpGetAsync<T>(string requestUri)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<T>>(requestUri);
            return result;
        }

        public async Task<ServiceResponse<T>?> HttpPostAsync<T, TPayload>(string requestUri, TPayload payload)
        {
            var httpResponseMessage = await _httpClient.PostAsJsonAsync(requestUri, payload);
            if (httpResponseMessage is null)
            {
                return default;
            }

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<ServiceResponse<T>>();
            return response;
        }
    }
}
