using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Identity.Client;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.Context;
using Supermarket.Models.Entities;
using Supermarket.ViewModels.Commands;
using Supermarket.Views;

namespace Supermarket.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly UserBLL _userBLL;
        
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public ICommand LoginCommand { get; private set; }
        public LoginViewModel()
        {
            _userBLL = new UserBLL();
            LoginCommand = new RelayCommand<object>(Login);
        }

        private void Login(object? obj)
        {
            if(Username== "")
            {
                return;
            }

            var currentPage = obj as Page;
            if (currentPage is not Page)
            {
                return;
            }

            var passwordBox = currentPage.FindName("PasswordBox") as PasswordBox;
            if (passwordBox is not PasswordBox)
            {
                return;
            }

            User? user = _userBLL.AuthenticateUser(Username, passwordBox.Password);

            if(user != null)
            {
                if (user.IsAdmin == true)
                {
                   currentPage.NavigationService?.Navigate(new AdminPage());
                }
                else
                {
                    currentPage.NavigationService?.Navigate(new CashierPage());
                }
            }

        }
       
    }
}
