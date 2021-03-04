using Microsoft.EntityFrameworkCore.Migrations;

namespace PPayment.Infrastructure.Migrations
{
    public partial class EntityTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "PaymentState",
                newName: "UpdatedAt");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Payments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "PaymentState",
                newName: "UpdateAt");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Payments",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
