using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExploreThrill.Entities.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TcNo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreateDate", "MyUserId" },
                values: new object[,]
                {
                    { 1, "Su Sporları", new DateTime(2024, 8, 10, 13, 17, 4, 138, DateTimeKind.Utc).AddTicks(7214), null },
                    { 2, "Doğa Etkinlikleri", new DateTime(2024, 8, 10, 13, 17, 4, 138, DateTimeKind.Utc).AddTicks(7216), null },
                    { 3, "Adrenalin Etkinlikleri", new DateTime(2024, 8, 10, 13, 17, 4, 138, DateTimeKind.Utc).AddTicks(7218), null },
                    { 4, "Kültürel Etkinlikler", new DateTime(2024, 8, 10, 13, 17, 4, 138, DateTimeKind.Utc).AddTicks(7220), null },
                    { 5, "Günübirlik Etkinlikler", new DateTime(2024, 8, 10, 13, 17, 4, 138, DateTimeKind.Utc).AddTicks(7222), null },
                    { 6, "Atölyeler", new DateTime(2024, 8, 10, 13, 17, 4, 138, DateTimeKind.Utc).AddTicks(7224), null }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreateDate", "MyUserId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 10, 13, 17, 4, 139, DateTimeKind.Utc).AddTicks(618), null, "İstanbul" },
                    { 2, new DateTime(2024, 8, 10, 13, 17, 4, 139, DateTimeKind.Utc).AddTicks(620), null, "Ankara" },
                    { 3, new DateTime(2024, 8, 10, 13, 17, 4, 139, DateTimeKind.Utc).AddTicks(622), null, "İzmir" },
                    { 4, new DateTime(2024, 8, 10, 13, 17, 4, 139, DateTimeKind.Utc).AddTicks(624), null, "Antalya" },
                    { 5, new DateTime(2024, 8, 10, 13, 17, 4, 139, DateTimeKind.Utc).AddTicks(626), null, "Bursa" },
                    { 6, new DateTime(2024, 8, 10, 13, 17, 4, 139, DateTimeKind.Utc).AddTicks(628), null, "Kastamonu" },
                    { 7, new DateTime(2024, 8, 10, 13, 17, 4, 139, DateTimeKind.Utc).AddTicks(630), null, "Rize" },
                    { 8, new DateTime(2024, 8, 10, 13, 17, 4, 139, DateTimeKind.Utc).AddTicks(632), null, "Gaziantep" },
                    { 9, new DateTime(2024, 8, 10, 13, 17, 4, 139, DateTimeKind.Utc).AddTicks(634), null, "Şanlıurfa" },
                    { 10, new DateTime(2024, 8, 10, 13, 17, 4, 139, DateTimeKind.Utc).AddTicks(636), null, "Mardin" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "CompanyName", "CreateDate", "Description", "Email", "MyUserId", "Phone", "Website" },
                values: new object[,]
                {
                    { 1, "Istanbul, Turkey", "Turkish Travel", new DateTime(2024, 8, 10, 13, 17, 4, 139, DateTimeKind.Utc).AddTicks(5941), "Leading travel company in Turkey", "info@turkishtravel.com", null, "00321234567", "www.turkishtravel.com" },
                    { 2, "Ankara, Turkey", "Anatolia Adventures", new DateTime(2024, 8, 10, 13, 17, 4, 139, DateTimeKind.Utc).AddTicks(5945), "Discover the beauty of Anatolia", "contact@anatoliaadventures.com", null, "00337654321", "www.anatoliaadventures.com" },
                    { 3, "Izmir, Turkey", "Ege Tours", new DateTime(2024, 8, 10, 13, 17, 4, 139, DateTimeKind.Utc).AddTicks(5947), "Explore the Aegean coast", "support@egetours.com", null, "00339876543", "www.egetours.com" },
                    { 4, "Antalya, Turkey", "Antalya Getaways", new DateTime(2024, 8, 10, 13, 17, 4, 139, DateTimeKind.Utc).AddTicks(5950), "Your guide to Antalya", "info@antalyagetaways.com", null, "00335432123", "www.antalyagetaways.com" },
                    { 5, "Mardin, Turkey", "Mardin Travels", new DateTime(2024, 8, 10, 13, 17, 4, 139, DateTimeKind.Utc).AddTicks(5952), "Experience the historical city of Mardin", "info@mardintravels.com", null, "00332109876", "www.mardintravels.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TcNo",
                table: "AspNetUsers");
        }
    }
}
