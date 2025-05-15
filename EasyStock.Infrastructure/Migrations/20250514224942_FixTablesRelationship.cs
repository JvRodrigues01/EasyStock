using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyStock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixTablesRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnterpriseId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "PhoneNumer",
                table: "Enterprises",
                newName: "PhoneNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Enterprises",
                newName: "PhoneNumer");

            migrationBuilder.AddColumn<Guid>(
                name: "EnterpriseId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Addresses",
                type: "uuid",
                nullable: true);
        }
    }
}
