﻿namespace PawelCarSharing.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string RegistrationPlate { get; set; }
        public int ProductionYear { get; set; }

        public bool IsDeleted { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
