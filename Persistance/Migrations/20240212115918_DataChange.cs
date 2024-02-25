using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class DataChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "home",
                table: "patient_contacts");

            migrationBuilder.DropColumn(
                name: "office",
                table: "patient_contacts");

            migrationBuilder.DropColumn(
                name: "permanent_address",
                table: "patient_contacts");

            migrationBuilder.DropColumn(
                name: "present_address",
                table: "patient_contacts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "home",
                table: "patient_contacts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "office",
                table: "patient_contacts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "permanent_address",
                table: "patient_contacts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "present_address",
                table: "patient_contacts",
                type: "text",
                nullable: true);
        }
    }
}
