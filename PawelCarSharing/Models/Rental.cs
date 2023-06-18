﻿namespace PawelCarSharing.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int AccountId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Kilometers { get; set; }

        public virtual Car Car { get; set; }

    }
}
