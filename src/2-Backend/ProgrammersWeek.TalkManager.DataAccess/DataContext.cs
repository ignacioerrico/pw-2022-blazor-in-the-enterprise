using Microsoft.EntityFrameworkCore;
using ProgrammersWeek.TalkManager.DataAccess.Data;
using ProgrammersWeek.TalkManager.Shared.Models;

namespace ProgrammersWeek.TalkManager.DataAccess;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Talk> Talks { get; set; }

    public DbSet<Author> Authors { get; set; }
    public DbSet<InterestArea> InterestAreas { get; set; }
    public DbSet<Region> Regions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed many-to-many relationship
        // For more info, see: https://github.com/dotnet/EntityFramework.Docs/issues/2879
        modelBuilder.Entity<Talk>()
            .HasMany(t => t.Authors)
            .WithMany(a => a.Talks)
            .UsingEntity<Dictionary<string, object>>(
                "TalkAuthor",
                r => r.HasOne<Author>().WithMany().HasForeignKey("AuthorId"),
                l => l.HasOne<Talk>().WithMany().HasForeignKey("TalkId"),
                je =>
                {
                    je.HasKey("TalkId", "AuthorId");
                    je.HasData(
                        new { TalkId = 1, AuthorId = 1 },
                        new { TalkId = 2, AuthorId = 2 },
                        new { TalkId = 3, AuthorId = 3 },
                        new { TalkId = 4, AuthorId = 4 },
                        new { TalkId = 5, AuthorId = 5 },
                        new { TalkId = 5, AuthorId = 6 },
                        new { TalkId = 6, AuthorId = 7 },
                        new { TalkId = 7, AuthorId = 8 },
                        new { TalkId = 8, AuthorId = 9 },
                        new { TalkId = 9, AuthorId = 10 }
                    );
                });

        modelBuilder.Entity<Talk>()
            .HasOne(t => t.InterestArea)
            .WithMany(ia => ia.Talks);

        modelBuilder.Entity<Talk>()
            .HasOne(t => t.Region)
            .WithMany(r => r.Talks);

        modelBuilder.Entity<Author>()
            .HasKey(a => a.Id);

        modelBuilder.Entity<Author>()
            .Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<Author>()
            .Property(a => a.Title)
            .HasMaxLength(50);

        modelBuilder.Entity<Author>()
            .HasMany(a => a.Talks)
            .WithMany(t => t.Authors);

        modelBuilder.Entity<InterestArea>()
            .HasKey(ia => ia.Id);

        modelBuilder.Entity<InterestArea>()
            .Property(ia => ia.Name)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<InterestArea>()
            .HasMany(ia => ia.Talks)
            .WithOne(t => t.InterestArea);

        modelBuilder.Entity<Region>()
            .Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<Region>()
            .HasMany(r => r.Talks)
            .WithOne(t => t.Region);

        modelBuilder.Entity<Talk>()
            .HasData(StaticTalks.GetList());

        modelBuilder.Entity<Author>()
            .HasData(StaticAuthors.GetList());
        
        modelBuilder.Entity<InterestArea>()
            .HasData(StaticInterestAreas.GetList());

        modelBuilder.Entity<Region>()
            .HasData(StaticRegions.GetList());

        base.OnModelCreating(modelBuilder);
    }
}
