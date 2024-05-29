using Microsoft.Data.SqlClient;
using Supermarket.Models.Entities;

namespace Supermarket.Models.DataAccessLayer
{
    public class ProductDAL
    {
        public List<Product> GetProducts()
        {
            var connection = DbHelper.Connection;
            List<Product> products = new List<Product>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAllProducts", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductId = reader.GetInt32(0);
                    product.Name = reader.GetString(1);
                    product.Barcode = reader.GetString(2);
                    product.CategoryId = reader.GetInt32(3);
                    product.ProducerId = reader.GetInt32(4);
                    product.IsActive = reader.GetBoolean(5);
                    products.Add(product);
                }

            }
            catch
            (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return products;
        }

        public Product GetProductById(int productId)
        {
            var connection = DbHelper.Connection;
            Product product = new Product();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectProductById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", productId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product.ProductId = reader.GetInt32(0);
                    product.Name = reader.GetString(1);
                    product.Barcode = reader.GetString(2);
                    product.CategoryId = reader.GetInt32(3);
                    product.ProducerId = reader.GetInt32(4);
                    product.IsActive = reader.GetBoolean(5);

                }

            }
            catch
            (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return product;
        }
        public void AddProduct(Product product)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("InsertProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Barcode", product.Barcode);
                command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                command.Parameters.AddWithValue("@ProducerId", product.ProducerId);
                command.ExecuteNonQuery();
            }
            catch
            (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        public void ModifyProduct(Product product)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", product.ProductId);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Barcode", product.Barcode);
                command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                command.Parameters.AddWithValue("@ProducerId", product.ProducerId);
                command.ExecuteNonQuery();
            }
            catch
            (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        public void DeleteProduct(Product product)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SoftDeleteProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", product.ProductId);
                command.ExecuteNonQuery();
            }
            catch
            (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }

}
