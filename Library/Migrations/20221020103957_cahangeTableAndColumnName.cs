using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    public partial class cahangeTableAndColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Books_BookID",
                table: "Operations");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Students_StudentID",
                table: "Operations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operations",
                table: "Operations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Operations",
                newName: "operasyonlar");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "yazarlar");

            migrationBuilder.RenameIndex(
                name: "IX_Operations_BookID",
                table: "operasyonlar",
                newName: "IX_operasyonlar_BookID");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "yazarlar",
                newName: "İsim");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "operasyonlar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_operasyonlar",
                table: "operasyonlar",
                columns: new[] { "StudenID", "BookID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_yazarlar",
                table: "yazarlar",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_operasyonlar_StudentID",
                table: "operasyonlar",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_yazarlar_AuthorID",
                table: "Books",
                column: "AuthorID",
                principalTable: "yazarlar",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_operasyonlar_Books_BookID",
                table: "operasyonlar",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_operasyonlar_Students_StudentID",
                table: "operasyonlar",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_yazarlar_AuthorID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_operasyonlar_Books_BookID",
                table: "operasyonlar");

            migrationBuilder.DropForeignKey(
                name: "FK_operasyonlar_Students_StudentID",
                table: "operasyonlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_yazarlar",
                table: "yazarlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_operasyonlar",
                table: "operasyonlar");

            migrationBuilder.DropIndex(
                name: "IX_operasyonlar_StudentID",
                table: "operasyonlar");

            migrationBuilder.RenameTable(
                name: "yazarlar",
                newName: "Authors");

            migrationBuilder.RenameTable(
                name: "operasyonlar",
                newName: "Operations");

            migrationBuilder.RenameColumn(
                name: "İsim",
                table: "Authors",
                newName: "FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_operasyonlar_BookID",
                table: "Operations",
                newName: "IX_Operations_BookID");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "Operations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operations",
                table: "Operations",
                columns: new[] { "StudentID", "BookID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Books_BookID",
                table: "Operations",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Students_StudentID",
                table: "Operations",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
