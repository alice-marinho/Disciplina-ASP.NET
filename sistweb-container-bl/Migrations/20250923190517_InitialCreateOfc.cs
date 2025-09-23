using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistweb_container_bl.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateOfc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Containers_BL_BLId",
                table: "Containers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BL",
                table: "BL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Containers",
                table: "Containers");

            migrationBuilder.RenameTable(
                name: "BL",
                newName: "bl");

            migrationBuilder.RenameTable(
                name: "Containers",
                newName: "container");

            migrationBuilder.RenameColumn(
                name: "Id_bl",
                table: "container",
                newName: "id_bl");

            migrationBuilder.RenameIndex(
                name: "IX_Containers_BLId",
                table: "container",
                newName: "IX_container_BLId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bl",
                table: "bl",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_container",
                table: "container",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_container_bl_BLId",
                table: "container",
                column: "BLId",
                principalTable: "bl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_container_bl_BLId",
                table: "container");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bl",
                table: "bl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_container",
                table: "container");

            migrationBuilder.RenameTable(
                name: "bl",
                newName: "BL");

            migrationBuilder.RenameTable(
                name: "container",
                newName: "Containers");

            migrationBuilder.RenameColumn(
                name: "id_bl",
                table: "Containers",
                newName: "Id_bl");

            migrationBuilder.RenameIndex(
                name: "IX_container_BLId",
                table: "Containers",
                newName: "IX_Containers_BLId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BL",
                table: "BL",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Containers",
                table: "Containers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_BL_BLId",
                table: "Containers",
                column: "BLId",
                principalTable: "BL",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
