using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.CRUD.Interface.Migrations
{
    /// <inheritdoc />
    public partial class add_active_col : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "CustomIdentity",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                schema: "CustomIdentity",
                table: "Clients");
        }
    }
}
