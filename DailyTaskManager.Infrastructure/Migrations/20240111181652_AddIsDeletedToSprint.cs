﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyTaskManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToSprint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Sprints",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Sprints");
        }
    }
}
