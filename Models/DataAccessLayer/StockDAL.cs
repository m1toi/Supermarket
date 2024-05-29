using System.Reflection.Metadata.Ecma335;
using Microsoft.Data.SqlClient;
using Supermarket.Models.Entities;

namespace Supermarket.Models.DataAccessLayer
{
    public class StockDAL
    {
        public List<Stock> GetStocks()
        {
            var connection = DbHelper.Connection;
            List<Stock> stocks = new List<Stock>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAllStocks", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Stock stock = new Stock();
                    stock.StockId = reader.GetInt32(0);
                    stock.ProductId = reader.GetInt32(1);
                    stock.Quantity = reader.GetInt32(2);
                    stock.Unit = reader.GetString(3);
                    stock.SupplyDate = reader.GetDateTime(4);
                    stock.ExpiryDate = reader.GetDateTime(5);
                    stock.PurchasePrice = reader.GetDecimal(6);
                    stock.IsActive = reader.GetBoolean(7);
                    stocks.Add(stock);
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
            return stocks;
        }

        public Stock GetStockById(int stockId)
        {
            var connection = DbHelper.Connection;
            Stock stock = new Stock();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectStockById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StockId", stockId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    stock.StockId = reader.GetInt32(0);
                    stock.ProductId = reader.GetInt32(1);
                    stock.Quantity = reader.GetInt32(2);
                    stock.SupplyDate = reader.GetDateTime(3);
                    stock.ExpiryDate = reader.GetDateTime(4);
                    stock.PurchasePrice = reader.GetDecimal(5);
                    stock.IsActive = reader.GetBoolean(6);
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
            return stock;
        }

        public void AddStock(Stock stock)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("InsertStock", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", stock.ProductId);
                command.Parameters.AddWithValue("@Quantity", stock.Quantity);
                command.Parameters.AddWithValue("@Unit", stock.Unit);
                command.Parameters.AddWithValue("@SupplyDate", stock.SupplyDate);
                command.Parameters.AddWithValue("@ExpiryDate", stock.ExpiryDate);
                command.Parameters.AddWithValue("@PurchasePrice", stock.PurchasePrice);
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

        public void ModifyStock(Stock stock)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateStock", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StockId", stock.StockId);
                command.Parameters.AddWithValue("@ProductId", stock.ProductId);
                command.Parameters.AddWithValue("@Quantity", stock.Quantity);
                command.Parameters.AddWithValue("@Unit", stock.Unit);
                command.Parameters.AddWithValue("@SupplyDate",stock.SupplyDate);
                command.Parameters.AddWithValue("@ExpiryDate", stock.ExpiryDate);
                command.Parameters.AddWithValue("@PurchasePrice", stock.PurchasePrice);
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

        public void DeleteStock(Stock stock)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SoftDeleteStock", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StockId", stock.StockId);
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
