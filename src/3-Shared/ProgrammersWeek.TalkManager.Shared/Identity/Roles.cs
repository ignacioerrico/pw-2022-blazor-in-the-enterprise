namespace ProgrammersWeek.TalkManager.Shared.Identity
{
    public static class Roles
    {
        public static string[] AllRoles = { Admin, Participant };

        public const string Admin = "Admin";
        public const string Participant = "Participant";

        public static string For(params string[] roles)
            => string.Join(",", roles);
    }
}
