using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCustomerStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationCustomer");

            migrationBuilder.DropTable(
                name: "PersonalCustomer");

            migrationBuilder.AddColumn<string>(
                name: "CustomerType",
                table: "Customer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Customer",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReferenceId",
                table: "Customer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaxNumber",
                table: "Customer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerType",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "TaxNumber",
                table: "Customer");

            migrationBuilder.CreateTable(
                name: "OrganizationCustomer",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationCustomer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_OrganizationCustomer_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalCustomer",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalCustomer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_PersonalCustomer_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
