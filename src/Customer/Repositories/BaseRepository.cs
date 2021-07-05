using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;
namespace CustomerLib.Repositories
{
    public abstract class BaseRepository
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(
            "Server = ALFA;" +
             "Database=CustomerLib_Bezslyozniy;" +
             "Trusted_Connection=True;");
        }
    }
}
