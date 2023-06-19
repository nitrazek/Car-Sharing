namespace PawelCarSharing.Models
{
    public class AccountRental
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int RentalId { get; set; }
        public Rental Rental { get; set; }
    }
}
