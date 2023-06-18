using PawelCarSharing.Repositories.Interfaces;
using PawelCarSharing.Models;
using PawelCarSharing.Enums;
using PawelCarSharing.Data;
using System.Collections.Generic;
using System.Linq;

namespace PawelCarSharing.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User user)
        {
            _dbContext.Users.Add(user);
        }

        public User GetOne(int id)
        {
            return _dbContext.Users.SingleOrDefault(x => x.Id == id);
        }

        public List<User> GetAllByIds(List<int> ids)
        {
            return _dbContext.Users.Where(x => ids.Contains(x.Id)).ToList();
        }

        public void Delete(int id)
        {
            var userToDelete = GetOne(id);
            if (userToDelete == null)
                return;

            userToDelete.IsDeleted = true;
        }
    }
}
