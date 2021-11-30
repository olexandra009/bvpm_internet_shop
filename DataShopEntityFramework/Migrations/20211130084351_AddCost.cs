using Microsoft.EntityFrameworkCore.Migrations;

namespace DataShopEntityFramework.Migrations
{
    public partial class AddCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "cost",
                table: "orders",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cost",
                table: "orders");
        }
    }
}
