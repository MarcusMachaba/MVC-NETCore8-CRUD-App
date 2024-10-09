using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.CRUD.Interface.Migrations
{
    /// <inheritdoc />
    public partial class add_dates_cols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "CustomIdentity",
                table: "Clients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "CustomIdentity",
                table: "Clients",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "CustomIdentity",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "CustomIdentity",
                table: "Clients");
        }
    }
}
