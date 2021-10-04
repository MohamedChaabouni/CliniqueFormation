using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dossiers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _CreatedAt = table.Column<DateTime>(nullable: false),
                    _LastModiedAt = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<string>(nullable: true),
                    NumDossier = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medecins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _CreatedAt = table.Column<DateTime>(nullable: false),
                    _LastModiedAt = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    NumLicence = table.Column<string>(nullable: true),
                    NumAssMaladie = table.Column<string>(nullable: true),
                    DateNaissance = table.Column<DateTime>(nullable: false),
                    Addresse = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medecins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecretaireInfirmieres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _CreatedAt = table.Column<DateTime>(nullable: false),
                    _LastModiedAt = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    DateNaissance = table.Column<DateTime>(nullable: false),
                    NumAssMaladie = table.Column<string>(nullable: true),
                    Addresse = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretaireInfirmieres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _CreatedAt = table.Column<DateTime>(nullable: false),
                    _LastModiedAt = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    DossierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Dossiers_DossierId",
                        column: x => x.DossierId,
                        principalTable: "Dossiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _CreatedAt = table.Column<DateTime>(nullable: false),
                    _LastModiedAt = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    DateNaissance = table.Column<DateTime>(nullable: false),
                    NumAssMaladie = table.Column<DateTime>(nullable: false),
                    Addresse = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Telephone = table.Column<string>(nullable: true),
                    Sexe = table.Column<int>(nullable: false),
                    DossierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Dossiers_DossierId",
                        column: x => x.DossierId,
                        principalTable: "Dossiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RendezVous",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _CreatedAt = table.Column<DateTime>(nullable: false),
                    _LastModiedAt = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DossierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RendezVous", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RendezVous_Dossiers_DossierId",
                        column: x => x.DossierId,
                        principalTable: "Dossiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hospitalisations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _CreatedAt = table.Column<DateTime>(nullable: false),
                    _LastModiedAt = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false),
                    MedecinId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitalisations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitalisations_Medecins_MedecinId",
                        column: x => x.MedecinId,
                        principalTable: "Medecins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hospitalisations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecretairePatients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _CreatedAt = table.Column<DateTime>(nullable: false),
                    _LastModiedAt = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<string>(nullable: true),
                    SecretaireInfirmerieId = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretairePatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecretairePatients_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecretairePatients_SecretaireInfirmieres_SecretaireInfirmerieId",
                        column: x => x.SecretaireInfirmerieId,
                        principalTable: "SecretaireInfirmieres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hospitalisers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _CreatedAt = table.Column<DateTime>(nullable: false),
                    _LastModiedAt = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    HeureArrivee = table.Column<DateTime>(nullable: false),
                    HeureDepart = table.Column<DateTime>(nullable: false),
                    MedecinId = table.Column<int>(nullable: false),
                    HospitalisationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitalisers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitalisers_Hospitalisations_HospitalisationId",
                        column: x => x.HospitalisationId,
                        principalTable: "Hospitalisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hospitalisers_Medecins_MedecinId",
                        column: x => x.MedecinId,
                        principalTable: "Medecins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalisations_MedecinId",
                table: "Hospitalisations",
                column: "MedecinId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalisations_PatientId",
                table: "Hospitalisations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalisers_HospitalisationId",
                table: "Hospitalisers",
                column: "HospitalisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalisers_MedecinId",
                table: "Hospitalisers",
                column: "MedecinId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_DossierId",
                table: "Notes",
                column: "DossierId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DossierId",
                table: "Patients",
                column: "DossierId",
                unique: true,
                filter: "[DossierId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_DossierId",
                table: "RendezVous",
                column: "DossierId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretairePatients_PatientId",
                table: "SecretairePatients",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretairePatients_SecretaireInfirmerieId",
                table: "SecretairePatients",
                column: "SecretaireInfirmerieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hospitalisers");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "RendezVous");

            migrationBuilder.DropTable(
                name: "SecretairePatients");

            migrationBuilder.DropTable(
                name: "Hospitalisations");

            migrationBuilder.DropTable(
                name: "SecretaireInfirmieres");

            migrationBuilder.DropTable(
                name: "Medecins");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Dossiers");
        }
    }
}
