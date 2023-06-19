using System.ComponentModel.DataAnnotations;

namespace PawelCarSharing.Models
{
    public class Car
    {
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "Marka")]
        [Required(ErrorMessage = "Marka jest obowiązkowa!")]
        public string Brand { get; set; }

		[Display(Name = "Model")]
		[Required(ErrorMessage = "Model jest obowiązkowy!")]
		public string Model { get; set; }

		[Display(Name = "Numer rejestracyjny")]
		[Required(ErrorMessage = "Rejestracja jest obowiązkowa!")]
		public string RegistrationPlate { get; set; }

		[Display(Name = "Rok produkcji")]
		[Required(ErrorMessage = "Rok jest obowiązkowy!")]
		public int ProductionYear { get; set; }

		[Display(Name = "Czy usunięty")]
		public bool IsDeleted { get; set; }

        [Display(Name = "Lista wypożyczeń")]
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
