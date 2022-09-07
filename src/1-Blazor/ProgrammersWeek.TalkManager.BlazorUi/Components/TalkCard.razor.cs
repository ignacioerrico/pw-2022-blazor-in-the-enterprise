using Microsoft.AspNetCore.Components;
using ProgrammersWeek.TalkManager.Shared.Dto.Responses;

namespace ProgrammersWeek.TalkManager.BlazorUi.Components
{
    public partial class TalkCard
    {
        [Parameter]
        public TalkResponse? Talk { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        public void ShowSpeakersInfo(List<AuthorResponse> authors)
        {
            var dialogParameters = new DialogParameters { ["Authors"] = authors };
            DialogService.Show<SpeakersInfoDialog>("Speakers info", dialogParameters);
        }
    }
}
