using Mapster;
using ProgrammersWeek.TalkManager.Shared.Dto.Requests;
using ProgrammersWeek.TalkManager.Shared.Dto.Responses;
using ProgrammersWeek.TalkManager.Shared.Models;

namespace ProgrammersWeek.TalkManager.WebApi.Mappings
{
    public static class Mapping
    {
        public static void Configure()
        {
            TypeAdapterConfig<Talk, TalkResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.DateTimeUtc, src => src.DateTimeUtc)
                .Map(dest => dest.InterestArea, src => src.InterestArea == null ? string.Empty : src.InterestArea.Name)
                .Map(dest => dest.Region, src => src.Region == null ? string.Empty : src.Region.Name)
                .Map(dest => dest.SessionType, src => src.SessionType);

            TypeAdapterConfig<Author, AuthorResponse>
                .NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Bio, src => src.Bio)
                .Map(dest => dest.Picture, src => src.Picture);

            TypeAdapterConfig<SessionType, string>
                .NewConfig()
                .MapWith(st => st == SessionType.Online ? "Online" :
                    st == SessionType.Onsite ? "On site" :
                    st == SessionType.Client ? "Client presentation" : "Other");

            TypeAdapterConfig<AttendanceRequest, Attendance>
                .NewConfig()
                .Map(dest => dest.ParticipantId, src => src.ParticipantId)
                .Map(dest => dest.TalkId, src => src.TalkId);

            TypeAdapterConfig<Attendance, MyTalkResponse>
                .NewConfig()
                .Map(dest => dest.Title, src => src.Talk.Title)
                .Map(dest => dest.DateTimeUtc, src => src.Talk.DateTimeUtc)
                .Map(dest => dest.Authors, src => src.Talk.Authors.Select(a => a.Name))
                .Map(dest => dest.InterestArea, src => src.Talk.InterestArea.Name)
                .Map(dest => dest.Region, src => src.Talk.Region.Name);
        }
    }
}
