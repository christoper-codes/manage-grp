using manage_grp.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Data.Contexts
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<State> States { get; set; }

        public DbSet<Municipality> Municipalities { get; set; }

        public DbSet<Dependency> Dependencies { get; set; }

        public DbSet<Area> Areas { get; set; } 

        public DbSet<AreaServiceType> AreaServiceTypes { get; set; } 

        public DbSet<User> AspNetUsers { get; set; }

        public DbSet<Role> AspNetRoles { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Address> Addresses { get; set; }
        
        public DbSet<BudgetaryKey> BudgetaryKeys { get; set; }

        public DbSet<BudgetaryKeyDocumentType> BudgetaryKeyDocumentTypes { get; set; }

        public DbSet<ResourceDistributionDocumentType> ResourceDistributionDocumentTypes { get; set; }

        public DbSet<BudgetaryKeyDocumentTypeBudgetaryKey> BudgetaryKeyDocumentTypeBudgetaryKeys { get; set; }

        public DbSet<DocumentRequirement> DocumentRequirements { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<BudgetKeyDefault> BudgetKeyDefaults { get; set; }
        
        public DbSet<ResourceType> ResourceTypes { get; set; }

        public DbSet<ResourceDistribution> ResourceDistributions { get; set; }

        public DbSet<ResourceDistributionDocumentTypeResourceDistribution> ResourceDistributionDocumentTypeResourceDistributions { get; set; }

        public DbSet<TenderDocumentType> TenderDocumentTypes { get; set; }

        public DbSet<TenderType> TenderTypes { get; set; }
        
        public DbSet<TenderStatus> TenderStatuses { get; set; }

        public DbSet<TenderFundingSource> TenderFundingSources { get; set; }
        
        public DbSet<TenderPriceType> TenderPriceTypes { get; set; }
        
        public DbSet<Tender> Tenders { get; set; }

        public DbSet<TenderDocumentTypeTender> TenderDocumentTypeTenders { get; set; }

        public DbSet<ResourceDistributionTender> ResourceDistributionTenders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<State>()
                .HasIndex(s => s.ExternalStateId)
                .IsUnique();

            modelBuilder.Entity<Municipality>()
                .HasIndex(s => s.ExternalMunicipalityId)
                .IsUnique();

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

            modelBuilder.Entity<BudgetaryKeyDocumentTypeBudgetaryKey>()
                .HasOne(bkdt => bkdt.BudgetaryKey)
                .WithMany(bk => bk.BudgetaryKeyDocumentTypeBudgetaryKeys)
                .HasForeignKey(bkdt => bkdt.BudgetaryKeyId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BudgetaryKeyDocumentTypeBudgetaryKey>()
                .HasOne(bkdt => bkdt.BudgetaryKeyDocumentType)
                .WithMany(dt => dt.BudgetaryKeyDocumentTypeBudgetaryKeys)
                .HasForeignKey(bkdt => bkdt.BudgetaryKeyDocumentTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ResourceDistribution>(entity =>
            {
                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<ResourceDistribution>()
                .HasOne(r => r.BudgetaryKey)
                .WithMany()
                .HasForeignKey(r => r.BudgetaryKeyId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ResourceDistributionDocumentTypeResourceDistribution>()
                .HasOne(bkdt => bkdt.ResourceDistribution)
                .WithMany(bk => bk.ResourceDistributionDocumentTypeResourceDistributions)
                .HasForeignKey(bkdt => bkdt.ResourceDistributionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ResourceDistributionDocumentTypeResourceDistribution>()
                .HasOne(bkdt => bkdt.ResourceDistributionDocumentType)
                .WithMany(dt => dt.ResourceDistributionDocumentTypeResourceDistributions)
                .HasForeignKey(bkdt => bkdt.ResourceDistributionDocumentTypeId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<TenderDocumentTypeTender>()
                .HasOne(bkdt => bkdt.Tender)
                .WithMany(bk => bk.TenderDocumentTypeTenders)
                .HasForeignKey(bkdt => bkdt.TenderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TenderDocumentTypeTender>()
                .HasOne(bkdt => bkdt.TenderDocumentType)
                .WithMany(dt => dt.TenderDocumentTypeTenders)
                .HasForeignKey(bkdt => bkdt.TenderDocumentTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}