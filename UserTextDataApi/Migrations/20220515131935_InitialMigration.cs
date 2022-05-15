using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserTextDataApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Texts",
                columns: table => new
                {
                    textId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    textValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserTextDataWrapperId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Texts", x => x.textId);
                    table.ForeignKey(
                        name: "FK_Texts_UserData_UserTextDataWrapperId",
                        column: x => x.UserTextDataWrapperId,
                        principalTable: "UserData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Texts_UserTextDataWrapperId",
                table: "Texts",
                column: "UserTextDataWrapperId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Texts");

            migrationBuilder.DropTable(
                name: "UserData");
        }
    }
}
