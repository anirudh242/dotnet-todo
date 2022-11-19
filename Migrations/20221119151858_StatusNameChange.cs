using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class StatusNameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Todos",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Todos",
                newName: "status");
        }
    }
}
