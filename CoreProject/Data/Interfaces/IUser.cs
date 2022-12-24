using CoreProject.Data.Models;
using System.Collections.Generic;

namespace CoreProject.Data.Interfaces
{
    public interface IUser
    {
        IEnumerable<User> users { get; }
        bool isLogged(string username, string password);
        bool isAdmin(string username, string password);
        User Login(string username, string password);
        bool Logout(string username, string password);
        bool isExisting(string username, string email);
        void Register(User user);
    }
}
