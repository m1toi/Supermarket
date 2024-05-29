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
    public class EditProductViewModel : BaseViewModel
    {
        private readonly ProductBLL _productBLL = new ProductBLL();
        private readonly CategoryBLL _categoryBLL = new CategoryBLL();
        private readonly ProducerBLL _producerBLL = new ProducerBLL();

        private bool _isEditMode;
        public Product EditingProduct { get; set; }
        public string Name { get; set; } = "";
        public string Barcode { get; set; } = "";
        public ObservableCollection<Category> Categories { get; set; }
        public Category SelectedCategory { get; set; }
        public ObservableCollection<Producer> Producers { get; set; }
        public Producer SelectedProducer { get; set; }

        public ICommand SaveProductCommand { get; set; }
        public EditProductViewModel()
        {
            Categories = _categoryBLL.GetCategories();
            Producers = _producerBLL.GetProducers();

            SaveProductCommand = new RelayCommand<object>(SaveProduct);

            _isEditMode = false;
        }
        public EditProductViewModel(Product product) : this()
        {
            Name = product.Name;
            Barcode = product.Barcode;
            SelectedCategory = Categories.FirstOrDefault(category => category.CategoryId == product.CategoryId);
            SelectedProducer = Producers.FirstOrDefault(producer => producer.ProducerId == product.ProducerId);
            _isEditMode = true;
            EditingProduct = product;

        }

        private void SaveProduct(object? obj)
        {
            if(string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Barcode) || SelectedCategory == null || SelectedProducer == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            if(_productBLL.ProductExists(Name, Barcode, _isEditMode ? EditingProduct.ProductId : 0))
            {
                MessageBox.Show("A product with the same name or barcode already exists.");
                return;
            }
            if(_isEditMode && EditingProduct != null)
            {
                EditingProduct.Name = Name;
                EditingProduct.Barcode = Barcode;
                EditingProduct.CategoryId = SelectedCategory.CategoryId;
                EditingProduct.ProducerId = SelectedProducer.ProducerId;
                _productBLL.ModifyProduct(EditingProduct);
                MessageBox.Show("Product updated successfully");
            }
            else
            {
                Product product = new Product()
                {
                    Name = Name,
                    Barcode = Barcode,
                    CategoryId = SelectedCategory.CategoryId,
                    ProducerId = SelectedProducer.ProducerId
                };
                _productBLL.AddProduct(product);
                MessageBox.Show("Product added successfully");
            }
            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new AdminPage());
           
        }


    }
}
