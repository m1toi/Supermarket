using Microsoft.Data.SqlClient;
using Supermarket.Models.Entities;

namespace Supermarket.Models.DataAccessLayer
{
    public class ProducerDAL
    {
        public List<Producer> GetProducers()
        {
            var connection = DbHelper.Connection;
            List<Producer> producers = new List<Producer>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAllProducers", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Producer producer = new Producer();
                    producer.ProducerId = reader.GetInt32(0);
                    producer.Name = reader.GetString(1);
                    producer.OriginCountry = reader.GetString(2);
                    producer.IsActive = reader.GetBoolean(3);
                    producers.Add(producer);
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
            return producers;
        }

        public Producer GetProducerById(int producerId)
        {
            var connection = DbHelper.Connection;
            Producer producer = new Producer();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectProducerById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProducerId", producerId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    producer.ProducerId = reader.GetInt32(0);
                    producer.Name = reader.GetString(1);
                    producer.IsActive = reader.GetBoolean(2);
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
            return producer;
        }
        public void AddProducer(Producer producer)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("InsertProducer", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", producer.Name);
                command.Parameters.AddWithValue("@OriginCountry", producer.OriginCountry);
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

        public void ModifyProducer(Producer producer)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateProducer", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProducerId", producer.ProducerId);
                command.Parameters.AddWithValue("@Name", producer.Name);
                command.Parameters.AddWithValue("@OriginCountry", producer.OriginCountry);
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
        public void DeleteProducer(Producer producer)

        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SoftDeleteProducer", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProducerId", producer.ProducerId);
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
