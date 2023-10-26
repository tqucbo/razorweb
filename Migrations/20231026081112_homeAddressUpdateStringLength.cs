using Microsoft.EntityFrameworkCore.Migrations;

namespace CS0058_Entity_Framework_Razor.Migrations
{
    public partial class homeAddressUpdateStringLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HomeAddress",
                table: "Users",
                type: "NVARCHAR(400)",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HomeAddress",
                table: "Users",
                type: "NVARCHAR",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(400)",
                oldMaxLength: 400,
                oldNullable: true);
        }
    }
}
