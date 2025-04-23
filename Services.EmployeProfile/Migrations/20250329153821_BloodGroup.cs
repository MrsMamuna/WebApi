using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.EmployeProfile.Migrations
{
    /// <inheritdoc />
    public partial class BloodGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bg");

            migrationBuilder.RenameTable(
                name: "EmployeeProfile",
                schema: "ep",
                newName: "EmployeeProfile",
                newSchema: "bg");

            migrationBuilder.CreateTable(
                name: "BloodGroup",
                schema: "bg",
                columns: table => new
                {
                    BloodGrpoupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BloodGroupName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodGroup", x => x.BloodGrpoupId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodGroup",
                schema: "bg");

            migrationBuilder.EnsureSchema(
                name: "ep");

            migrationBuilder.RenameTable(
                name: "EmployeeProfile",
                schema: "bg",
                newName: "EmployeeProfile",
                newSchema: "ep");
        }
    }
}
