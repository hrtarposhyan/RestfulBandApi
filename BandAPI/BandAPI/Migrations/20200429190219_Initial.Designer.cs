﻿// <auto-generated />
using System;
using BandAPI.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BandAPI.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20200429190219_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BandAPI.Entities.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4a31a3ee-6dc1-48fd-9da6-67717c0457b6"),
                            BandId = new Guid("77c60f57-6a28-4e23-b6b2-94eab06b9120"),
                            Description = "One of the best heavy metal albums ever",
                            Title = "Master of Puppets"
                        },
                        new
                        {
                            Id = new Guid("1c26241e-e159-4fc8-9c36-df6fbc2bc679"),
                            BandId = new Guid("2c57d0b9-1469-42d7-9fd5-7aa7ef1f5c5b"),
                            Description = "Amazing Rock album with raw sound",
                            Title = "Appetite for Destruction"
                        },
                        new
                        {
                            Id = new Guid("29009521-57ac-4f35-857b-2177ffeedcc5"),
                            BandId = new Guid("3022aebe-75fd-42f7-909d-3f0150ba2096"),
                            Description = "Very groovy album",
                            Title = "Waterloo"
                        },
                        new
                        {
                            Id = new Guid("7d4e3bda-5111-46d4-95b3-fe74dbde70eb"),
                            BandId = new Guid("8b117edd-20c6-428c-87c7-0e45ebd813f5"),
                            Description = "Argubly one of the best albums by Oasis",
                            Title = "Be Here Now"
                        },
                        new
                        {
                            Id = new Guid("5bec116f-e6d5-4cfe-a585-7598ce63e292"),
                            BandId = new Guid("990f8d02-0b45-40c5-8035-2b9700c75123"),
                            Description = "Awesome Debut album by A-Ha",
                            Title = "Hunting Hight and Low"
                        });
                });

            modelBuilder.Entity("BandAPI.Entities.Band", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Founded")
                        .HasColumnType("datetime2");

                    b.Property<string>("MainGenre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Bands");

                    b.HasData(
                        new
                        {
                            Id = new Guid("77c60f57-6a28-4e23-b6b2-94eab06b9120"),
                            Founded = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MainGenre = "Heavy Metal",
                            Name = "Mettalica"
                        },
                        new
                        {
                            Id = new Guid("2c57d0b9-1469-42d7-9fd5-7aa7ef1f5c5b"),
                            Founded = new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MainGenre = "Rock",
                            Name = "Guns and Roses"
                        },
                        new
                        {
                            Id = new Guid("3022aebe-75fd-42f7-909d-3f0150ba2096"),
                            Founded = new DateTime(1965, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MainGenre = "Disco",
                            Name = "ABBA"
                        },
                        new
                        {
                            Id = new Guid("8b117edd-20c6-428c-87c7-0e45ebd813f5"),
                            Founded = new DateTime(1991, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MainGenre = "Alternative",
                            Name = "Oasis"
                        },
                        new
                        {
                            Id = new Guid("990f8d02-0b45-40c5-8035-2b9700c75123"),
                            Founded = new DateTime(1981, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MainGenre = "Pop",
                            Name = "A-ha"
                        });
                });

            modelBuilder.Entity("BandAPI.Entities.Album", b =>
                {
                    b.HasOne("BandAPI.Entities.Band", "Band")
                        .WithMany("Albums")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
