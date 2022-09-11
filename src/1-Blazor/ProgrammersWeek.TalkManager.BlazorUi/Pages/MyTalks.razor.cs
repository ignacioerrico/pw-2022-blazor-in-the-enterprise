using IdentityModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ProgrammersWeek.TalkManager.BlazorUi.Interfaces;
using ProgrammersWeek.TalkManager.Shared.Dto.Responses;

namespace ProgrammersWeek.TalkManager.BlazorUi.Pages
{
    public partial class MyTalks
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Inject]
        public IAttendanceClientService AttendanceClientService { get; set; }

        public List<MyTalkResponse>? Talks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var user = (await AuthenticationStateTask).User;
            var participantId = user.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Subject)?.Value;
            if (participantId is not null)
            {
                var talks = await AttendanceClientService.GetTalksForAsync(participantId);
                if (talks is not null && talks.IsValid())
                {
                    Talks = talks.Response;
                }
            }

            await base.OnInitializedAsync();
        }
    }
}
