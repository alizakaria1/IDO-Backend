using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class createFileTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDo_Category_CategoryId",
                table: "ToDo");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_ToDo_CategoryId",
                table: "ToDo");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ToDo");

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ToDo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Status",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.FileId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_FileId",
                table: "User",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_File_FileId",
                table: "User",
                column: "FileId",
                principalTable: "File",
                principalColumn: "FileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_File_FileId",
                table: "User");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropIndex(
                name: "IX_User_FileId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "ToDo");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Status");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ToDo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_CategoryId",
                table: "ToDo",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_Category_CategoryId",
                table: "ToDo",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
