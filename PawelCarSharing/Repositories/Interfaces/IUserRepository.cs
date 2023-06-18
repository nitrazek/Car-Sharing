using PawelCarSharing.Models;
namespace PawelCarSharing.Repositories.Interfaces
{
    public interface IUserRepository
    {
        private static ICollection<User> db;
        public User GetOne(int id);
        public List<User> GetAllByIds(List<int> ids);
        public void Add(User user);
    }
}
