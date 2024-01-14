using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyTaskManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSprintTaskQueryFilter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SprintTasks_Sprints_SprintId",
                table: "SprintTasks");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SprintTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_SprintTasks_Sprints_SprintId",
                table: "SprintTasks",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SprintTasks_Sprints_SprintId",
                table: "SprintTasks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SprintTasks");

            migrationBuilder.AddForeignKey(
                name: "FK_SprintTasks_Sprints_SprintId",
                table: "SprintTasks",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
