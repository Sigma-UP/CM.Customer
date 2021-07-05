using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
namespace CustomerLib.Data.Repositories
{
    [ExcludeFromCodeCoverage]
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
