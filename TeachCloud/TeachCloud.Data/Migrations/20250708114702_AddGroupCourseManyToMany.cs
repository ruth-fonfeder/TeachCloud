using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachCloud.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGroupCourseManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Admins_AdminId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Admins_AdminId",
                table: "Teachers");

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "Teachers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "Groups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Admins_AdminId",
                table: "Groups",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Admins_AdminId",
                table: "Teachers",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Admins_AdminId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Admins_AdminId",
                table: "Teachers");

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Admins_AdminId",
                table: "Groups",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Admins_AdminId",
                table: "Teachers",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
