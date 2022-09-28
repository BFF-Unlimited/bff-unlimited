using Bff.WebApi.Services.Administrations.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bff.WebApi.Services.Administrations.DataAccess.Mysql
{
    public class AdministrationContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AdministrationContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Leerling>? Leerlingen { get; set; }
        public DbSet<Permission>? Permissions { get; set; }
        public DbSet<Koppeling>? Koppelingen { get; set; }
        public DbSet<Absentie>? Absenties { get; set; }
        public DbSet<Notitie>? Notities { get; set; }
        public DbSet<LaatstBekekenPagina>? LaatstBekekenPaginas { get; set; }
        public DbSet<Groep>? Groepen { get; set; }
        public DbSet<Vestiging>? Vestigingen { get; set; }
    }
}
