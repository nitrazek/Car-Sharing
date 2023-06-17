﻿namespace PawelCarSharing.Models
{
    public class CarRent
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Kilometeres { get; set; }

    }
}
