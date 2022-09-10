using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using ProgrammersWeek.TalkManager.BlazorUi.Services;
using ProgrammersWeek.TalkManager.Shared.Dto.Responses;

namespace ProgrammersWeek.TalkManager.BlazorUi.Pages
{
    [Authorize]
    public partial class AllTalks
    {
        [Inject]
        public ITalkClientService TalkClientService { get; set; }

        public List<TalkResponse>? Talks { get; set; }

        public string Message { get; set; } = "Loading talks...";

        protected override async Task OnInitializedAsync()
        {
            var response = await TalkClientService.GetAllAsync();
            if (response is null || !response.IsValid())
            {
                Message = "There was an error loading the talks. Try refreshing the page.";
                return;
            }

            Talks = response.Response;

            await base.OnInitializedAsync();
        }
    }
}
