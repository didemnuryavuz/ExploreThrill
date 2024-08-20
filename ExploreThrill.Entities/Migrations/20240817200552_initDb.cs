using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExploreThrill.Entities.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MyUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_MyUserId",
                        column: x => x.MyUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MyUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_AspNetUsers_MyUserId",
                        column: x => x.MyUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MyUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_MyUserId",
                        column: x => x.MyUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActivityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MyUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_AspNetUsers_MyUserId",
                        column: x => x.MyUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Activities_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityCity",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityCity", x => new { x.ActivityId, x.CityId });
                    table.ForeignKey(
                        name: "FK_ActivityCity_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityCity_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99c113c8-3358-4c3f-b376-d16ae29476b8", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TcNo", "TwoFactorEnabled", "UserName" },
                values: new object[] { "99c113c8-3358-4c3f-b376-d16ae2947611", 0, "bdb65b1b-57a1-47f9-abab-5a297a96ca5e", "admin@admin.com", true, null, false, null, "admin@admin.com", "admin@admin.com", "AQAAAAIAAYagAAAAEDgwen5wue/zZZ3CWMUDyV+gLfZ8PbfnnCZcYi5U2zhgUqrTBQszatSCaYgn8JxDNw==", null, false, "", "12345678955", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreateDate", "MyUserId" },
                values: new object[,]
                {
                    { 1, "Water Activity", new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(7140), null },
                    { 2, "Nature Activity", new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(7142), null },
                    { 3, "Adventure Activity", new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(7143), null },
                    { 4, "Culture Activity", new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(7145), null },
                    { 5, "Daily Activity", new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(7146), null },
                    { 6, "Workshop", new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(7147), null }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreateDate", "MyUserId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(9188), null, "İstanbul" },
                    { 2, new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(9190), null, "Ankara" },
                    { 3, new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(9191), null, "İzmir" },
                    { 4, new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(9193), null, "Antalya" },
                    { 5, new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(9194), null, "Bursa" },
                    { 6, new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(9195), null, "Kastamonu" },
                    { 7, new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(9196), null, "Rize" },
                    { 8, new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(9197), null, "Gaziantep" },
                    { 9, new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(9198), null, "Şanlıurfa" },
                    { 10, new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(9199), null, "Mardin" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "CompanyName", "CreateDate", "Description", "Email", "MyUserId", "Phone", "Website" },
                values: new object[,]
                {
                    { 1, "Istanbul, Turkey", "Turkish Travel", new DateTime(2024, 8, 17, 20, 5, 52, 45, DateTimeKind.Utc).AddTicks(3114), "Leading travel company in Turkey", "info@turkishtravel.com", null, "00321234567", "www.turkishtravel.com" },
                    { 2, "Ankara, Turkey", "Anatolia Adventures", new DateTime(2024, 8, 17, 20, 5, 52, 45, DateTimeKind.Utc).AddTicks(3117), "Discover the beauty of Anatolia", "contact@anatoliaadventures.com", null, "00337654321", "www.anatoliaadventures.com" },
                    { 3, "Izmir, Turkey", "Ege Tours", new DateTime(2024, 8, 17, 20, 5, 52, 45, DateTimeKind.Utc).AddTicks(3118), "Explore the Aegean coast", "support@egetours.com", null, "00339876543", "www.egetours.com" },
                    { 4, "Antalya, Turkey", "Antalya Getaways", new DateTime(2024, 8, 17, 20, 5, 52, 45, DateTimeKind.Utc).AddTicks(3120), "Your guide to Antalya", "info@antalyagetaways.com", null, "00335432123", "www.antalyagetaways.com" },
                    { 5, "Mardin, Turkey", "Mardin Travels", new DateTime(2024, 8, 17, 20, 5, 52, 45, DateTimeKind.Utc).AddTicks(3122), "Experience the historical city of Mardin", "info@mardintravels.com", null, "00332109876", "www.mardintravels.com" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "ActivityDate", "ActivityName", "Capacity", "CategoryId", "CompanyId", "CreateDate", "Description", "MyUserId", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(4717), "Paragliding", 10, 3, 1, new DateTime(2024, 8, 17, 23, 5, 52, 44, DateTimeKind.Local).AddTicks(4702), "Fly over mountains", null, 150.00m },
                    { 2, new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(4721), "Canoeing", 8, 1, 4, new DateTime(2024, 8, 17, 23, 5, 52, 44, DateTimeKind.Local).AddTicks(4719), "Explore rivers", null, 100.00m },
                    { 3, new DateTime(2024, 8, 17, 20, 5, 52, 44, DateTimeKind.Utc).AddTicks(4723), "Hot Air Ballooning", 5, 2, 2, new DateTime(2024, 8, 17, 23, 5, 52, 44, DateTimeKind.Local).AddTicks(4722), "See the world from above", null, 200.00m },
                    { 4, new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scuba Diving", 10, 1, 4, new DateTime(2024, 8, 17, 23, 5, 52, 44, DateTimeKind.Local).AddTicks(4724), "Explore the underwater world", null, 250.00m },
                    { 5, new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boat Tour", 5, 5, 3, new DateTime(2024, 8, 17, 23, 5, 52, 44, DateTimeKind.Local).AddTicks(4727), "Explore the sea", null, 250.00m },
                    { 6, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain Climbing", 5, 2, 2, new DateTime(2024, 8, 17, 23, 5, 52, 44, DateTimeKind.Local).AddTicks(4729), "Conquer the peaks", null, 300.00m },
                    { 7, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Historical Tour", 20, 4, 4, new DateTime(2024, 8, 17, 23, 5, 52, 44, DateTimeKind.Local).AddTicks(4731), "Discover the ancient ruins", null, 150.00m }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "99c113c8-3358-4c3f-b376-d16ae29476b8", "99c113c8-3358-4c3f-b376-d16ae2947611" });

            migrationBuilder.InsertData(
                table: "ActivityCity",
                columns: new[] { "ActivityId", "CityId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 2, 3 },
                    { 3, 9 },
                    { 4, 4 },
                    { 5, 2 },
                    { 5, 4 },
                    { 6, 6 },
                    { 6, 9 },
                    { 7, 1 },
                    { 7, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CategoryId",
                table: "Activities",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CompanyId",
                table: "Activities",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_MyUserId",
                table: "Activities",
                column: "MyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCity_CityId",
                table: "ActivityCity",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryName",
                table: "Categories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MyUserId",
                table: "Categories",
                column: "MyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_MyUserId",
                table: "Cities",
                column: "MyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyName",
                table: "Companies",
                column: "CompanyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Email",
                table: "Companies",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_MyUserId",
                table: "Companies",
                column: "MyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Phone",
                table: "Companies",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Website",
                table: "Companies",
                column: "Website",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityCity");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
