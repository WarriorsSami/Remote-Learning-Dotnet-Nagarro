using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendingMachine.DataAccess.Migrations
{
    public partial class InitialCreateSaleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sales",
                columns: table =>
                    new
                    {
                        Date = table.Column<DateTime>(
                            type: "timestamp with time zone",
                            nullable: false
                        ),
                        ProductName = table.Column<string>(type: "text", nullable: true),
                        Price = table.Column<decimal>(type: "numeric", nullable: false),
                        PaymentMethod = table.Column<string>(type: "text", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales", x => x.Date);
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "sales");
        }
    }
}
