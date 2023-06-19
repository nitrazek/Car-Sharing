using PawelCarSharing.Models;
namespace PawelCarSharing.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        public Account GetOne(int id);
        public List<Account> GetAll();
        public List<Account> GetAllByIds(List<int> ids);
        public void Add(Account account);
        public void Update(Account account);
        public void Delete(int id);
        public int GetMaxId();
        public Account GetAccountByLoginAndPassword(string login, string password);
    }
}
