using Microsoft.EntityFrameworkCore;
using System;

namespace kolokwiumEF.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        protected MainDbContext()
        {
        }

        public DbSet<Organization> Organization { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<File> File { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Organization>(e =>
            {
                e.HasKey(e => e.OrganizationID);
                e.Property(e => e.OrganizationName).IsRequired().HasMaxLength(100);
                e.Property(e => e.OrganizationDomain).IsRequired().HasMaxLength(50);

                e.HasData(
                    new Organization
                    {
                        OrganizationID = 1,
                        OrganizationName = "Organizacja1",
                        OrganizationDomain = "Domena1"
                    },
                    new Organization
                    {
                        OrganizationID = 2,
                        OrganizationName = "Organizacja2",
                        OrganizationDomain = "Domena2"
                    }
                );
            });

            modelBuilder.Entity<Member>(e =>
            {
                e.HasKey(e => e.MemberID);
                e.Property(e => e.MemberName).IsRequired().HasMaxLength(20);
                e.Property(e => e.MemberSurname).IsRequired().HasMaxLength(50);
                e.Property(e => e.MemberNickName).HasMaxLength(20);

                e.HasOne(e => e.Organization).WithMany(e => e.Members).HasForeignKey(e => e.OrganizationID);

                e.HasData(
                    new Member
                    {
                        MemberID = 1,
                        OrganizationID = 1,
                        MemberName = "Jan",
                        MemberSurname = "Kowalski",
                        MemberNickName = "Janek"
                    },
                    new Member
                    {
                        MemberID = 2,
                        OrganizationID = 2,
                        MemberName = "Piotr",
                        MemberSurname = "Nowak",
                        MemberNickName = "Piotrek"
                    }
                );
            });

            modelBuilder.Entity<Team>(e =>
            {
                e.HasKey(e => e.TeamID);
                e.Property(e => e.TeamName).IsRequired().HasMaxLength(50);
                e.Property(e => e.TeamDescription).HasMaxLength(500);

                e.HasOne(e => e.Organization).WithMany(e => e.Teams).HasForeignKey(e => e.OrganizationID);

                e.HasData(
                    new Team
                    {
                        TeamID = 1,
                        OrganizationID = 1,
                        TeamName = "Team1",
                        TeamDescription = "opis1"
                    },
                    new Team
                    {
                        TeamID = 2,
                        OrganizationID = 2,
                        TeamName = "Team2",
                        TeamDescription = "opis2"
                    }
                );
            });

            modelBuilder.Entity<Membership>(e =>
            {
                e.HasKey(e => new { e.MemberID, e.TeamID });
                e.Property(e => e.MembershipDate).IsRequired();

                e.HasOne(e => e.Member).WithMany(e => e.Memberships).HasForeignKey(e => e.MemberID);
                e.HasOne(e => e.Team).WithMany(e => e.Memberships).HasForeignKey(e => e.TeamID).IsRequired().OnDelete(DeleteBehavior.NoAction);

                e.HasData(
                    new Membership
                    {
                        MemberID = 1,
                        TeamID = 1,
                        MembershipDate = DateTime.Parse("2022-01-01")
                    },
                    new Membership
                    {
                        MemberID = 2,
                        TeamID = 2,
                        MembershipDate = DateTime.Parse("2022-02-02")
                    }
                );
            });

            modelBuilder.Entity<File>(e =>
            {
                e.HasKey(e => new { e.FileID, e.TeamID });
                e.Property(e => e.FileName).IsRequired().HasMaxLength(100);
                e.Property(e => e.FileExtension).IsRequired().HasMaxLength(4);
                e.Property(e => e.FileSize).IsRequired();

                e.HasOne(e => e.Team).WithMany(e => e.Files).HasForeignKey(e => e.TeamID);

                e.HasData(
                    new File
                    {
                        FileID = 1,
                        TeamID = 1,
                        FileName = "plik1",
                        FileExtension = "jpg",
                        FileSize = 1024
                    },
                    new File
                    {
                        FileID = 2,
                        TeamID = 2,
                        FileName = "plik2",
                        FileExtension = "png",
                        FileSize = 2048
                    }
                );
            });
        }
    }
}
