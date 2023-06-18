using PawelCarSharing.Enums;

namespace PawelCarSharing.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AccountRole AccountRole { get; set; }
        public bool IsDeleted { get; set; }

    }
}
