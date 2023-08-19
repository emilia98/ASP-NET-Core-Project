using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobListing.Infrastructure.Migrations
{
    public partial class UpdateUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "UserProfiles",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "LinkedInUrl",
                table: "UserProfiles",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LogoUrl",
                table: "CompanyProfiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkedInUrl",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "UserProfiles",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LogoUrl",
                table: "CompanyProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
