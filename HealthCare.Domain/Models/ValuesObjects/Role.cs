namespace HealthCare.Domain.ValueObjects
{
    public static class Role
    {
        public const string SuperAdministrator = "SuperAdministrator";
        public const string User = "User";

        public static List<string> Roles { get { return new List<string> { SuperAdministrator, User }; } }
    }
}
