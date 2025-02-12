using System.Collections.Generic;
using Project1_Edited.Entities;

namespace Project1_Edited.Intefaces
{
    public interface IUserServices
    {
        bool Registration(string username, string password);
        bool Login(string username, string password);
        void Logout();
        User GetUserByUsername(string username);
        List<User> GetUsers();
        bool DeleteUser(string username, string password);
    }
}