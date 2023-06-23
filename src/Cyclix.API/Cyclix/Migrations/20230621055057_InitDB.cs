using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cyclix.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    HouseNumber = table.Column<string>(type: "TEXT", nullable: false),
                    PostCode = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Telephone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeId = table.Column<long>(type: "INTEGER", nullable: false),
                    BrandId = table.Column<long>(type: "INTEGER", nullable: false),
                    ServiceId = table.Column<long>(type: "INTEGER", nullable: false),
                    PackageId = table.Column<string>(type: "TEXT", nullable: false),
                    OptionId = table.Column<string>(type: "TEXT", nullable: false),
                    AnotherOptionId = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bikes_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "City", "Email", "FirstName", "HouseNumber", "LastName", "PostCode", "Street", "Telephone" },
                values: new object[] { 1L, "Ho Chi Minh", "abc@test.com", "Hung", "10", "Pham", "700000", "Pham Hung", "1234567890" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[,]
                {
                    { 1L, "type", "type 1" },
                    { 2L, "type", "type 2" },
                    { 3L, "type", "type 3" },
                    { 4L, "brand", "brand 1" },
                    { 5L, "brand", "brand 2" },
                    { 6L, "brand", "brand 3" },
                    { 7L, "service", "service 1" },
                    { 8L, "service", "service 2" },
                    { 9L, "service", "service 3" },
                    { 10L, "option", "option 1" },
                    { 11L, "option", "option 2" },
                    { 12L, "option", "option 3" },
                    { 13L, "option", "option 4" },
                    { 14L, "option", "option 5" },
                    { 15L, "option", "option 6" },
                    { 16L, "package", "package 1" },
                    { 17L, "package", "package 2" },
                    { 18L, "another_option", "another option 1" },
                    { 19L, "another_option", "another option 2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_CustomerId",
                table: "Bikes",
                column: "CustomerId");
            
            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "TypeId", "BrandId", "ServiceId", "PackageId", "OptionId", "AnotherOptionId", "Description", "Note", "CustomerId" },
                values: new object[] { 1L, 1L, 4L, 7L, "16", "10", "18", "Description", "Note", 1L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bikes");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
