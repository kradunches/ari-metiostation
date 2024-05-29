using Microsoft.EntityFrameworkCore;
using ServerMVC.Infrastructure;
using ServerMVC.Infrastructure.Enum;

namespace ServerMVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { Database.EnsureCreated(); }
        public DbSet<meteo1> meteo1 { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<agro_moist> agro_moist { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("User").HasKey(x => x.Id);

                builder.HasData(new User[]
                {
                    new User()
                    {
                        Id = 1,
                        Name = "meteo",
                        Password = HashPassword.HashPassowrd("meteo"),
                        Role = Role.Admin
                    }
                });
                builder.Property(x => x.Id).ValueGeneratedOnAdd();
                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            });
        }
    }
}
