using BandAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.DBContext
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        { }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>().HasData(new Band()
            {
                Id = Guid.Parse("77c60f57-6a28-4e23-b6b2-94eab06b9120"),
                Name = "Mettalica",
                Founded = new DateTime(1980, 1, 1),
                MainGenre = "Heavy Metal"
            },
            new Band
            {
                Id = Guid.Parse("2c57d0b9-1469-42d7-9fd5-7aa7ef1f5c5b"),
                Name = "Guns and Roses",
                Founded = new DateTime(1985, 2, 1),
                MainGenre = "Rock"
            },
            new Band
            {
                Id = Guid.Parse("3022aebe-75fd-42f7-909d-3f0150ba2096"),
                Name = "ABBA",
                Founded = new DateTime(1965, 7, 1),
                MainGenre = "Disco"
            },
            new Band
            {
                Id = Guid.Parse("8b117edd-20c6-428c-87c7-0e45ebd813f5"),
                Name = "Oasis",
                Founded = new DateTime(1991, 6, 1),
                MainGenre = "Alternative"
            },
            new Band
            {
                Id = Guid.Parse("990f8d02-0b45-40c5-8035-2b9700c75123"),
                Name = "A-ha",
                Founded = new DateTime(1981, 6, 1),
                MainGenre = "Pop"
            });

            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    Id = Guid.Parse("4a31a3ee-6dc1-48fd-9da6-67717c0457b6"),
                    Title = "Master of Puppets",
                    Description = "One of the best heavy metal albums ever",
                    BandId = Guid.Parse("77c60f57-6a28-4e23-b6b2-94eab06b9120")
                },
                new Album
                {
                    Id = Guid.Parse("1c26241e-e159-4fc8-9c36-df6fbc2bc679"),
                    Title = "Appetite for Destruction",
                    Description = "Amazing Rock album with raw sound",
                    BandId = Guid.Parse("2c57d0b9-1469-42d7-9fd5-7aa7ef1f5c5b")
                },
                new Album
                {
                    Id = Guid.Parse("29009521-57ac-4f35-857b-2177ffeedcc5"),
                    Title = "Waterloo",
                    Description = "Very groovy album",
                    BandId = Guid.Parse("3022aebe-75fd-42f7-909d-3f0150ba2096")
                },
                 new Album
                 {
                     Id = Guid.Parse("7d4e3bda-5111-46d4-95b3-fe74dbde70eb"),
                     Title = "Be Here Now",
                     Description = "Argubly one of the best albums by Oasis",
                     BandId = Guid.Parse("8b117edd-20c6-428c-87c7-0e45ebd813f5")
                 },
                 new Album
                 {
                     Id = Guid.Parse("5bec116f-e6d5-4cfe-a585-7598ce63e292"),
                     Title = "Hunting Hight and Low",
                     Description = "Awesome Debut album by A-Ha",
                     BandId = Guid.Parse("990f8d02-0b45-40c5-8035-2b9700c75123")
                 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
