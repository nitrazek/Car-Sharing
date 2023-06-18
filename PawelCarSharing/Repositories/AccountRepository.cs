using PawelCarSharing.Repositories.Interfaces;
using PawelCarSharing.Models;
using PawelCarSharing.Data;
using System.Collections.Generic;
using System.Linq;

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
