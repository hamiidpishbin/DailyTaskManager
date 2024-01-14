using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyTaskManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSprintTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SprintTask_Sprints_SprintId",
                table: "SprintTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SprintTask",
                table: "SprintTask");

            migrationBuilder.RenameTable(
                name: "SprintTask",
                newName: "SprintTasks");

            migrationBuilder.RenameIndex(
                name: "IX_SprintTask_SprintId",
                table: "SprintTasks",
                newName: "IX_SprintTasks_SprintId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SprintTasks",
                table: "SprintTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SprintTasks_Sprints_SprintId",
                table: "SprintTasks",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SprintTasks_Sprints_SprintId",
                table: "SprintTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SprintTasks",
                table: "SprintTasks");

            migrationBuilder.RenameTable(
                name: "SprintTasks",
                newName: "SprintTask");

            migrationBuilder.RenameIndex(
                name: "IX_SprintTasks_SprintId",
                table: "SprintTask",
                newName: "IX_SprintTask_SprintId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SprintTask",
                table: "SprintTask",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SprintTask_Sprints_SprintId",
                table: "SprintTask",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
