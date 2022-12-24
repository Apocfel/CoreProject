using CoreProject.Data.Interfaces;
using CoreProject.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoreProject.Data.Repository
{
    public class UserRepository : IUser
    {
        private readonly AppDbContent appDbContent;
        public UserRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public IEnumerable<User> users => appDbContent.User;

        public bool isLogged(string username, string password)
        {
            if (GetUser(username, password) != null)
                return true;
            else
                return false;
        }
        public bool isAdmin(string username, string password)
        {
            return appDbContent.User.FirstOrDefault(u => u.Username == username && u.Password == password && u.Role == "Admin") != null;
        }

        public User Login(string username, string password)
        {
            return appDbContent.User.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public bool Logout(string username, string password)
        {
            throw new System.NotImplementedException();
        }
        public User GetUser(string username, string password)
        {
            return appDbContent.User.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
        public void Register(User user)
        {
            if (user.Role == null)
                user.Role = "Standart";
            appDbContent.User.Add(user);
            appDbContent.SaveChanges();
        }

        public bool isExisting(string username, string email)
        {
            return appDbContent.User.Where(u => u.Username == username || u.Email == email).Any();
        }
    }
}
