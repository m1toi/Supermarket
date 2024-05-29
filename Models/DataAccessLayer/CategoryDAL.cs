using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Supermarket.Models.Entities;

namespace Supermarket.Models.DataAccessLayer
{
    public class CategoryDAL
    {
        public List<Category> GetCategories()
        {
           var connection = DbHelper.Connection;
           List<Category> categories = new List<Category>();
           try
           {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAllCategories", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category();
                    category.CategoryId = reader.GetInt32(0);
                    category.Name = reader.GetString(1);
                    category.IsActive = reader.GetBoolean(2);
                    categories.Add(category);
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
            return categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            var connection = DbHelper.Connection;
            Category category = new Category();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectCategoryById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CategoryId", categoryId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    category.CategoryId = reader.GetInt32(0);
                    category.Name = reader.GetString(1);
                    category.IsActive = reader.GetBoolean(2);
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
            return category;
        }   
        
        public void AddCategory(Category category)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("InsertCategory", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", category.Name);
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
        
        public void ModifyCategory(Category category)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateCategory", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CategoryId", category.CategoryId);
                command.Parameters.AddWithValue("@Name", category.Name);
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

        public void DeleteCategory(Category category)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SoftDeleteCategory", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CategoryId", category.CategoryId);
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
