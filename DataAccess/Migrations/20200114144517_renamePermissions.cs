using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class renamePermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersPerpissions",
                table: "UsersPerpissions");

            migrationBuilder.RenameTable(
                name: "UsersPerpissions",
                newName: "UsersPermissions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersPermissions",
                table: "UsersPermissions",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersPermissions",
                table: "UsersPermissions");

            migrationBuilder.RenameTable(
                name: "UsersPermissions",
                newName: "UsersPerpissions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersPerpissions",
                table: "UsersPerpissions",
                column: "Id");
        }
    }
}
