using PawelCarSharing.Repositories.Interfaces;
using PawelCarSharing.Models;
using PawelCarSharing.Data;
using System.Collections.Generic;
using System.Linq;

namespace PawelCarSharing.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RentalRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Rental GetOne(int id)
        {
            return _dbContext.Rentals.SingleOrDefault(x => x.Id == id);
        }

        public List<Rental> GetAllByIds(List<int> ids)
        {
            return _dbContext.Rentals.Where(x => ids.Contains(x.Id)).ToList();
        }

        public void Add(Rental rental)
        {
            _dbContext.Rentals.Add(rental);
        }

        public void Delete(int id)
        {
            var rentalToDelete = GetOne(id);
            if (rentalToDelete == null)
                return;

            //tutaj wyjebać z bazy całkowicie ale idk jak
        }

        public int GetMaxId()
        {
            return _dbContext.Rentals.Max(x => x.Id);
        }
    }
}
