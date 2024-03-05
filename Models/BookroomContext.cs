
using Bookroom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

 
namespace Bookroom.Models
{
    public class BookroomContext : IdentityDbContext<IdentityUser>
    {
        public BookroomContext(DbContextOptions<BookroomContext> options) : base(options)
        {
        }
 
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Roomtype> Roomtypes { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
 
            modelBuilder.Entity<Rent>()
                .HasOne(p => p.Room)
                .WithMany(v => v.Rents)
                .HasForeignKey(p => p.RoomId);

                modelBuilder.Entity<Rent>()
                .HasKey(p => new {p.PriceId});
 
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.CustomerId)
                .IsUnique();

                modelBuilder.Entity<Roomtype>()
                .HasKey(r => r.RoomtypeId);
 
            modelBuilder.Entity<Bookingorder>()
                .HasKey(op => new { op.OrderId, op.CustomerId, op.RoomId });
 
            modelBuilder.Entity<Bookingorder>()
                .HasOne(op => op.Customer)
                .WithMany()
                .HasForeignKey(op => op.CustomerId);
 
            modelBuilder.Entity<Bookingorder>()
                .HasOne(op => op.Roomtype)
                .WithMany()
                .HasForeignKey(op => op.RoomId);
        }
        public DbSet<Bookroom.Models.Bookingorder> Bookingorder { get; set; } = default!;
    }
}