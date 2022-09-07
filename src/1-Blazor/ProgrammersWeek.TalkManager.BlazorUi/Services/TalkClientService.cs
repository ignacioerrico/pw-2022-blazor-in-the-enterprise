using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ProgrammersWeek.TalkManager.Shared.Dto;
using ProgrammersWeek.TalkManager.Shared.Dto.Responses;

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
            var stream = await _httpClient.GetStreamAsync(Endpoint.GetAll);
            var talks = await JsonSerializer.DeserializeAsync<ServiceResponse<List<TalkResponse>>>(stream, _jsonSerializerOptions);
            return talks;
        }
        
        public async Task<ServiceResponse<TalkResponse>?> GetByIdAsync(int id)
        {
            var stream = await _httpClient.GetStreamAsync(Endpoint.GetById(id));
            var talk = await JsonSerializer.DeserializeAsync<ServiceResponse<TalkResponse>>(stream, _jsonSerializerOptions);
            return talk;
        }
    }
}
