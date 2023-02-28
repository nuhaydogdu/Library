using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    public partial class lastData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_yazarlar_AuthorID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_operasyonlar_Students_StudentID",
                table: "operasyonlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_operasyonlar",
                table: "operasyonlar");

            migrationBuilder.DropIndex(
                name: "IX_operasyonlar_StudentID",
                table: "operasyonlar");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SchoolNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudenID",
                table: "operasyonlar");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "yazarlar",
                newName: "Soyisim");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "varchar(30)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "operasyonlar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "operasyonlar",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_operasyonlar",
                table: "operasyonlar",
                columns: new[] { "StudentID", "BookID" });

            migrationBuilder.CreateTable(
                name: "StudentDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentDetail_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AutherID",
                table: "Books",
                column: "AutherID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetail_StudentID",
                table: "StudentDetail",
                column: "StudentID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_yazarlar_AutherID",
                table: "Books",
                column: "AutherID",
                principalTable: "yazarlar",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_operasyonlar_Students_StudentID",
                table: "operasyonlar",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_yazarlar_AutherID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_operasyonlar_Students_StudentID",
                table: "operasyonlar");

            migrationBuilder.DropTable(
                name: "StudentDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_operasyonlar",
                table: "operasyonlar");

            migrationBuilder.DropIndex(
                name: "IX_Books_AutherID",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Soyisim",
                table: "yazarlar",
                newName: "LastName");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchoolNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "operasyonlar",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "operasyonlar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StudenID",
                table: "operasyonlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_operasyonlar",
                table: "operasyonlar",
                columns: new[] { "StudenID", "BookID" });

            migrationBuilder.CreateIndex(
                name: "IX_operasyonlar_StudentID",
                table: "operasyonlar",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_yazarlar_AuthorID",
                table: "Books",
                column: "AuthorID",
                principalTable: "yazarlar",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_operasyonlar_Students_StudentID",
                table: "operasyonlar",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID");
        }
    }
}
