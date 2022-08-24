using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;

namespace DAL.DbContexts
{
    public class DBContext:DbContext
    {
        ////private IConfiguration _configuration;

        ////public DBContext(IConfiguration configuration)
        ////{
        ////    _configuration = configuration;
        ////}

        public DbSet<User> Users { get; set; }
        public DbSet<UserPassword> UserPasswords { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Server=. ;Database=DBApartment;Trusted_Connection=True"));

            //var connectionString = _configuration.GetConnectionString("Dbcom");
            //base.OnConfiguring(optionsBuilder.UseSqlServer(connectionString));
        }
    }
}
