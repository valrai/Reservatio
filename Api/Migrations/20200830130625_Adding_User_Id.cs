using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservatio.Migrations
{
    public partial class Adding_User_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "NaturalPerson",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPerson_UserId",
                table: "NaturalPerson",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NaturalPerson_UserId",
                table: "NaturalPerson");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NaturalPerson");
        }
    }
}
