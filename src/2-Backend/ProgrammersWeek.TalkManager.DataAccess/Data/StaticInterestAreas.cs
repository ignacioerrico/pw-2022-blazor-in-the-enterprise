using ProgrammersWeek.TalkManager.Shared.Models;

namespace ProgrammersWeek.TalkManager.DataAccess.Data
{
    internal static class StaticInterestAreas
    {
        public static List<InterestArea> GetList() =>
            new()
            {
                new()
                {
                    Id = 1,
                    Name = "DevOps"
                },
                new()
                {
                    Id = 2,
                    Name = ".NET"
                },
                new()
                {
                    Id = 3,
                    Name = "Project Management"
                },
                new()
                {
                    Id = 4,
                    Name = "Mobile"
                },
            };
    }
}
