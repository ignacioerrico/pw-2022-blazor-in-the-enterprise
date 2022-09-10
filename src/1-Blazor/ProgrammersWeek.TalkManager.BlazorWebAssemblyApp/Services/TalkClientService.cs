using ProgrammersWeek.TalkManager.BlazorUi.Interfaces;
using ProgrammersWeek.TalkManager.Shared.Dto;
using ProgrammersWeek.TalkManager.Shared.Dto.Responses;
using ProgrammersWeek.TalkManager.Shared.Services;
using System.Text.Json;

namespace ProgrammersWeek.TalkManager.BlazorWebAssemblyApp.Services
{
    public class TalkClientService : ITalkClientService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public TalkClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<ServiceResponse<List<TalkResponse>>?> GetAllAsync()
        {
            var stream = await _httpClient.GetStreamAsync(ServiceEndpoints.GetAll);
            var talks = await JsonSerializer.DeserializeAsync<ServiceResponse<List<TalkResponse>>>(stream, _jsonSerializerOptions);
            return talks;
        }

        public async Task<ServiceResponse<TalkResponse>?> GetByIdAsync(int id)
        {
            var stream = await _httpClient.GetStreamAsync(ServiceEndpoints.GetById(id));
            var talk = await JsonSerializer.DeserializeAsync<ServiceResponse<TalkResponse>>(stream, _jsonSerializerOptions);
            return talk;
        }
    }
}
