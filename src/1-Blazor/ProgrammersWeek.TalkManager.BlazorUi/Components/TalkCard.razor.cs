using IdentityModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ProgrammersWeek.TalkManager.BlazorUi.Interfaces;
using ProgrammersWeek.TalkManager.Shared.Dto.Requests;
using ProgrammersWeek.TalkManager.Shared.Dto.Responses;

namespace ProgrammersWeek.TalkManager.BlazorUi.Components
{
    public partial class TalkCard
    {
        private string? _participantId;

        [Parameter]
        public TalkResponse? Talk { get; set; }

        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Inject]
        public IAttendanceClientService AttendanceClientService { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        public bool IsAttending { get; set; }
        public bool RegisteredCompleted { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var user = (await AuthenticationStateTask).User;
            _participantId = user.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Subject)?.Value;
            if (_participantId is not null)
            {
                var response = await AttendanceClientService.GetTalkIdsForAsync(_participantId);
                if (response?.Response is null || Talk is null)
                {
                    await base.OnInitializedAsync();
                    return;
                }
                
                if (response.Response.Contains(Talk.Id))
                {
                    IsAttending = true;
                    RegisteredCompleted = true;
                }
            }

            await base.OnInitializedAsync();
        }

        public void ShowSpeakersInfo(List<AuthorResponse> authors)
        {
            var dialogParameters = new DialogParameters { ["Authors"] = authors };
            DialogService.Show<SpeakersInfoDialog>("Speakers info", dialogParameters);
        }

        private async Task AttendTalkWithId(int talkId)
        {
            if (_participantId is null)
            {
                return;
            }
            
            IsAttending = true;

            var request = new AttendanceRequest
            {
                ParticipantId = _participantId,
                TalkId = talkId
            };

            var response = await AttendanceClientService.RegisterParticipantAsync(request);

            if (response is null || !response.IsValid())
            {
                // The attendance could not be registered
                IsAttending = false;
                return;
            }

            RegisteredCompleted = true;
        }
    }
}
