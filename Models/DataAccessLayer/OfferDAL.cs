using Microsoft.Data.SqlClient;
using Supermarket.Models.Entities;

namespace Supermarket.Models.DataAccessLayer
{
    public class OfferDAL
    {
        public List<Offer> GetOffers()
        {
            var connection = DbHelper.Connection;
            List<Offer> offers = new List<Offer>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectAllOffers", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Offer offer = new Offer();
                    offer.OfferId = reader.GetInt32(0);
                    offer.ProductId = reader.GetInt32(1);
                    offer.DiscountPercentage = reader.GetDecimal(2);
                    offer.StartDate = reader.GetDateTime(3);
                    offer.EndDate = reader.GetDateTime(4);
                    offer.Reason = reader.GetString(5);
                    offer.IsActive = reader.GetBoolean(6);
                    offers.Add(offer);
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
            return offers;
        }

        public Offer GetOfferById(int offerId)
        {
            var connection = DbHelper.Connection;
            Offer offer = new Offer();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectOfferById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OfferId", offerId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    offer.OfferId = reader.GetInt32(0);
                    offer.ProductId = reader.GetInt32(1);
                    offer.DiscountPercentage = reader.GetDecimal(2);
                    offer.StartDate = reader.GetDateTime(3);
                    offer.EndDate = reader.GetDateTime(4);
                    offer.Reason = reader.GetString(5);
                    offer.IsActive = reader.GetBoolean(6);
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
            return offer;
        }   

        public void AddOffer(Offer offer)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("InsertOffer", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", offer.ProductId);
                command.Parameters.AddWithValue("@DiscountPercentage", offer.DiscountPercentage);
                command.Parameters.AddWithValue("@StartDate", offer.StartDate);
                command.Parameters.AddWithValue("@EndDate", offer.EndDate);
                command.Parameters.AddWithValue("@Reason", offer.Reason);
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
        public void ModifyOffer(Offer offer)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateOffer", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OfferId", offer.OfferId);
                command.Parameters.AddWithValue("@ProductId", offer.ProductId);
                command.Parameters.AddWithValue("@DiscountPercentage", offer.DiscountPercentage);
                command.Parameters.AddWithValue("@StartDate", offer.StartDate);
                command.Parameters.AddWithValue("@EndDate", offer.EndDate);
                command.Parameters.AddWithValue("@Reason", offer.Reason);
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

        public void DeleteOffer(int offerId)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SoftDeleteOffer", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OfferId", offerId);
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
