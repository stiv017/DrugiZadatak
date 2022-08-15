using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwagerApi.Data.Migrations
{
    public partial class createdatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_Users",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "Users",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdGrupe",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_Users",
                table: "Users",
                column: "Users",
                principalTable: "Groups",
                principalColumn: "IdGrupe",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdGrupe",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "Users",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_Users",
                table: "Users",
                column: "Users",
                principalTable: "Groups",
                principalColumn: "IdGrupe");
        }
    }
}
