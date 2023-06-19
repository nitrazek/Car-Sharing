using PawelCarSharing.Enums;
using System.ComponentModel.DataAnnotations;

namespace PawelCarSharing.Models
{
    public class Account
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

		[Display(Name = "Login")]
		[Required(ErrorMessage = "Login jest obowiązkowy!")]
		public string Login { get; set; }

		[Display(Name = "Hasło")]
		[Required(ErrorMessage = "Hasło jest obowiązkowe!")]
		[RegularExpression("^.{4,20}$", ErrorMessage = "Hasło powinno mieć od 4 do 20 znaków.")]
		public string Password { get; set; }

		[Display(Name = "Imię")]
		[Required(ErrorMessage = "Imię jest obowiązkowe!")]
		public string FirstName { get; set; }

		[Display(Name = "Nazwisko")]
		[Required(ErrorMessage = "Nazwisko jest obowiązkowe!")]
		public string LastName { get; set; }

		[Display(Name = "Rola")]
		[Required(ErrorMessage = "Rola jest obowiązkowa!")]
		public AccountRole AccountRole { get; set; }

		[Display(Name = "Czy usunięte")]
		public bool IsDeleted { get; set; }
    }
}
