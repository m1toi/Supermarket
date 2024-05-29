using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Supermarket.Models.DataAccessLayer
{
    public class DbHelper
    {
       public static SqlConnection Connection = new SqlConnection("Server=mitoi;Database=Supermarket;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}