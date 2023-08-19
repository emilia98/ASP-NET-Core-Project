using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobListing.Infrastructure.Migrations
{
    public partial class AddDescriptionToUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CompanyProfiles");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "CompanyProfiles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CompanyProfiles");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserProfiles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Companies",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Companies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CompanyProfiles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "CompanyProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CompanyProfiles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
