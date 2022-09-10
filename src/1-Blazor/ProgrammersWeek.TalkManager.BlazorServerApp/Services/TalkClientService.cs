using System.Text.Json;
using IdentityModel.Client;
using ProgrammersWeek.TalkManager.BlazorUi.Interfaces;
using ProgrammersWeek.TalkManager.Shared.Dto;
using ProgrammersWeek.TalkManager.Shared.Dto.Responses;
using ProgrammersWeek.TalkManager.Shared.Services;

namespace ProgrammersWeek.TalkManager.BlazorServerApp.Services
{
    public class TalkClientService : ITalkClientService
    {
        private readonly HttpClient _httpClient;
        private readonly RefreshTokenService _refreshTokenService;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public TalkClientService(HttpClient httpClient, RefreshTokenService refreshTokenService)
        {
            _httpClient = httpClient;
            _refreshTokenService = refreshTokenService;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<ServiceResponse<List<TalkResponse>>?> GetAllAsync()
        {
            _httpClient.SetBearerToken(await _refreshTokenService.RetrieveAccessTokenAsync());
            var stream = await _httpClient.GetStreamAsync(ServiceEndpoints.GetAll);
            var talks = await JsonSerializer.DeserializeAsync<ServiceResponse<List<TalkResponse>>>(stream, _jsonSerializerOptions);
            return talks;
        }

        public async Task<ServiceResponse<TalkResponse>?> GetByIdAsync(int id)
        {
            _httpClient.SetBearerToken(await _refreshTokenService.RetrieveAccessTokenAsync());
            var stream = await _httpClient.GetStreamAsync(ServiceEndpoints.GetById(id));
            var talk = await JsonSerializer.DeserializeAsync<ServiceResponse<TalkResponse>>(stream, _jsonSerializerOptions);
            return talk;
        }
    }
}
