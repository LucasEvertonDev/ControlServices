using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlServices.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class IncludeRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.InsertData(
            //    table: "controlservices.aspnetroles",
            //    columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
            //    values: new object[,]
            //    {
            //        { "1", "Administrador", "Admin", null },
            //    });
            migrationBuilder.Sql("INSERT INTO `controlservices`.`aspnetroles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES ('1', 'Administrador', 'admin', null);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM aspnetroles;");
        }
    }
}
