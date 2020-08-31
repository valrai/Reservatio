using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservatio.Migrations
{
    public partial class Fixing_field_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancellationDate",
                table: "NaturalPersonEvent");

            migrationBuilder.DropColumn(
                name: "CancellationDate",
                table: "NaturalPerson");

            migrationBuilder.AddColumn<DateTime>(
                name: "CancelationDate",
                table: "NaturalPersonEvent",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CancelationDate",
                table: "NaturalPerson",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancelationDate",
                table: "NaturalPersonEvent");

            migrationBuilder.DropColumn(
                name: "CancelationDate",
                table: "NaturalPerson");

            migrationBuilder.AddColumn<DateTime>(
                name: "CancellationDate",
                table: "NaturalPersonEvent",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CancellationDate",
                table: "NaturalPerson",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
