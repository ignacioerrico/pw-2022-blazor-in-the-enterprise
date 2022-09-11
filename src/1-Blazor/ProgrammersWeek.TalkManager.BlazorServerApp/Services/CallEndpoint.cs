using IdentityModel.Client;
using ProgrammersWeek.TalkManager.BlazorUi.Services;
using ProgrammersWeek.TalkManager.Shared.Dto;

namespace ProgrammersWeek.TalkManager.BlazorServerApp.Services
{
    public class CallEndpoint : ICallEndpoint
    {
        private readonly HttpClient _httpClient;
        private readonly RefreshTokenService _refreshTokenService;

        public CallEndpoint(HttpClient httpClient, RefreshTokenService refreshTokenService)
        {
            _httpClient = httpClient;
            _refreshTokenService = refreshTokenService;
        }

        public async Task<ServiceResponse<T>?> HttpGetAsync<T>(string requestUri)
        {
            _httpClient.SetBearerToken(await _refreshTokenService.RetrieveAccessTokenAsync());
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<T>>(requestUri);
            return result;
        }

        public async Task<ServiceResponse<T>?> HttpPostAsync<T, TPayload>(string requestUri, TPayload payload)
        {
            _httpClient.SetBearerToken(await _refreshTokenService.RetrieveAccessTokenAsync());
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
