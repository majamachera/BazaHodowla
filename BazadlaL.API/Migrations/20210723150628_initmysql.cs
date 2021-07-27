using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BazadlaL.API.Migrations
{
    public partial class initmysql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fdog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Imie = table.Column<string>(nullable: true),
                    Plec = table.Column<string>(nullable: true),
                    Rasa = table.Column<string>(nullable: true),
                    Masc = table.Column<string>(nullable: true),
                    DlugoscSiersci = table.Column<string>(nullable: true),
                    Rodowod = table.Column<bool>(nullable: false),
                    DataUrodzenia = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fdog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fdog_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DewormingDog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Preparat = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    FdogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DewormingDog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DewormingDog_Fdog_FdogId",
                        column: x => x.FdogId,
                        principalTable: "Fdog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Puppy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Imie = table.Column<string>(nullable: true),
                    Plec = table.Column<string>(nullable: true),
                    Rasa = table.Column<string>(nullable: true),
                    Masc = table.Column<string>(nullable: true),
                    DlugoscSiersci = table.Column<string>(nullable: true),
                    Rodowod = table.Column<bool>(nullable: false),
                    DataUrodzenia = table.Column<DateTime>(nullable: false),
                    MatkaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puppy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Puppy_Fdog_MatkaId",
                        column: x => x.MatkaId,
                        principalTable: "Fdog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationDog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true),
                    Seria = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Waznosc = table.Column<DateTime>(nullable: false),
                    FdogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationDog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationDog_Fdog_FdogId",
                        column: x => x.FdogId,
                        principalTable: "Fdog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DewormingPuppy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Preparat = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    PuppyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DewormingPuppy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DewormingPuppy_Puppy_PuppyId",
                        column: x => x.PuppyId,
                        principalTable: "Puppy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationPuppy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true),
                    Seria = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Waznosc = table.Column<DateTime>(nullable: false),
                    PuppyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationPuppy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationPuppy_Puppy_PuppyId",
                        column: x => x.PuppyId,
                        principalTable: "Puppy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DewormingDog_FdogId",
                table: "DewormingDog",
                column: "FdogId");

            migrationBuilder.CreateIndex(
                name: "IX_DewormingPuppy_PuppyId",
                table: "DewormingPuppy",
                column: "PuppyId");

            migrationBuilder.CreateIndex(
                name: "IX_Fdog_UserId",
                table: "Fdog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Puppy_MatkaId",
                table: "Puppy",
                column: "MatkaId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationDog_FdogId",
                table: "VaccinationDog",
                column: "FdogId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationPuppy_PuppyId",
                table: "VaccinationPuppy",
                column: "PuppyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DewormingDog");

            migrationBuilder.DropTable(
                name: "DewormingPuppy");

            migrationBuilder.DropTable(
                name: "VaccinationDog");

            migrationBuilder.DropTable(
                name: "VaccinationPuppy");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "Puppy");

            migrationBuilder.DropTable(
                name: "Fdog");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
