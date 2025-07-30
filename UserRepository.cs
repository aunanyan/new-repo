using UserManagement.Data;
using UserManagement.Models;

namespace UserManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
       
            private readonly DataContext _dataContext;

            public UserRepository(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public IEnumerable<User> AllUsers()
            {
                return _dataContext.User.ToList();
            }

            public void DeleteUser(User user)
            {
                var deluser = _dataContext.User.FirstOrDefault(x => x.Id == user.Id);
                if (deluser != null)
                {
                    _dataContext.User.Remove(deluser);
                }
                _dataContext.SaveChanges();
            }

            public User GetUsersId(int id)
            {
                return _dataContext.User.FirstOrDefault(x => x.Id == id);
            }

            public User Login(string username, string password)
            {
                var user = _dataContext.User.FirstOrDefault(x => x.UserName == username);

                if (user.Password != password)
                {
                    throw new Exception("Wrong password or username");

                }
                return user;
            }

            public bool Register(User user)
            {
                var reguser = _dataContext.User.FirstOrDefault(x => x.Email == user.Email);
                if (reguser != null)
                {
                    throw new Exception("Email already registered");
                }

                _dataContext.User.Add(user);
                _dataContext.SaveChanges();
                return true;
            }

            public void UpdateUser(User user)
            {
                var upuser = _dataContext.User.FirstOrDefault(x => x.Id == user.Id);
                if (upuser != null)
                {
                    upuser.Name = user.Name;
                    upuser.LastName = user.LastName;
                    upuser.Email = user.Email;
                    upuser.BirthData = user.BirthData;
                    upuser.UserName = user.UserName;
                    upuser.Password = user.Password;

                   _dataContext.SaveChanges();
            }
                
            
        }
    }
}
