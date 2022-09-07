using Microsoft.AspNetCore.Components;
using ProgrammersWeek.TalkManager.Shared.Dto.Responses;

namespace ProgrammersWeek.TalkManager.BlazorUi.Dialogs
{
    public partial class SpeakersInfoDialog
    {
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public List<AuthorResponse> Authors { get; set; } = new();

        public string AuthorsNames { get; set; }

        protected override void OnParametersSet()
        {
            AuthorsNames = string.Join(", ", Authors.Select(a => a.Name));
            base.OnParametersSet();
        }
    }
}
