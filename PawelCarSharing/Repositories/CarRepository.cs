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
            return _dbContext.Cars.SingleOrDefault(x => x.Id == id && !x.IsDeleted);
        }

        public List<Car> GetAll()
        {
            return _dbContext.Cars.Where(x => !x.IsDeleted).ToList();
        }

        public List<Car> GetAllByIds(List<int> ids)
        {
            return _dbContext.Cars.Where(x => ids.Contains(x.Id) && !x.IsDeleted).ToList();
        }

        public void Add(Car car)
        {
            car.IsDeleted = false;
            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();
        }

        public void Update(Car car)
        {
            Car existingCar = GetOne(car.Id);
            if (existingCar == null) return;

            existingCar.Brand = car.Brand;
            existingCar.Model = car.Model;
            existingCar.RegistrationPlate = car.RegistrationPlate;
            existingCar.ProductionYear = car.ProductionYear;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var carToDelete = GetOne(id);
            if (carToDelete == null)
                return;

            carToDelete.IsDeleted = true;
            _dbContext.SaveChanges();
        }

        public int GetMaxId()
        {
            return _dbContext.Cars.Max(x => x.Id);
        }
    }
}
