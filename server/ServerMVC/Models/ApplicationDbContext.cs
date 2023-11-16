using Microsoft.EntityFrameworkCore;
using ServerMVC.Infrastructure;
using ServerMVC.Infrastructure.Enum;

namespace ServerMVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { Database.EnsureCreated(); }
        public DbSet<Measurement> Measurement { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Moistmeter> Moistmeter { get; set; }
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
                        Name = "Admin",
                        Password = HashPassword.HashPassowrd("123456"),
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
