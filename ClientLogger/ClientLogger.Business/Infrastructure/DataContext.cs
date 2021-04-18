using ClientLogger.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientLogger.Business.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Client> Client { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<ClientFullInfo> ClientFullInfo { get; set; }
    }
}
