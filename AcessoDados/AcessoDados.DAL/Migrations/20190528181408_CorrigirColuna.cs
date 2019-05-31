using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessoDados.DAL.Migrations
{
    public partial class CorrigirColuna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Responsavel",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(int),
                oldUnicode: false,
                oldMaxLength: 255);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Nome",
                table: "Responsavel",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 255);
        }
    }
}
