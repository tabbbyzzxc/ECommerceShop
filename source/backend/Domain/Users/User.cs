namespace Domain.Users
{
    public class User
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public bool IsActive { get; set; }

        public List<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
    }
}