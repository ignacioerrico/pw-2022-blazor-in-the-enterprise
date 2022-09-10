using IdentityModel.Client;
using ProgrammersWeek.TalkManager.BlazorUi.Services;
using ProgrammersWeek.TalkManager.Shared.Dto;
using System.Text.Json;

namespace ProgrammersWeek.TalkManager.BlazorServerApp.Services
{
    public class CallEndpoint : ICallEndpoint
    {
        private readonly HttpClient _httpClient;
        private readonly RefreshTokenService _refreshTokenService;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public CallEndpoint(HttpClient httpClient, RefreshTokenService refreshTokenService)
        {
            _httpClient = httpClient;
            _refreshTokenService = refreshTokenService;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<ServiceResponse<T>?> HttpGetAsync<T>(string requestUri)
        {
            _httpClient.SetBearerToken(await _refreshTokenService.RetrieveAccessTokenAsync());
            var stream = await _httpClient.GetStreamAsync(requestUri);
            var response = await JsonSerializer.DeserializeAsync<ServiceResponse<T>>(stream, _jsonSerializerOptions);
            return response;
        }
    }
}
