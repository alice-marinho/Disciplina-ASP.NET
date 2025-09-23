using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistweb_container_bl.Migrations
{
    /// <inheritdoc />
    public partial class CorrigirTipoColunaNumero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "numero",
                table: "container",
                type: "char(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(char),
                oldType: "character(1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "numero",
                table: "container",
                type: "character(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(11)",
                oldMaxLength: 11);
        }
    }
}
