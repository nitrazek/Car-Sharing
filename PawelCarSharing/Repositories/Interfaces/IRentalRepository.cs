using PawelCarSharing.Models;
namespace PawelCarSharing.Repositories.Interfaces
{
    public interface IRentalRepository
    {
        public Rental GetOne(int id);
        public List<Rental> GetAllByIds(List<int> ids);
        public void Add(Rental rental);
        public void Update(Rental rental);
        public void Delete(int id);
        public int GetMaxId();
    }
}
