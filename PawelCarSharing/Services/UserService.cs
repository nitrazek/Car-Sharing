using System.Collections.Generic;
using PawelCarSharing.Models;

namespace PawelCarSharing.Services
{
    public class UserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = new List<User>();
        }

        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        public User GetUserById(int id)
        {
            return _users.Find(user => user.Id == id);
        }

        public User CreateUser(User user)
        {
            user.Id = GenerateUserId();
            _users.Add(user);
            return user;
        }

        public User UpdateUser(int id, User user)
        {
            var existingUser = _users.Find(u => u.Id == id);
            if (existingUser != null)
            {
                existingUser.Login = user.Login;
                existingUser.Password = user.Password;
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                // Update other user properties if needed
                return existingUser;
            }
            return null;
        }

        public User DeleteUser(int id)
        {
            var user = _users.Find(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
                return user;
            }
            return null;
        }

        private int GenerateUserId()
        {
            // Generate a unique user ID based on your logic (e.g., auto-increment, GUID, etc.)
            // This is just a sample implementation
            return _users.Count + 1;
        }
    }
}
