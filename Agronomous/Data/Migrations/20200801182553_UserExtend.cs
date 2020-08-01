using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agronomous.Data.Migrations
{
    public partial class UserExtend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "plantGuid",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "plantGuid",
                table: "AspNetUsers");
        }
    }
}
