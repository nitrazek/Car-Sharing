using System;
using System.Collections.Generic;
using PawelCarSharing.Models;

namespace PawelCarSharing.Services
{
    public class RentalService
    {
        private readonly List<Rental> _rentals;

        public RentalService()
        {
            _rentals = new List<Rental>();
        }

        public IEnumerable<Rental> GetRentals()
        {
            return _rentals;
        }

        public Rental GetRentalById(int id)
        {
            return _rentals.Find(rental => rental.Id == id);
        }

        public Rental CreateRental(Rental rental)
        {
            rental.Id = GenerateRentalId();
            _rentals.Add(rental);
            return rental;
        }

        public Rental UpdateRental(int id, Rental rental)
        {
            var existingRental = _rentals.Find(r => r.Id == id);
            if (existingRental != null)
            {
                existingRental.CarId = rental.CarId;
                existingRental.UserId = rental.UserId;
                existingRental.StartDate = rental.StartDate;
                existingRental.EndDate = rental.EndDate;
                existingRental.Kilometers = rental.Kilometers;
                // Update other rental properties if needed
                return existingRental;
            }
            return null;
        }

        public Rental DeleteRental(int id)
        {
            var rental = _rentals.Find(r => r.Id == id);
            if (rental != null)
            {
                _rentals.Remove(rental);
                return rental;
            }
            return null;
        }

        private int GenerateRentalId()
        {
            // Generate a unique rental ID based on your logic (e.g., auto-increment, GUID, etc.)
            // This is just a sample implementation
            return _rentals.Count + 1;
        }
    }
}
