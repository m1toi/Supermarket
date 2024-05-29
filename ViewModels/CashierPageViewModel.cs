using System.Collections.ObjectModel;
using System.Net.WebSockets;
using System.Printing;
using System.Runtime.ExceptionServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.Entities;
using Supermarket.ViewModels.Commands;

namespace Supermarket.ViewModels
{
    public class CashierPageViewModel : BaseViewModel
    {
        private readonly CategoryBLL _categoryBLL = new CategoryBLL();
        private readonly ProductBLL _productBLL = new ProductBLL();
        private readonly StockBLL _stockBLL = new StockBLL();
        private readonly ProducerBLL _producerBLL = new ProducerBLL();
        private readonly ReceiptBLL _receiptBLL = new ReceiptBLL(); 
        
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Producer> Producers { get; set; }
        public ObservableCollection<Stock> Stocks { get; set; }
        public ObservableCollection <Product> Products { get; set; }
        private ObservableCollection<Product> _productList;
        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
        public ObservableCollection<Product> ProductList
        {
            get => _productList;
            set
            {
                _productList = value;
                OnPropertyChanged(nameof(ProductList));
            }
        }
        private ObservableCollection<ProductPrice> _cartList;
        public ObservableCollection<ProductPrice> CartList
        {
            get => _cartList;
            set
            {
                _cartList = value;
                OnPropertyChanged(nameof(CartList));
            }
        }
        public ObservableCollection<string> Items { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand IssueReceiptCommand { get; set; }
        private string _selectedItem;
        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public CashierPageViewModel()
        {
            Categories = _categoryBLL.GetCategories();
            Producers = _producerBLL.GetProducers();
            Stocks = _stockBLL.GetStocks();
            Products = _productBLL.GetProducts();

            CartList = new ObservableCollection<ProductPrice>();
            Items = new ObservableCollection<string>();
            foreach (var product in Products)
            {
                Items.Add(product.Name);
                Items.Add(product.Barcode);
            }
            foreach(var stock in Stocks)
            {
                Items.Add(stock.ExpiryDate.ToString());
            }
            foreach(var Producer in Producers)
            {
                Items.Add(Producer.Name);
            }
            foreach(var Category in Categories)
            {
                Items.Add(Category.Name);
            }

            SaveCommand = new RelayCommand<object>(Save);
            AddCommand = new RelayCommand<object>(Add);
            IssueReceiptCommand = new RelayCommand<object>(IssueReceipt);
                
        }

        private void IssueReceipt(object obj)
        {
            _receiptBLL.AddReceipt(CartList);
            CartList.Clear();
            MessageBox.Show("Receipt issued successfully");
        }

        private void Add(object obj)
        {
            if (SelectedProduct == null)
            {
                MessageBox.Show("Please select a product to add in the cart");
                return;
            }
            else
            {
                ProductPrice productPrice = new ProductPrice();
                productPrice.Product = SelectedProduct;
                Stock stock = Stocks.FirstOrDefault(stock => stock.ProductId == SelectedProduct.ProductId);
                if (stock == null)
                {
                    MessageBox.Show("Product is out of stock");
                    return;
                }
                productPrice.Price = stock.SellingPrice;
                CartList.Add(productPrice);
                stock.Quantity--;
                _stockBLL.ModifyStock(stock);
            }

        }

        private void Save(object obj)
        {
            if (SelectedItem == null)
            {
                return;
            }
            ProductList = new ObservableCollection<Product>();
            foreach (var product in Products)
            {
                if (product.Name == SelectedItem || product.Barcode == SelectedItem)
                {
                    ProductList.Add(product);
                }
            }
            foreach (var stock in Stocks)
            {
                if (stock.ExpiryDate.ToString() == SelectedItem)
                {
                    ProductList.Add(_productBLL.GetProductById(stock.ProductId));
                }
            }
            foreach (var producer in Producers)
            {
                if (producer.Name == SelectedItem)
                {
                    foreach (var product in Products)
                    {
                        if (product.ProducerId == producer.ProducerId)
                        {
                            ProductList.Add(product);
                        }
                    }
                }
            }
            foreach (var category in Categories)
            {
                if (category.Name == SelectedItem)
                {
                    foreach (var product in Products)
                    {
                        if (product.CategoryId == category.CategoryId)
                        {
                            ProductList.Add(product);
                        }
                    }
                }
            }

        }
    }
}
