using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Supermarket.Models.Entities;

namespace Supermarket.Models.DataAccessLayer
{
    public class ReceiptProductsDAL
    {
        public List<ReceiptProducts> GetReceiptProducts()
        {
            var connection = DbHelper.Connection;
            List<ReceiptProducts> receiptProducts = new List<ReceiptProducts>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAllReceiptProducts", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ReceiptProducts receiptProduct = new ReceiptProducts();
                    receiptProduct.ReceiptId = reader.GetInt32(0);
                    receiptProduct.ProductId = reader.GetInt32(1);
                    receiptProduct.Quantity = reader.GetInt32(2);
                    receiptProduct.Unit = reader.GetString(3);
                    receiptProduct.SubtotalPrice = reader.GetDecimal(4);
                    receiptProduct.IsActive = reader.GetBoolean(5);
                    receiptProducts.Add(receiptProduct);
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
            return receiptProducts;
        }
        public ReceiptProducts GetReceiptProductById(int receiptId, int productId)
        {
            var connection = DbHelper.Connection;
            ReceiptProducts receiptProduct = new ReceiptProducts();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectReceiptProductById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ReceiptId", receiptId);
                command.Parameters.AddWithValue("@ProductId", productId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    receiptProduct.ReceiptId = reader.GetInt32(0);
                    receiptProduct.ProductId = reader.GetInt32(1);
                    receiptProduct.Quantity = reader.GetInt32(2);
                    receiptProduct.Unit = reader.GetString(3);
                    receiptProduct.SubtotalPrice = reader.GetDecimal(4);
                    receiptProduct.IsActive = reader.GetBoolean(5);
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
            return receiptProduct;
        }

        public void AddReceiptProduct(ReceiptProducts receiptProduct)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("InsertReceiptProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ReceiptId", receiptProduct.ReceiptId);
                command.Parameters.AddWithValue("@ProductId", receiptProduct.ProductId);
                command.Parameters.AddWithValue("@Quantity", receiptProduct.Quantity);
                command.Parameters.AddWithValue("@Unit", receiptProduct.Unit);
                command.Parameters.AddWithValue("@SubtotalPrice", receiptProduct.SubtotalPrice);
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
        public void ModifyReceiptProduct(ReceiptProducts receiptProduct)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateReceiptProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ReceiptId", receiptProduct.ReceiptId);
                command.Parameters.AddWithValue("@ProductId", receiptProduct.ProductId);
                command.Parameters.AddWithValue("@Quantity", receiptProduct.Quantity);
                command.Parameters.AddWithValue("@Unit", receiptProduct.Unit);
                command.Parameters.AddWithValue("@SubtotalPrice", receiptProduct.SubtotalPrice);
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

        public void DeleteReceiptProduct(int receiptId, int productId)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SoftDeleteReceiptProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ReceiptId", receiptId);
                command.Parameters.AddWithValue("@ProductId", productId);
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
