using Domen;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PristupPodacima
{
    public class Context : IdentityDbContext<User>
    {
        public DbSet<Klijent> Klijenti { get; set; }
        public DbSet<Trener> Treneri { get; set; }
        public DbSet<Grupa> Grupe { get; set; }
        public DbSet<Mesto> Mesta { get; set; }
        public DbSet<Obrazovanje> Obrazovanja { get; set; }
        public DbSet<Pol> Pol { get; set; }
        public DbSet<Termin> Termini { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Aplikacija.NP;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trener>()
                .HasOne(t => t.Obrazovanje)
                .WithMany()
                .HasForeignKey(t => t.ObrazovanjeID);
            modelBuilder.Entity<Grupa>()
                .HasOne(g => g.Trener)
                .WithMany()
                .HasForeignKey(g => g.TrenerID);
            modelBuilder.Entity<Grupa>()
                .HasOne(g => g.Mesto)
                .WithMany()
                .HasForeignKey(g => g.MestoID);
            modelBuilder.Entity<Mesto>().ToTable("Mesto");
            modelBuilder.Entity<Obrazovanje>().ToTable("Obrazovanje");
            modelBuilder.Entity<Pol>().ToTable("Pol");
            modelBuilder.Entity<Klijent>()
                .HasOne(k => k.Grupa)
                .WithMany()
                .HasForeignKey(k => k.GrupaID);
            modelBuilder.Entity<Klijent>()
                .HasOne(k => k.Pol)
                .WithMany()
                .HasForeignKey(k => k.PolID);
            modelBuilder.Entity<Termin>()
                .HasOne(t => t.Grupa)
                .WithMany()
                .HasForeignKey(t => t.GrupaID);
            modelBuilder.Entity<User>().ToTable("User");
            base.OnModelCreating(modelBuilder);

        }

    }
}