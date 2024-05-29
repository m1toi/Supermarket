using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Windows.Controls;
using System.Windows.Input;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.Entities;
using Supermarket.ViewModels.Commands;
using Supermarket.Views;

namespace Supermarket.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {

        private readonly UserBLL _userBLL = new UserBLL();
        private readonly ProductBLL _productBLL = new ProductBLL();
        private readonly CategoryBLL _categoryBLL = new CategoryBLL();
        private readonly ProducerBLL _producerBLL  = new ProducerBLL();
        private readonly StockBLL _stockBLL = new StockBLL();
        private readonly ReceiptBLL _receiptBLL = new ReceiptBLL();
       
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Receipt> Receipts { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Producer> Producers { get; set; }
        public ObservableCollection<Offer> Offers { get; set; }
        public ObservableCollection<Stock> Stocks { get; set; }

        public User SelectedUser { get; set; }
        public Category SelectedCategory { get; set; }
        public Product SelectedProduct { get; set; }
        public Producer SelectedProducer { get; set; }
        public Stock SelectedStock { get; set; }
        public ICommand AddUserCommand { get; set; }
        public ICommand EditUserCommand { get; set; }
        public ICommand DeleteUserCommand { get; set; }

        public ICommand AddProductCommand { get; set; }
        public ICommand EditProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }

        public ICommand AddCategoryCommand { get; set; }
        public ICommand EditCategoryCommand { get; set; }
        public ICommand DeleteCategoryCommand { get; set; }

        public ICommand AddProducerCommand { get; set; }
        public ICommand EditProducerCommand { get; set; }
        public ICommand DeleteProducerCommand { get; set; }

        public ICommand AddStockCommand { get; set; }
        public ICommand EditStockCommand { get; set; }
        public ICommand DeleteStockCommand { get; set; }

        public AdminViewModel()
        {

            Users = new ObservableCollection<User>(_userBLL.GetUsers());
            Products = _productBLL.GetProducts();
            Categories = _categoryBLL.GetCategories();
            Producers = _producerBLL.GetProducers();
            Stocks = _stockBLL.GetStocks();
            Receipts = _receiptBLL.GetReceipts();

            AddUserCommand = new RelayCommand<object>(AddUser);
            EditUserCommand = new RelayCommand<object>(EditUser);
            DeleteUserCommand = new RelayCommand<object>(DeleteUser);

            AddCategoryCommand = new RelayCommand<object>(AddCategory);
            EditCategoryCommand = new RelayCommand<object>(EditCategory);
            DeleteCategoryCommand = new RelayCommand<object>(DeleteCategory);

            AddProductCommand = new RelayCommand<object>(AddProduct);
            EditProductCommand = new RelayCommand<object>(EditProduct);
            DeleteProductCommand = new RelayCommand<object>(DeleteProduct);

            AddProducerCommand = new RelayCommand<object>(AddProducer);
            EditProducerCommand = new RelayCommand<object>(EditProducer);
            DeleteProducerCommand = new RelayCommand<object>(DeleteProducer);

            AddStockCommand = new RelayCommand<object>(AddStock);
            EditStockCommand = new RelayCommand<object>(EditStock);
            DeleteStockCommand = new RelayCommand<object>(DeleteStock);
        }

        private void AddUser(object? obj)
        {
            if(obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;
                
            }

            currentPage.NavigationService?.Navigate(new EditUserPage());

        }

        private void EditUser(object? obj)
        {
            if (SelectedUser == null)
            {
                return;
            }
            User user = SelectedUser;
            if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }

            currentPage.NavigationService?.Navigate(new EditUserPage(user));
        }
        private void DeleteUser(object? obj)
        {
           if(SelectedUser == null)
            {
                return;
            }
            User user = SelectedUser;
            _userBLL.DeleteUser(user);
            Users.Remove(user);
        }

        private void AddCategory(object? obj)
        {
            if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }

            currentPage.NavigationService?.Navigate(new EditCategoryPage());
        }
        private void EditCategory(object? obj)
        {
            if (SelectedCategory == null)
            {
                return;
            }
            Category category = SelectedCategory;
            if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }

            currentPage.NavigationService?.Navigate(new EditCategoryPage(category));
        }
        private void DeleteCategory(object? obj)
        {
            if (SelectedCategory == null)
            {
                return;
            }
            Category category = SelectedCategory;
            _categoryBLL.DeleteCategory(category);
            Categories.Remove(category);

        }
        private void AddProduct(object? obj)
        {
            if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }

            currentPage.NavigationService?.Navigate(new EditProductPage());
        }
        
        private void EditProduct(object? obj)
        {
            if (SelectedProduct == null)
            {
                return;
            }
            Product product = SelectedProduct;
            if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }

            currentPage.NavigationService?.Navigate(new EditProductPage(product));
        }
        private void DeleteProduct(object? obj)
        {
            if (SelectedProduct == null)
            {
                return;
            }
            Product product = SelectedProduct;
            _productBLL.DeleteProduct(product);
            Products.Remove(product);

        }   
        private void AddProducer(object? obj)
        {
            if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }

            currentPage.NavigationService?.Navigate(new EditProducerPage());
        }
        private void EditProducer(object? obj)
        {
            if (SelectedProducer == null)
            {
                return;
            }
            Producer producer = SelectedProducer;
            if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }

            currentPage.NavigationService?.Navigate(new EditProducerPage(producer));
        }
        private void DeleteProducer(object? obj)
        {
            if (SelectedProducer == null)
            {
                return;
            }
            Producer producer = SelectedProducer;
            _producerBLL.DeleteProducer(producer);
            Producers.Remove(producer);

        }
        private void AddStock(object? obj)
        {
            if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }

            currentPage.NavigationService?.Navigate(new EditStockPage());
        }
        private void EditStock(object? obj)
        {
            if (SelectedStock == null)
            {
                return;
            }
            Stock stock = SelectedStock;
            if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }

            currentPage.NavigationService?.Navigate(new EditStockPage(stock));
        }
        private void DeleteStock(object? obj)
        {
            if (SelectedStock == null)
            {
                return;
            }
            Stock stock = SelectedStock;
            _stockBLL.DeleteStock(stock);
            Stocks.Remove(stock);
        }
    }
}
