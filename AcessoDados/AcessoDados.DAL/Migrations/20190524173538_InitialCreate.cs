using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessoDados.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioCriacao = table.Column<string>(maxLength: 255, nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    FlagExcluido = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Responsavel",
                columns: table => new
                {
                    IdResponsavel = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioCriacao = table.Column<string>(maxLength: 255, nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    FlagExcluido = table.Column<bool>(nullable: false),
                    Nome = table.Column<int>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsavel", x => x.IdResponsavel);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    IdVideo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioCriacao = table.Column<string>(maxLength: 255, nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    FlagExcluido = table.Column<bool>(nullable: false),
                    Titulo = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Url = table.Column<string>(maxLength: 255, nullable: false),
                    IdadeMinima = table.Column<int>(nullable: true),
                    IdResponsavel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.IdVideo);
                    table.ForeignKey(
                        name: "FK_Video_Responsavel_IdResponsavel",
                        column: x => x.IdResponsavel,
                        principalTable: "Responsavel",
                        principalColumn: "IdResponsavel",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoCategoria",
                columns: table => new
                {
                    IdVideoCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioCriacao = table.Column<string>(maxLength: 255, nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    FlagExcluido = table.Column<bool>(nullable: false),
                    IdCategoria = table.Column<int>(nullable: false),
                    IdVideo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCategoria", x => x.IdVideoCategoria);
                    table.ForeignKey(
                        name: "FK_VideoCategoria_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VideoCategoria_Video_IdVideo",
                        column: x => x.IdVideo,
                        principalTable: "Video",
                        principalColumn: "IdVideo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Video_IdResponsavel",
                table: "Video",
                column: "IdResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_VIDEO_IDADE",
                table: "Video",
                column: "IdadeMinima");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCategoria_IdCategoria",
                table: "VideoCategoria",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCategoria_IdVideo",
                table: "VideoCategoria",
                column: "IdVideo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoCategoria");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Responsavel");
        }
    }
}
