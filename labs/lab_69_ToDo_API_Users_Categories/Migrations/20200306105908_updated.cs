using Microsoft.EntityFrameworkCore.Migrations;

namespace lab_69_ToDo_API_Users_Categories.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "ToDos",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "ToDoID", "ToDoName", "UserID" },
                values: new object[,]
                {
                    { 1, "Do This", null },
                    { 2, "And do this", null },
                    { 3, "Also do this", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "UserName" },
                values: new object[,]
                {
                    { 1, "Jamie" },
                    { 2, "Karim" },
                    { 3, "Tim" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_UserID",
                table: "ToDos",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Users_UserID",
                table: "ToDos",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Users_UserID",
                table: "ToDos");

            migrationBuilder.DropIndex(
                name: "IX_ToDos_UserID",
                table: "ToDos");

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "ToDoID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "ToDoID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "ToDoID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "ToDos");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
