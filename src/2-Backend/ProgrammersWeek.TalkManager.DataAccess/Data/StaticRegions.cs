using ProgrammersWeek.TalkManager.Shared.Models;

namespace ProgrammersWeek.TalkManager.DataAccess.Data
{
    internal static class StaticRegions
    {
        public static List<Region> GetList() =>
            new()
            {
                new()
                {
                    Id = 1,
                    Name = "North America"
                },
                new()
                {
                    Id = 2,
                    Name = "Argentina"
                },
                new()
                {
                    Id = 3,
                    Name = "Romania"
                },
            };
    }
}
