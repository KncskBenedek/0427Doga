using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class MasodikMigr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__recept__kat_id__267ABA7A",
                table: "recept");

            migrationBuilder.DropPrimaryKey(
                name: "PK__recept__3213E83F8E7CE522",
                table: "recept");

            migrationBuilder.DropPrimaryKey(
                name: "PK__kategori__3213E83FDF7D555F",
                table: "kategoria");

            migrationBuilder.AddColumn<DateTime>(
                name: "datum",
                table: "recept",
                type: "date",
                nullable: false,
                defaultValueSql: "(CONVERT([date],getdate()))");

            migrationBuilder.AddPrimaryKey(
                name: "PK__recept__3213E83F16E05ACB",
                table: "recept",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__kategori__3213E83F91E6844C",
                table: "kategoria",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__recept__kat_id__2C3393D0",
                table: "recept",
                column: "kat_id",
                principalTable: "kategoria",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__recept__kat_id__2C3393D0",
                table: "recept");

            migrationBuilder.DropPrimaryKey(
                name: "PK__recept__3213E83F16E05ACB",
                table: "recept");

            migrationBuilder.DropPrimaryKey(
                name: "PK__kategori__3213E83F91E6844C",
                table: "kategoria");

            migrationBuilder.DropColumn(
                name: "datum",
                table: "recept");

            migrationBuilder.AddPrimaryKey(
                name: "PK__recept__3213E83F8E7CE522",
                table: "recept",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__kategori__3213E83FDF7D555F",
                table: "kategoria",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__recept__kat_id__267ABA7A",
                table: "recept",
                column: "kat_id",
                principalTable: "kategoria",
                principalColumn: "id");
        }
    }
}
