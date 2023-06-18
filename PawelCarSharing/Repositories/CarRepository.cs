using PawelCarSharing.Repositories.Interfaces;
using PawelCarSharing.Models;
using PawelCarSharing.Data;
using System.Collections.Generic;
using System.Linq;

namespace PawelCarSharing.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CarRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Car GetOne(int id)
        {
            return _dbContext.Cars.SingleOrDefault(x => x.Id == id);
        }

        public List<Car> GetAllByIds(List<int> ids)
        {
            return _dbContext.Cars.Where(x => ids.Contains(x.Id)).ToList();
        }

        public void Add(Car car)
        {
            _dbContext.Cars.Add(car);
        }

        public void Delete(int id)
        {
            var carToDelete = GetOne(id);
            if (carToDelete == null)
                return;

            carToDelete.IsDeleted = true;
        }

        public int GetMaxId()
        {
            return _dbContext.Cars.Max(x => x.Id);
        }
    }
}
