using System;
using Microsoft.EntityFrameworkCore;

namespace Zadanie02.Database
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }

        public DbSet<Pismo> Pisma { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pismo>().HasData(
                new Pismo {Id = "p1", Nazwa = "Pismo 1", Rocznik = 2019},
                new Pismo {Id = "p2", Nazwa = "Pismo 2", Rocznik = 2019, Priorytet = true},
                new Pismo {Id = "p3", Nazwa = "Pismo 3", Rocznik = 2019, Priorytet = true, CzySkasowany = true},
                new Pismo {Id = "p4", Nazwa = "Pismo 4", Rocznik = 2019, CzySkasowany = true},
                new Pismo {Id = "p5", Nazwa = "Pismo 5", Rocznik = 2020},
                new Pismo {Id = "p6", Nazwa = "Pismo 6", Rocznik = 2020, Priorytet = true},
                new Pismo {Id = "p7", Nazwa = "Pismo 7", Rocznik = 2020, Priorytet = true, CzySkasowany = true},
                new Pismo {Id = "p8", Nazwa = "Pismo 8", Rocznik = 2020, CzySkasowany = true},
                new Pismo {Id = "p9", Nazwa = "Pismo 9", Rocznik = 2020});
        }
    }
}