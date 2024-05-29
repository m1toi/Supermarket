using Microsoft.Data.SqlClient;
using Supermarket.Models.Entities;

namespace Supermarket.Models.DataAccessLayer
{
    public class UserDAL
    {
        public List<User> GetUser()
        {
            var connection = DbHelper.Connection;
            List<User> users = new List<User>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAllUsers", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.UserId = reader.GetInt32(0);
                    user.Username = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.IsAdmin = reader.GetBoolean(3);
                    user.IsActive = reader.GetBoolean(4);
                    users.Add(user);
                }
                connection.Close();

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

            return users;

        }
        public User GetUserById(int UserId)
        {
            var connection = DbHelper.Connection;
            User user = new User();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectUserById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", UserId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user.UserId = reader.GetInt32(0);
                    user.Username = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.IsAdmin = reader.GetBoolean(3);
                    user.IsActive = reader.GetBoolean(4);
                }
                connection.Close();

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
            return user;
        }
        public void AddUser(User user)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("InsertUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
                command.ExecuteNonQuery();
                connection.Close();
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

        public void ModifyUser(User user)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", user.UserId);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin); 
                command.ExecuteNonQuery();
                connection.Close();
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

        public void DeleteUser(User user)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SoftDeleteUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", user.UserId);
                command.ExecuteNonQuery();
                connection.Close();
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
        public User? AuthenticateUser(string username, string password)
        {
            var connection = DbHelper.Connection;
            User user = new User();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AuthenticateUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user.UserId = reader.GetInt32(0);
                    user.Username = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.IsAdmin = reader.GetBoolean(3);
                    user.IsActive = reader.GetBoolean(4);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return user;
        }

    }
}
