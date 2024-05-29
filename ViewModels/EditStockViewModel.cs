using System.Collections.ObjectModel;
using System.Security.Policy;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using Microsoft.Identity.Client;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.Entities;
using Supermarket.ViewModels.Commands;
using Supermarket.Views;

namespace Supermarket.ViewModels
{
    public class EditStockViewModel : BaseViewModel
    {
        private readonly StockBLL _stockBLL = new StockBLL();
        private readonly ProductBLL _productBLL = new ProductBLL();

        private bool _isEditMode;

        public Stock EditingStock { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime SupplyDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }
        public ICommand SaveStockCommand { get; set; }

        public EditStockViewModel()
        {
            Products = _productBLL.GetProducts();
            SaveStockCommand = new RelayCommand<object>(SaveStock);
            _isEditMode = false;
        }

        public EditStockViewModel(Stock stock)
        {
            Quantity = stock.Quantity;
            Unit = stock.Unit;
            SupplyDate = stock.SupplyDate;
            ExpiryDate = stock.ExpiryDate;
            PurchasePrice = stock.PurchasePrice;
            SellingPrice = PurchasePrice * (decimal)1.2;
           // SelectedStock = Products.FirstOrDefault(product => product.ProductId == stock.ProductId);
            _isEditMode = true;
            EditingStock = stock;
        }

        private void SaveStock(object obj)
        {
            if(string.IsNullOrEmpty(Unit) || PurchasePrice == 0 || SelectedProduct == null || Quantity==0)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
                Stock stock = new Stock
                {
                    Quantity = Quantity,
                    Unit = Unit,
                    SupplyDate = SupplyDate,
                    ExpiryDate = ExpiryDate,
                    PurchasePrice = PurchasePrice,
                    ProductId = SelectedProduct.ProductId
                };
                _stockBLL.AddStock(stock);
                MessageBox.Show("Stock added successfully.");
           
            var currentPage = obj as Page;
            currentPage.NavigationService?.Navigate(new AdminPage());
        }


    }
}
