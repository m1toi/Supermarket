using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.Identity.Client;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.Entities;

namespace Supermarket.Models.BusinessLogicLayer
{
    public class UserBLL
    {
        private readonly UserDAL _userDAL;

        public UserBLL()
        {
            _userDAL = new UserDAL();
        }

        public User? AuthenticateUser(string username, string password)
        {
            return _userDAL.AuthenticateUser(username, password);
        }   
        
        public ObservableCollection<User> GetUsers()
        {
            ObservableCollection<User> users = new ObservableCollection<User>();
            foreach (var user in _userDAL.GetUser())
            {
                users.Add(user);
            }
            return users;
        }
        public void AddUser(User user)
        {
            //User checkUser = _userDAL.AuthenticateUser(user.Username, user.Password);
            //if (checkUser!=null)
            //{
            //    MessageBox.Show("User already exists");
            //    return;
            //}
            _userDAL.AddUser(user);
        }
        public void ModifyUser(User user)
        {
            _userDAL.ModifyUser(user);
        }
        public void DeleteUser(User user)
        {
            _userDAL.DeleteUser(user);
        }

        public bool UserExists(string username, string password, int userId = 0)
        {
            var users = GetUsers();
            return users.Any(user => (user.Username == username || user.Password == password) && user.UserId != userId);
        }

    }
}
