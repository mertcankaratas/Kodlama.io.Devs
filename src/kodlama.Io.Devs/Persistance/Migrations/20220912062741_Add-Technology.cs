using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class AddTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrammingLanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Technologies_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Name", "Version" },
                values: new object[,]
                {
                    { 3, "Java", "18" },
                    { 4, "Javascript", "ES6" }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId", "Version" },
                values: new object[,]
                {
                    { 1, "Django", 1, "4.1.1" },
                    { 2, "WPF", 2, "4.6" }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId", "Version" },
                values: new object[] { 3, "Spring", 3, "5.3.22" });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId", "Version" },
                values: new object[] { 4, "React", 4, "18.2.0" });

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_ProgrammingLanguageId",
                table: "Technologies",
                column: "ProgrammingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
