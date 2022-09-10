using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammersWeek.TalkManager.Shared.Dto;
using ProgrammersWeek.TalkManager.Shared.Dto.Responses;
using ProgrammersWeek.TalkManager.WebApi.Services;

namespace ProgrammersWeek.TalkManager.WebApi.Controllers
{
    [Route("api/talk")]
    [ApiController]
    [Authorize]
    public class TalkController : ControllerBase
    {
        private readonly ITalkService _talkService;

        public TalkController(ITalkService talkService)
        {
            _talkService = talkService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResponse<List<TalkResponse>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var allTalks = await _talkService.GetAllAsync();
            var response = new ServiceResponse<List<TalkResponse>>
            {
                Response = allTalks
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ServiceResponse<TalkResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var talk = await _talkService.GetByIdAsync(id);
            var response = new ServiceResponse<TalkResponse>
            {
                Response = talk,
                IsSuccessful = talk != null,
                ErrorMessage = talk is null ? $"Talk ID {id} not found" : string.Empty
            };
            return Ok(response);
        }

        [HttpGet("author/{authorId}")]
        [ProducesResponseType(typeof(ServiceResponse<List<TalkResponse>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByAuthorIdAsync(int authorId)
        {
            var talks = await _talkService.GetByAuthorIdAsync(authorId);
            var response = new ServiceResponse<List<TalkResponse>>
            {
                Response = talks
            };
            return Ok(response);
        }

        [HttpGet("interest-area/{interestAreaId}")]
        [ProducesResponseType(typeof(ServiceResponse<List<TalkResponse>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByInterestAreaIdAsync(int interestAreaId)
        {
            var talks = await _talkService.GetByInterestAreaIdAsync(interestAreaId);
            var response = new ServiceResponse<List<TalkResponse>>
            {
                Response = talks
            };
            return Ok(response);
        }

        [HttpGet("region/{regionId}")]
        [ProducesResponseType(typeof(ServiceResponse<List<TalkResponse>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByRegionIdAsync(int regionId)
        {
            var talks = await _talkService.GetByRegionIdAsync(regionId);
            var response = new ServiceResponse<List<TalkResponse>>
            {
                Response = talks
            };
            return Ok(response);
        }
    }
}
