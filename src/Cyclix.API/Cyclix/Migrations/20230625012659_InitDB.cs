﻿using Microsoft.EntityFrameworkCore.Migrations;

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
                name: "AnotherOptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnotherOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

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
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeId = table.Column<long>(type: "INTEGER", nullable: false),
                    BrandId = table.Column<long>(type: "INTEGER", nullable: false),
                    ServiceId = table.Column<long>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestAnotherOptions",
                columns: table => new
                {
                    RequestId = table.Column<long>(type: "INTEGER", nullable: false),
                    AnotherOptionId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestAnotherOptions", x => new { x.RequestId, x.AnotherOptionId });
                    table.ForeignKey(
                        name: "FK_RequestAnotherOptions_AnotherOptions_AnotherOptionId",
                        column: x => x.AnotherOptionId,
                        principalTable: "AnotherOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestAnotherOptions_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestOptions",
                columns: table => new
                {
                    RequestId = table.Column<long>(type: "INTEGER", nullable: false),
                    OptionId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOptions", x => new { x.RequestId, x.OptionId });
                    table.ForeignKey(
                        name: "FK_RequestOptions_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestOptions_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestPackages",
                columns: table => new
                {
                    RequestId = table.Column<long>(type: "INTEGER", nullable: false),
                    PackageId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestPackages", x => new { x.RequestId, x.PackageId });
                    table.ForeignKey(
                        name: "FK_RequestPackages_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestPackages_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AnotherOptions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "another option 1" },
                    { 2L, "another option 2" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "brand 1" },
                    { 2L, "brand 2" },
                    { 3L, "brand 3" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "City", "Email", "FirstName", "HouseNumber", "LastName", "PostCode", "Street", "Telephone" },
                values: new object[] { 1L, "Ho Chi Minh", "abc@test.com", "Hung", "10", "Pham", "700000", "Pham Hung", "1234567890" });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "option 1" },
                    { 2L, "option 2" },
                    { 3L, "option 3" },
                    { 4L, "option 4" },
                    { 5L, "option 5" },
                    { 6L, "option 6" }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "package 1" },
                    { 2L, "package 2" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "service 1" },
                    { 2L, "service 2" },
                    { 3L, "service 3" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "type 1" },
                    { 2L, "type 2" },
                    { 3L, "type 3" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "BrandId", "CustomerId", "Description", "Note", "ServiceId", "TypeId" },
                values: new object[] { 1L, 1L, 1L, "Description", "Note", 1L, 1L });

            migrationBuilder.InsertData(
                table: "RequestAnotherOptions",
                columns: new[] { "AnotherOptionId", "RequestId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.InsertData(
                table: "RequestOptions",
                columns: new[] { "OptionId", "RequestId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.InsertData(
                table: "RequestPackages",
                columns: new[] { "PackageId", "RequestId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_RequestAnotherOptions_AnotherOptionId",
                table: "RequestAnotherOptions",
                column: "AnotherOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOptions_OptionId",
                table: "RequestOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestPackages_PackageId",
                table: "RequestPackages",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_BrandId",
                table: "Requests",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CustomerId",
                table: "Requests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ServiceId",
                table: "Requests",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_TypeId",
                table: "Requests",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestAnotherOptions");

            migrationBuilder.DropTable(
                name: "RequestOptions");

            migrationBuilder.DropTable(
                name: "RequestPackages");

            migrationBuilder.DropTable(
                name: "AnotherOptions");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
