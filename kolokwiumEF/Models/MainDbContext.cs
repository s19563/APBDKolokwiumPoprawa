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

        public DbSet<Musician> Musician { get; set; }
        public DbSet<Musician_Track> Musician_Track { get; set; }
        public DbSet<Track> Track { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<MusicLabel> MusicLabel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Musician>(e =>
            {
                e.HasKey(e => e.IdMusician);
                e.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                e.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                e.Property(e => e.Nickname).HasMaxLength(20);

                e.HasData(
                    new Musician
                    {
                        IdMusician = 0,
                        FirstName = "Jan",
                        LastName = "Kowalski",
                        Nickname = "Janek"
                    },
                    new Musician
                    {
                        IdMusician = 1,
                        FirstName = "Adam",
                        LastName = "Nowak",
                        Nickname = "Nowacki"
                    }
                );
            });

            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.HasKey(e => e.IdMusicLabel);
                e.Property(e => e.Name).IsRequired().HasMaxLength(50);

                e.HasData(
                    new MusicLabel
                    {
                        IdMusicLabel = 0,
                        Name = "Lalala"
                    },
                    new MusicLabel
                    {
                        IdMusicLabel = 1,
                        Name = "Blabla"
                    }
                );
            });

            modelBuilder.Entity<Album>(e =>
            {
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                e.Property(e => e.PublishDate).IsRequired();

                e.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel);

                e.HasData(
                    new Album
                    {
                        IdMusicLabel = 0,
                        AlbumName = "Costam",
                        PublishDate = DateTime.Parse("2022-06-01")
                    },
                    new Album
                    {
                        IdMusicLabel = 1,
                        AlbumName = "Costamtam",
                        PublishDate = DateTime.Parse("2022-06-01")
                    }
                );
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
                e.Property(e => e.Duration).IsRequired();

                e.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdMusicAlbum);

                e.HasData(
                    new Track
                    {
                        IdTrack = 0,
                        TrackName = "Aaaaa",
                        Duration = 3.54F
                    },
                    new Track
                    {
                        IdTrack = 1,
                        TrackName = "Bbbbb",
                        Duration = 4.1F
                    }
                );
            });

            modelBuilder.Entity<Musician_Track>(e =>
            {
                e.HasKey(e => new { e.IdTrack, e.IdMusician });

                e.HasOne(e => e.Musician).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdMusician);
                e.HasOne(e => e.Track).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdTrack);

                e.HasData(
                    new Musician_Track
                    {
                        IdMusician = 0,
                        IdTrack = 0
                    },
                    new Musician_Track
                    {
                        IdMusician = 1,
                        IdTrack = 1
                    }
                );
            });
        }
    }
}
