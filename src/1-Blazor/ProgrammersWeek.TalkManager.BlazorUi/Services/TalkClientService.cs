using IdentityModel.Client;
using ProgrammersWeek.TalkManager.Shared.Dto;
using ProgrammersWeek.TalkManager.Shared.Dto.Responses;
using System.Text.Json;

namespace ProgrammersWeek.TalkManager.BlazorUi.Services
{
    public interface ITalkClientService
    {
        Task<ServiceResponse<List<TalkResponse>>?> GetAllAsync();
        Task<ServiceResponse<TalkResponse>?> GetByIdAsync(int id);
    }

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
            var stream = await _httpClient.GetStreamAsync(Endpoint.GetAll);
            var talks = await JsonSerializer.DeserializeAsync<ServiceResponse<List<TalkResponse>>>(stream, _jsonSerializerOptions);
            return talks;
        }

        public async Task<ServiceResponse<TalkResponse>?> GetByIdAsync(int id)
        {
            _httpClient.SetBearerToken(await _refreshTokenService.RetrieveAccessTokenAsync());
            var stream = await _httpClient.GetStreamAsync(Endpoint.GetById(id));
            var talk = await JsonSerializer.DeserializeAsync<ServiceResponse<TalkResponse>>(stream, _jsonSerializerOptions);
            return talk;
        }
    }
}
