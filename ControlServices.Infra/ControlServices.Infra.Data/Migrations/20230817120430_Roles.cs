using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlServices.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO controlservices..Roles (Id, Name, NormalizedName, ConcurrencyStamp) VALUES ('fd301af2-4459-4a15-9e88-f9d3cf35ac16', 'Administrador', 'ADMINISTRADOR', null);");
            migrationBuilder.Sql("INSERT INTO controlservices..Roles (Id, Name, NormalizedName, ConcurrencyStamp) VALUES ('fd301af2-4459-4a15-9e88-f9d3cf35ac13', 'User', 'User', null);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
    
        }
    }
}
