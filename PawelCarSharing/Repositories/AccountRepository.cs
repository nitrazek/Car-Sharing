using PawelCarSharing.Repositories.Interfaces;
using PawelCarSharing.Models;
using PawelCarSharing.Data;
using System.Collections.Generic;
using System.Linq;
using BCryptNet = BCrypt.Net.BCrypt;

namespace PawelCarSharing.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Account GetOne(int id)
        {
            return _dbContext.Accounts.SingleOrDefault(x => x.Id == id);
        }

        public List<Account> GetAllByIds(List<int> ids)
        {
            return _dbContext.Accounts.Where(x => ids.Contains(x.Id)).ToList();
        }

        public Account GetAccountByLoginAndPassword(string login, string password)
        {

            Account account = _dbContext.Accounts.SingleOrDefault(x => x.Login == login);
            if(account != null && BCryptNet.Verify(password, account.Password)) return account;
            else return null;
        }

        public void Add(Account account)
        {
            _dbContext.Accounts.Add(account);
        }

        public void Delete(int id)
        {
            var accountToDelete = GetOne(id);
            if (accountToDelete == null)
                return;

            accountToDelete.IsDeleted = true;
        }

        public int GetMaxId()
        {
            return _dbContext.Accounts.Max(x => x.Id);
        }
    }
}
