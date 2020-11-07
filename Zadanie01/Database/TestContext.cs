using System;
using Microsoft.EntityFrameworkCore;

namespace Zadanie01.Database
{
    public class TestContext : DbContext
    {
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Rekrutacja;Trusted_Connection=True;";
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }
        public TestContext() : base() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Pismo> Pisma { get; set; }
        public DbSet<Korespondencja> Korespondencje { get; set; }
        public DbSet<KorespondencjaPisma> KorespondencjePisma { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KorespondencjaPisma>()
             .HasKey(bc => new { bc.IdKorespondencja, bc.IdPismo });
            modelBuilder.Entity<KorespondencjaPisma>()
                .HasOne(bc => bc.Korespondencja)
                .WithMany(b => b.KorespondencjePisma)
                .HasForeignKey(bc => bc.IdKorespondencja);
            modelBuilder.Entity<KorespondencjaPisma>()
                .HasOne(bc => bc.Pismo)
                .WithMany(c => c.KorespondencjePisma)
                .HasForeignKey(bc => bc.IdPismo);

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