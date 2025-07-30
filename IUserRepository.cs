using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using UserManagement.Data;
using UserManagement.Models;

namespace UserManagement.Repositories
{

    
    public interface IUserRepository
    {

        bool Register (User user);
        User Login (string username, string password);
        IEnumerable<User> AllUsers();
        void DeleteUser(User user);
        void UpdateUser (User user);
        User GetUsersId(int id);
    }

   
}
