using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaFacil.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFullname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "ServiceProviderProfiles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "ServiceProviderProfiles");
        }
    }
}
