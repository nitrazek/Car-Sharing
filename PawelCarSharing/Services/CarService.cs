using System.Collections.Generic;
using System.Xml.Linq;
using PawelCarSharing.Models;
using PawelCarSharing.Repositories;
using PawelCarSharing.Repositories.Interfaces;

namespace PawelCarSharing.Services
{
    public class CarService
    {
        private ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public Car GetCarById(int id)
        {
            return _carRepository.GetOne(id);
        }

        public Car CreateCar(Car car)
        {
            car.Id = _carRepository.GetMaxId() + 1;
            _carRepository.Add(car);
            return car;
        }
    }
}