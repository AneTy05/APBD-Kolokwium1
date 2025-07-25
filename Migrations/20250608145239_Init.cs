﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kolokwium_s28508.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    TemperatureCelsius = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.ProgramId);
                });

            migrationBuilder.CreateTable(
                name: "Washing_machine",
                columns: table => new
                {
                    WashingMachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxWeight = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Washing_machine", x => x.WashingMachineId);
                });

            migrationBuilder.CreateTable(
                name: "Available_program",
                columns: table => new
                {
                    AvailableProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WashinMachineId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Available_program", x => x.AvailableProgramId);
                    table.ForeignKey(
                        name: "FK_Available_program_Program_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Program",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Available_program_Washing_machine_WashinMachineId",
                        column: x => x.WashinMachineId,
                        principalTable: "Washing_machine",
                        principalColumn: "WashingMachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_History",
                columns: table => new
                {
                    AvailableProgramId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_History", x => new { x.AvailableProgramId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_Purchase_History_Available_program_AvailableProgramId",
                        column: x => x.AvailableProgramId,
                        principalTable: "Available_program",
                        principalColumn: "AvailableProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_History_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Anna", "Nowak", "1111111111" },
                    { 2, "Jane", "Kowalski", "2222222222" }
                });

            migrationBuilder.InsertData(
                table: "Program",
                columns: new[] { "ProgramId", "DurationMinutes", "Name", "TemperatureCelsius" },
                values: new object[,]
                {
                    { 1, 120, "Standard", 30 },
                    { 2, 60, "Delicate", 30 },
                    { 3, 40, "Wool", 20 }
                });

            migrationBuilder.InsertData(
                table: "Washing_machine",
                columns: new[] { "WashingMachineId", "MaxWeight", "SerialNumber" },
                values: new object[,]
                {
                    { 1, 7m, "abc111" },
                    { 2, 6m, "def222" }
                });

            migrationBuilder.InsertData(
                table: "Available_program",
                columns: new[] { "AvailableProgramId", "Price", "ProgramId", "WashinMachineId" },
                values: new object[,]
                {
                    { 1, 10.9899997711182m, 1, 1 },
                    { 2, 15.9899997711182m, 2, 1 },
                    { 3, 100m, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Purchase_History",
                columns: new[] { "AvailableProgramId", "CustomerId", "PurchaseDate", "Rating" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 2, 1, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 2, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Available_program_ProgramId",
                table: "Available_program",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Available_program_WashinMachineId",
                table: "Available_program",
                column: "WashinMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_History_CustomerId",
                table: "Purchase_History",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase_History");

            migrationBuilder.DropTable(
                name: "Available_program");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "Washing_machine");
        }
    }
}
