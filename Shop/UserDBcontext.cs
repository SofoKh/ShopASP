using Microsoft.EntityFrameworkCore;

namespace Shop
{
    public partial class UserDBContext : DbContext
    {
        public UserDBContext()
        {
        }

        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }
        
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Database=ShopAPI;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("Server=(local);Database=ShopAPI;Trusted_Connection=True;", options => options.EnableRetryOnFailure().UseSslStream(ssl => ssl.AcceptAnyServerCertificate(true)));
        }*/
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("Server = (local); Database = ShopAPI; Trusted_Connection = True; ");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}