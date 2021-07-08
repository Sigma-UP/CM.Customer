using System.Data.Entity;
using CustomerLib.Entities;
namespace CustomerLib.Data.EF
{
    public class CustomerDataContext : DbContext
    {
        public CustomerDataContext() : base(
            "Server=ALFA;" +
            "Database=CustomerLib_Bezslyozniy;" +
            "Trusted_Connection=True;"
            )
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
