using System;
using Microsoft.EntityFrameworkCore;

namespace Zadanie01.Database
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public DbSet<Pismo> Pisma { get; set; }
        public DbSet<Korespondencja> Korespondencje { get; set; }
        public DbSet<KorespondencjaPisma> KorespondencjePisma { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pismo>().HasData(
                new Pismo {Id = "p1", Nazwa = "Pismo 1", Numer = "1/2020"},
                new Pismo {Id = "p2", Nazwa = "Pismo 2", Numer = "2/2020"},
                new Pismo {Id = "p3", Nazwa = "Pismo 3", Numer = "3/2020", Priorytet = true},
                new Pismo {Id = "p4", Nazwa = "Pismo 4", Numer = "4/2020", Priorytet = true});

            modelBuilder.Entity<Korespondencja>().HasData(
                new Korespondencja {Id = "k1", DataWysylki = new DateTime(2020, 6, 7)},
                new Korespondencja {Id = "k2", DataWysylki = new DateTime(2020, 6, 8)});

            modelBuilder.Entity<KorespondencjaPisma>().HasData(
                new KorespondencjaPisma {Id = 1, IdPismo = "p1", IdKorespondencja = "k1"},
                new KorespondencjaPisma {Id = 2, IdPismo = "p3", IdKorespondencja = "k1"},
                new KorespondencjaPisma {Id = 3, IdPismo = "p2", IdKorespondencja = "k2"});
        }
    }
}