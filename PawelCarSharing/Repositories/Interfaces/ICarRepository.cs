using PawelCarSharing.Models;
namespace PawelCarSharing.Repositories.Interfaces
{
    public interface ICarRepository
    {
        public Car GetOne(int id);
        public List<Car> GetAllByIds(List<int> ids);
        public void Add(Car car);
        public void Delete(int id);
        public int GetMaxId();
    }
}
