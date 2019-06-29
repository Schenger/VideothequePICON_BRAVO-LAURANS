using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Videotheque.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titre = table.Column<string>(nullable: true),
                    Statut = table.Column<int>(nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    Note = table.Column<int>(nullable: false),
                    Commentaire = table.Column<string>(nullable: true),
                    Synopsis = table.Column<string>(nullable: true),
                    AgeMinimum = table.Column<int>(nullable: false),
                    LangueVO = table.Column<int>(nullable: false),
                    LangueMedia = table.Column<int>(nullable: false),
                    SousTitre = table.Column<int>(nullable: false),
                    AudioDescription = table.Column<bool>(nullable: false),
                    SupportPhysique = table.Column<bool>(nullable: false),
                    SupportNumerique = table.Column<bool>(nullable: false),
                    Photo = table.Column<byte[]>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Duree = table.Column<TimeSpan>(nullable: true),
                    Serie_Duree = table.Column<int>(nullable: true),
                    NbSaison = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    EstAmi = table.Column<bool>(nullable: false),
                    Nationalite = table.Column<int>(nullable: false),
                    Civilite = table.Column<int>(nullable: false),
                    Photo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Duree = table.Column<TimeSpan>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    IdMedia = table.Column<int>(nullable: false),
                    DateSortie = table.Column<DateTime>(nullable: false),
                    Saison = table.Column<int>(nullable: false),
                    Synopsis = table.Column<string>(nullable: true),
                    AgeMinimum = table.Column<int>(nullable: false),
                    Statut = table.Column<int>(nullable: false),
                    Note = table.Column<int>(nullable: false),
                    Commentaire = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episode_Media_IdMedia",
                        column: x => x.IdMedia,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaGenre",
                columns: table => new
                {
                    IdMedia = table.Column<int>(nullable: false),
                    IdGenre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaGenre", x => new { x.IdMedia, x.IdGenre });
                    table.ForeignKey(
                        name: "FK_MediaGenre_Genres_IdGenre",
                        column: x => x.IdGenre,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaGenre_Media_IdMedia",
                        column: x => x.IdMedia,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaPersonne",
                columns: table => new
                {
                    IdMedia = table.Column<int>(nullable: false),
                    IdPersonne = table.Column<int>(nullable: false),
                    Fonction = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaPersonne", x => new { x.IdMedia, x.IdPersonne });
                    table.ForeignKey(
                        name: "FK_MediaPersonne_Media_IdMedia",
                        column: x => x.IdMedia,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaPersonne_Personnes_IdPersonne",
                        column: x => x.IdPersonne,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pret",
                columns: table => new
                {
                    IdMedia = table.Column<int>(nullable: false),
                    IdPersonne = table.Column<int>(nullable: false),
                    DatePret = table.Column<DateTime>(nullable: false),
                    DateRetour = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pret", x => new { x.IdMedia, x.IdPersonne });
                    table.ForeignKey(
                        name: "FK_Pret_Media_IdMedia",
                        column: x => x.IdMedia,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pret_Personnes_IdPersonne",
                        column: x => x.IdPersonne,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episode_IdMedia",
                table: "Episode",
                column: "IdMedia");

            migrationBuilder.CreateIndex(
                name: "IX_MediaGenre_IdGenre",
                table: "MediaGenre",
                column: "IdGenre");

            migrationBuilder.CreateIndex(
                name: "IX_MediaPersonne_IdPersonne",
                table: "MediaPersonne",
                column: "IdPersonne");

            migrationBuilder.CreateIndex(
                name: "IX_Pret_IdMedia",
                table: "Pret",
                column: "IdMedia",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pret_IdPersonne",
                table: "Pret",
                column: "IdPersonne");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "MediaGenre");

            migrationBuilder.DropTable(
                name: "MediaPersonne");

            migrationBuilder.DropTable(
                name: "Pret");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Personnes");
        }
    }
}
