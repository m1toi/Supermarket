using Supermarket.Views;

namespace Supermarket.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private Object? _currentPage;
        public Object? CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        public MainViewModel()
        {
            var loginPage = new LoginPage();
            CurrentPage = loginPage;
        }

    }
}
