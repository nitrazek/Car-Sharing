using System.Collections.Generic;
using PawelCarSharing.Models;

namespace PawelCarSharing.Services
{
    public class CarService
    {
        private readonly List<Car> _cars;

        public CarService()
        {
            _cars = new List<Car>();
        }

        public IEnumerable<Car> GetCars()
        {
            return _cars;
        }

        public Car GetCarById(int id)
        {
            return _cars.Find(car => car.Id == id);
        }

        public Car CreateCar(Car car)
        {
            car.Id = GenerateCarId();
            _cars.Add(car);
            return car;
        }

        public Car UpdateCar(int id, Car car)
        {
            var existingCar = _cars.Find(c => c.Id == id);
            if (existingCar != null)
            {
                existingCar.Brand = car.Brand;
                existingCar.Model = car.Model;
                existingCar.RegistrationPlate = car.RegistrationPlate;
                existingCar.ProductionYear = car.ProductionYear;
                // Update other car properties if needed
                return existingCar;
            }
            return null;
        }

        public Car DeleteCar(int id)
        {
            var car = _cars.Find(c => c.Id == id);
            if (car != null)
            {
                _cars.Remove(car);
                return car;
            }
            return null;
        }

        private int GenerateCarId()
        {
            // Generate a unique car ID based on your logic (e.g., auto-increment, GUID, etc.)
            // This is just a sample implementation
            return _cars.Count + 1;
        }
    }
}
