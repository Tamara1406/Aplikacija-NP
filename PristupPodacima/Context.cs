using Domen;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PristupPodacima
{
    /// <summary>
    /// Predstavlja klasu koja sluzi za povezivanje sa bazom podataka.
    /// 
    /// Nasledjuje IdentityDbContext sa parametrom User
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class Context : IdentityDbContext<User>
    {
        /// <summary>
        /// Lista klijenata koji treniraju u teretani.
        /// </summary>
        public DbSet<Klijent> Klijenti { get; set; }
        /// <summary>
        /// Lista trenera koji rade u teretani.
        /// </summary>
        public DbSet<Trener> Treneri { get; set; }
        /// <summary>
        /// Lista grupa koje postoje u teretani.
        /// </summary>
        public DbSet<Grupa> Grupe { get; set; }
        /// <summary>
        /// Lista mesta u kojima se nalazi teretana.
        /// </summary>
        public DbSet<Mesto> Mesta { get; set; }
        /// <summary>
        /// Lista naziva strucne spreme.
        /// </summary>
        public DbSet<Obrazovanje> Obrazovanja { get; set; }
        /// <summary>
        /// Lista polova.
        /// </summary>
        public DbSet<Pol> Pol { get; set; }
        /// <summary>
        /// Lista termina u kojima se odrzavaju treninzi.
        /// </summary>
        public DbSet<Termin> Termini { get; set; }

        /// <summary>
        /// Metoda koja povezuje aplikaciju sa bazom podataka.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Aplikacija.teretana;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        /// <summary>
        /// Metoda koja konvertuje podatke iz baze u promenljive.
        /// </summary>
        /// <param name="modelBuilder"></param>
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