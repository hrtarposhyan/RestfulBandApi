using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BandAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Founded = table.Column<DateTime>(nullable: false),
                    MainGenre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: true),
                    BandId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Founded", "MainGenre", "Name" },
                values: new object[,]
                {
                    { new Guid("77c60f57-6a28-4e23-b6b2-94eab06b9120"), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heavy Metal", "Mettalica" },
                    { new Guid("2c57d0b9-1469-42d7-9fd5-7aa7ef1f5c5b"), new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Guns and Roses" },
                    { new Guid("3022aebe-75fd-42f7-909d-3f0150ba2096"), new DateTime(1965, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Disco", "ABBA" },
                    { new Guid("8b117edd-20c6-428c-87c7-0e45ebd813f5"), new DateTime(1991, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alternative", "Oasis" },
                    { new Guid("990f8d02-0b45-40c5-8035-2b9700c75123"), new DateTime(1981, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pop", "A-ha" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "BandId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("4a31a3ee-6dc1-48fd-9da6-67717c0457b6"), new Guid("77c60f57-6a28-4e23-b6b2-94eab06b9120"), "One of the best heavy metal albums ever", "Master of Puppets" },
                    { new Guid("1c26241e-e159-4fc8-9c36-df6fbc2bc679"), new Guid("2c57d0b9-1469-42d7-9fd5-7aa7ef1f5c5b"), "Amazing Rock album with raw sound", "Appetite for Destruction" },
                    { new Guid("29009521-57ac-4f35-857b-2177ffeedcc5"), new Guid("3022aebe-75fd-42f7-909d-3f0150ba2096"), "Very groovy album", "Waterloo" },
                    { new Guid("7d4e3bda-5111-46d4-95b3-fe74dbde70eb"), new Guid("8b117edd-20c6-428c-87c7-0e45ebd813f5"), "Argubly one of the best albums by Oasis", "Be Here Now" },
                    { new Guid("5bec116f-e6d5-4cfe-a585-7598ce63e292"), new Guid("990f8d02-0b45-40c5-8035-2b9700c75123"), "Awesome Debut album by A-Ha", "Hunting Hight and Low" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_BandId",
                table: "Albums",
                column: "BandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Bands");
        }
    }
}
