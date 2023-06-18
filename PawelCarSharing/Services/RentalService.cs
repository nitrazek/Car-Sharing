using System;
using System.Collections.Generic;
using PawelCarSharing.Models;
using PawelCarSharing.Repositories;
using PawelCarSharing.Repositories.Interfaces;

namespace PawelCarSharing.Services
{
    public class RentalService
    {
        private IRentalRepository _rentalRepository;

        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public Rental GetRentalById(int id)
        {
            return _rentalRepository.GetOne(id);
        }

        public void CreateRental(Rental rental)
        {
            rental.Id = _rentalRepository.GetMaxId() + 1;
            _rentalRepository.Add(rental);
        }
    }
}
