using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservatio.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NaturalPerson",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CancellationDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 200, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Rg = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    SecondaryPhone = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalPerson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExclusionDate = table.Column<DateTime>(nullable: true),
                    TotalValue = table.Column<float>(nullable: false),
                    NumberInstallments = table.Column<ushort>(nullable: false, defaultValue: (ushort)1),
                    Discount = table.Column<double>(nullable: true),
                    Change = table.Column<float>(nullable: false),
                    ValueReceived = table.Column<float>(nullable: false),
                    PaymentType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExclusionDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    StateAbbreviation = table.Column<string>(fixedLength: true, maxLength: 2, nullable: false),
                    Region = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExclusionDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Code = table.Column<long>(nullable: false),
                    StateId = table.Column<long>(nullable: false),
                    StateAbbreviation = table.Column<string>(fixedLength: true, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cep = table.Column<string>(maxLength: 8, nullable: false),
                    StateId = table.Column<long>(nullable: false),
                    CityId = table.Column<long>(nullable: false),
                    District = table.Column<string>(maxLength: 200, nullable: true),
                    Street = table.Column<string>(maxLength: 200, nullable: true),
                    Number = table.Column<ushort>(nullable: true),
                    Complement = table.Column<string>(maxLength: 400, nullable: true),
                    PersonId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_NaturalPerson_PersonId",
                        column: x => x.PersonId,
                        principalTable: "NaturalPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExclusionDate = table.Column<DateTime>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PlaceId = table.Column<long>(nullable: true),
                    PaymentMethodId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Address_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NaturalPersonEvent",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CancellationDate = table.Column<DateTime>(nullable: true),
                    PersonId = table.Column<long>(nullable: false),
                    EventId = table.Column<long>(nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalPersonEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NaturalPersonEvent_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NaturalPersonEvent_NaturalPerson_PersonId",
                        column: x => x.PersonId,
                        principalTable: "NaturalPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_PersonId",
                table: "Address",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateId",
                table: "Address",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_City_Code",
                table: "City",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_PaymentMethodId",
                table: "Event",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_PlaceId",
                table: "Event",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPerson_Cpf",
                table: "NaturalPerson",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPersonEvent_EventId",
                table: "NaturalPersonEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPersonEvent_PersonId",
                table: "NaturalPersonEvent",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_State_StateAbbreviation",
                table: "State",
                column: "StateAbbreviation",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NaturalPersonEvent");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "NaturalPerson");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
