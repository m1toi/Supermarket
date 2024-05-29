using System.Collections.ObjectModel;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.Entities;

namespace Supermarket.Models.BusinessLogicLayer
{
    public class ProductBLL
    {
        private readonly ProductDAL _productDAL;

        public ProductBLL()
        {
            _productDAL = new ProductDAL();
        }

        public ObservableCollection<Product> GetProducts()
        {
            ObservableCollection<Product> products = new ObservableCollection<Product>();
            foreach (var product in _productDAL.GetProducts())
            {
                products.Add(product);
            }
            return products;
        }
        public void AddProduct(Product product)
        {
            _productDAL.AddProduct(product);
        }
        public void ModifyProduct(Product product)
        {
            _productDAL.ModifyProduct(product);
        }
        public void DeleteProduct(Product product)
        {
            _productDAL.DeleteProduct(product);
        }
        public bool ProductExists(string name, string barcode, int productId = 0)
        {
            var products = GetProducts();
            return products.Any(product => (product.Name == name || product.Barcode == barcode) && product.ProductId != productId);
        }
        public Product GetProductById(int id)
        {
            return _productDAL.GetProductById(id);
        }
    }
}
