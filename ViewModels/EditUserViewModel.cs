using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.Entities;
using Supermarket.ViewModels.Commands;
using Supermarket.Views;

namespace Supermarket.ViewModels
{
    public class EditUserViewModel:  BaseViewModel
    {
        private readonly UserBLL _userBLL = new UserBLL();
        private bool _isEditMode;
        public User EditingUser { get; set;}
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";

        public ObservableCollection<string> Roles { get; } = new ObservableCollection<string>()
        {
            "Admin",
            "User"
        };
        public string SelectedRole { get; set; }
        public ICommand SaveUserCommand { get; set; }

        public EditUserViewModel()
        {

            SaveUserCommand = new RelayCommand<object>(SaveUser);
            _isEditMode = false;
        }

        public EditUserViewModel(User user) : this()
        {
            Username = user.Username;
            Password = user.Password;
            SelectedRole = user.IsAdmin ? "Admin" : "User";
            _isEditMode = true;
            EditingUser = user;
        }

        private void SaveUser(object? obj)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) ||string.IsNullOrEmpty(SelectedRole))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            if (_userBLL.UserExists(Username, Password, _isEditMode ? EditingUser.UserId : 0))
            {
                MessageBox.Show("A user with the same username or password already exists.");
                return;
            }
            if (_isEditMode && EditingUser != null)
            {
                // Update the existing user
                EditingUser.Username = Username;
                EditingUser.Password = Password;
                EditingUser.IsAdmin = SelectedRole == "Admin";
                _userBLL.ModifyUser(EditingUser);
                MessageBox.Show("User updated successfully");
            }
            else
            {
                // Add a new user
                User newUser = new User()
                {
                    Username = Username,
                    Password = Password,
                    IsActive = true,
                    IsAdmin = SelectedRole == "Admin"
                };
                _userBLL.AddUser(newUser);
                MessageBox.Show("User added successfully");
            }

            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new AdminPage());
        }

    }
}
