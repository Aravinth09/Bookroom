
using Microsoft.EntityFrameworkCore;
using Bookroom.Models;
 
namespace Bookroom.Models
{
    public class BookroomContext : DbContext
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
// using Microsoft.EntityFrameworkCore;

// using System.Collections.Generic;


// using Microsoft.AspNetCore.Identity;
// namespace RentalApp.Models
// {
// public class RentalAppContext : DbContext
//     {
//         public RentalAppContext(DbContextOptions<RentalAppContext> options) : base(options)
//         {
//         }

//         public DbSet<Customer> Customer { get; set; }
//         public DbSet<Location> Location { get; set; }

//         public DbSet<Pricing> Pricing { get; set; }

//         public DbSet<RentalOrder> RentalOrder { get; set; }
//         public DbSet<Vehicle> Vehicle { get; set; }

//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         base.OnModelCreating(modelBuilder); 
       
//          modelBuilder.Entity<Pricing>()        
//          .HasOne(p => p.Vehicle)
//          .WithMany(v => v.Pricing)
//         .HasForeignKey(p => p.VehicleId);  

//          modelBuilder.Entity<Customer>()        
//          .HasIndex(c => c.CustomerId)        
//          .IsUnique();    

//          modelBuilder.Entity<RentalOrder>()       
//         .HasKey(op => new { op.OrderId, op.CustomerId, op.VehicleId });

//         modelBuilder.Entity<RentalOrder>()        
//         .HasOne(op => op.Customer)        
//         .WithMany()        
//         .HasForeignKey(op => op.CustomerId);

//         modelBuilder.Entity<RentalOrder>()        
//         .HasOne(op => op.Vehicle)        
//         .WithMany()        
//         .HasForeignKey(op => op.VehicleId);

         
        
// 	}
// }
// }