using Microsoft.Data.SqlClient;
using Supermarket.Models.Entities;

namespace Supermarket.Models.DataAccessLayer
{
    public class ReceiptDAL
    {
        public List<Receipt> GetReceipts()
        {
            var connection = DbHelper.Connection;
            List<Receipt> receipts = new List<Receipt>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAllReceipts", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Receipt receipt = new Receipt();
                    receipt.ReceiptId = reader.GetInt32(0);
                    receipt.UserId = reader.GetInt32(1);
                    receipt.IssueDate = reader.GetDateTime(2);
                    receipt.AmountReceived = reader.GetDecimal(3);
                    receipt.IsActive = reader.GetBoolean(4);
                    receipts.Add(receipt);
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
            return receipts;

        }

        public Receipt GetReceiptById(int receiptId)
        {
            var connection = DbHelper.Connection;
            Receipt receipt = new Receipt();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectReceiptById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ReceiptId", receiptId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    receipt.ReceiptId = reader.GetInt32(0);
                    receipt.IssueDate = reader.GetDateTime(1);
                    receipt.AmountReceived = reader.GetDecimal(2);
                    receipt.IsActive = reader.GetBoolean(3);
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
            return receipt;
        }
        public void AddReceipt(Receipt receipt)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("InsertReceipt", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", receipt.UserId);
                command.Parameters.AddWithValue("@IssueDate", receipt.IssueDate);
                command.Parameters.AddWithValue("@AmountReceived", receipt.AmountReceived);
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

        public void ModifyReceipt(Receipt receipt)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateReceipt", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ReceiptId", receipt.ReceiptId);
                command.Parameters.AddWithValue("@IssueDate", receipt.IssueDate);
                command.Parameters.AddWithValue("@AmountReceived", receipt.AmountReceived);
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

        public void DeleteReceipt(int receiptId)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DeleteReceipt", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ReceiptId", receiptId);
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
        
        public int GetReceiptIdByIssueDate(DateTime issueDate)
        {
            var connection = DbHelper.Connection;
            int receiptId = 0;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetReceiptIdByIssueDate", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IssueDate", issueDate);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    receiptId = reader.GetInt32(0);
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
            return receiptId;
        }
    }
}

