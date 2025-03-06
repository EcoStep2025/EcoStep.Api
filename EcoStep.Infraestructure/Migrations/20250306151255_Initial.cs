using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcoStep.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenderName = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProvinceName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirebaseId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    BirthDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GenderId = table.Column<int>(type: "integer", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    ProvinceId = table.Column<int>(type: "integer", nullable: true),
                    ImageId = table.Column<int>(type: "integer", nullable: true),
                    VerificationCode = table.Column<string>(type: "text", nullable: true),
                    Token = table.Column<string>(type: "text", nullable: true),
                    isEmailVerified = table.Column<bool>(type: "boolean", nullable: true),
                    VerificationCodeExpiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RegisterType = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    ImageUrl = table.Column<List<string>>(type: "text[]", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryName", "CreatedAt", "IsDeleted", "UpdatedAt" },
                values: new object[] { 1, "Spain", null, false, null });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "CreatedAt", "GenderName", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, "Male", false, null },
                    { 2, null, "Female", false, null },
                    { 3, null, "Non-binary", false, null },
                    { 4, null, "Gender fluid", false, null },
                    { 5, null, "Agender", false, null },
                    { 6, null, "Bigender", false, null },
                    { 7, null, "Demiboy", false, null },
                    { 8, null, "DemiGirl", false, null }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CountryId", "CreatedAt", "IsDeleted", "ProvinceName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, null, false, "Álava", null },
                    { 2, 1, null, false, "Albacete", null },
                    { 3, 1, null, false, "Alicante", null },
                    { 4, 1, null, false, "Almería", null },
                    { 5, 1, null, false, "Asturias", null },
                    { 6, 1, null, false, "Ávila", null },
                    { 7, 1, null, false, "Badajoz", null },
                    { 8, 1, null, false, "Baleares", null },
                    { 9, 1, null, false, "Barcelona", null },
                    { 10, 1, null, false, "Burgos", null },
                    { 11, 1, null, false, "Cáceres", null },
                    { 12, 1, null, false, "Cádiz", null },
                    { 13, 1, null, false, "Cantabria", null },
                    { 14, 1, null, false, "Castellón", null },
                    { 15, 1, null, false, "Ceuta", null },
                    { 16, 1, null, false, "Ciudad Real", null },
                    { 17, 1, null, false, "Córdoba", null },
                    { 18, 1, null, false, "Cuenca", null },
                    { 19, 1, null, false, "Girona", null },
                    { 20, 1, null, false, "Granada", null },
                    { 21, 1, null, false, "Guadalajara", null },
                    { 22, 1, null, false, "Guipúzcoa", null },
                    { 23, 1, null, false, "Huelva", null },
                    { 24, 1, null, false, "Huesca", null },
                    { 25, 1, null, false, "Jaén", null },
                    { 26, 1, null, false, "La Coruña", null },
                    { 27, 1, null, false, "La Rioja", null },
                    { 28, 1, null, false, "Las Palmas", null },
                    { 29, 1, null, false, "León", null },
                    { 30, 1, null, false, "Lleida", null },
                    { 31, 1, null, false, "Lugo", null },
                    { 32, 1, null, false, "Madrid", null },
                    { 33, 1, null, false, "Málaga", null },
                    { 34, 1, null, false, "Melilla", null },
                    { 35, 1, null, false, "Murcia", null },
                    { 36, 1, null, false, "Navarra", null },
                    { 37, 1, null, false, "Ourense", null },
                    { 38, 1, null, false, "Palencia", null },
                    { 39, 1, null, false, "Pontevedra", null },
                    { 40, 1, null, false, "Salamanca", null },
                    { 41, 1, null, false, "Santa Cruz de Tenerife", null },
                    { 42, 1, null, false, "Segovia", null },
                    { 43, 1, null, false, "Sevilla", null },
                    { 44, 1, null, false, "Soria", null },
                    { 45, 1, null, false, "Tarragona", null },
                    { 46, 1, null, false, "Teruel", null },
                    { 47, 1, null, false, "Toledo", null },
                    { 48, 1, null, false, "Valencia", null },
                    { 49, 1, null, false, "Valladolid", null },
                    { 50, 1, null, false, "Vizcaya", null },
                    { 51, 1, null, false, "Zamora", null },
                    { 52, 1, null, false, "Zaragoza", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                table: "Users",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProvinceId",
                table: "Users",
                column: "ProvinceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
