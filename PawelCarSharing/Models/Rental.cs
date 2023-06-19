using System.ComponentModel.DataAnnotations;

namespace PawelCarSharing.Models
{
    public class Rental
    {
		[Display(Name = "Id")]
		[Required(ErrorMessage = "Id jest obowiązkowe!")]
		public int Id { get; set; }

		[Display(Name = "Data rozpoczęcia")]
		[Required(ErrorMessage = "Data rozpoczęcia jest obowiązkowa!")]
		public DateTime StartDate { get; set; }

		[Display(Name = "Data zakończenia")]
		[Required(ErrorMessage = "Data zakończenia jest obowiązkowy!")]
		public DateTime EndDate { get; set; }

		[Display(Name = "Przejechane kilometry")]
		[Required(ErrorMessage = "Kilometry są obowiązkowe!")]
		public decimal Kilometers { get; set; }

        [Display(Name = "Id Samochodu")]
        [Required(ErrorMessage = "Id samochodu jest obowiązkowe!")]
		public int CarId { get; set; }

        [Display(Name = "Samochód")]
        [Required(ErrorMessage = "Samochodu jest obowiązkowy!")]
        public Car Car { get; set; }

		[Display(Name = "Lista użytkowników")]
		public ICollection<AccountRental> Accounts { get; set; } = new List<AccountRental>();
	}
}
