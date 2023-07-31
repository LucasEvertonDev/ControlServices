using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlServices.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MapUserRoles_Roles_RoleId",
                table: "MapUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_MapUserRoles_Users_UserId",
                table: "MapUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MapUserRoles",
                table: "MapUserRoles");

            migrationBuilder.RenameTable(
                name: "MapUserRoles",
                newName: "UserRolesMapping");

            migrationBuilder.RenameIndex(
                name: "IX_MapUserRoles_RoleId",
                table: "UserRolesMapping",
                newName: "IX_UserRolesMapping_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRolesMapping",
                table: "UserRolesMapping",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRolesMapping_Roles_RoleId",
                table: "UserRolesMapping",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRolesMapping_Users_UserId",
                table: "UserRolesMapping",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRolesMapping_Roles_RoleId",
                table: "UserRolesMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRolesMapping_Users_UserId",
                table: "UserRolesMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRolesMapping",
                table: "UserRolesMapping");

            migrationBuilder.RenameTable(
                name: "UserRolesMapping",
                newName: "MapUserRoles");

            migrationBuilder.RenameIndex(
                name: "IX_UserRolesMapping_RoleId",
                table: "MapUserRoles",
                newName: "IX_MapUserRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MapUserRoles",
                table: "MapUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MapUserRoles_Roles_RoleId",
                table: "MapUserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MapUserRoles_Users_UserId",
                table: "MapUserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
