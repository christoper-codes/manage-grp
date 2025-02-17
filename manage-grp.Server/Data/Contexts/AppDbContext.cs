using manage_grp.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Xml.Linq;

namespace manage_grp.Server.Data.Contexts
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<State> States { get; set; }

        public DbSet<Municipality> Municipalities { get; set; }

        public DbSet<Dependency> Dependencies { get; set; }

        public DbSet<Area> Areas { get; set; } 

        public DbSet<User> AspNetUsers { get; set; }

        public DbSet<Role> AspNetRoles { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Address> Addresses { get; set; }
        
        public DbSet<BudgetaryKey> BudgetaryKeys { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<BudgetaryKeyDocumentType> BudgetaryKeyDocumentTypes { get; set; }

        public DbSet<DocumentRequirement> DocumentRequirements { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<BudgetKeyDefault> BudgetKeyDefaults { get; set; }         

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasOne(e => e.Dependency)
                      .WithMany()
                      .HasForeignKey(e => e.DependencyId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Position)
                      .WithMany()
                      .HasForeignKey(e => e.PositionId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasOne(e => e.Dependency)
                      .WithMany()
                      .HasForeignKey(e => e.DependencyId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<BudgetaryKey>(entity =>
            {
                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(e => e.Dependency)
                      .WithMany(d => d.BudgetaryKeys)
                      .HasForeignKey(e => e.DependencyId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<BudgetaryKeyDocumentType>()
                .HasOne(bkdt => bkdt.BudgetaryKey)
                .WithMany(bk => bk.BudgetaryKeyDocumentTypes)
                .HasForeignKey(bkdt => bkdt.BudgetaryKeyId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BudgetaryKeyDocumentType>()
                .HasOne(bkdt => bkdt.DocumentType)
                .WithMany(dt => dt.BudgetaryKeyDocumentTypes)
                .HasForeignKey(bkdt => bkdt.DocumentTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}