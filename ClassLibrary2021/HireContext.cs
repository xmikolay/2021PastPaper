using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary2021
{
    public class HireContext : DbContext
    {
        //db context for Hire and Car entities
        public DbSet<Hire> Hires { get; set; }
        public DbSet<Car> Cars { get; set; }

        //constructor for mvc app that accepts options
        public HireContext(DbContextOptions<HireContext> options) : base(options)
        {
        }

        //default constructor
        public HireContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //configure the context to use a SQL Server database
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HireDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configure the one-to-many relationship between Car and Hire
            modelBuilder.Entity<Hire>()
                .HasOne(h => h.Car)
                .WithMany(c => c.Hires)
                .HasForeignKey(h => h.CarID);

            //seed data for Cars
            modelBuilder.Entity<Car>()
                .HasData(
                    new Car { CarID = 1, Make = "VW", Model = "Polo", Class = "Economy", CostPerDay = 51.83m },
                    new Car { CarID = 2, Make = "Ford", Model = "Focus", Class = "Compact", CostPerDay = 59.93m },
                    new Car { CarID = 3, Make = "Ford", Model = "Puma", Class = "Compact", CostPerDay = 56.87m },
                    new Car { CarID = 4, Make = "VW", Model = "UP", Class = "Mini", CostPerDay = 50.92m },
                    new Car { CarID = 5, Make = "Ford", Model = "Kuga", Class = "Standard", CostPerDay = 66.22m }
                );

            //seed data for Hires
            modelBuilder.Entity<Hire>().HasData(
                new Hire { HireID = 1, HireStartDate = new DateTime(2021, 12, 12), HireEndDate = new DateTime(2021, 12, 14), PickUpLocation = "Sligo", DropOffLocation = "Sligo", ExtraCharge = 30m, CarID = 1 },
                new Hire { HireID = 2, HireStartDate = new DateTime(2021, 12, 23), HireEndDate = new DateTime(2021, 12, 27), PickUpLocation = "Sligo", DropOffLocation = "Dublin Airport", ExtraCharge = 127.56m, CarID = 1 },
                new Hire { HireID = 3, HireStartDate = new DateTime(2022, 1, 4), HireEndDate = new DateTime(2022, 1, 6), PickUpLocation = "Sligo", DropOffLocation = "Sligo", ExtraCharge = 30m, CarID = 5 },
                new Hire { HireID = 4, HireStartDate = new DateTime(2022, 1, 5), HireEndDate = new DateTime(2022, 1, 6), PickUpLocation = "Sligo", DropOffLocation = "Sligo", ExtraCharge = 30m, CarID = 5 }
            );

        }
    }
}
