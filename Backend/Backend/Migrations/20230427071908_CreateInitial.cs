using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kategoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nev = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__kategori__3213E83FDF7D555F", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recept",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nev = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    kat_id = table.Column<int>(type: "int", nullable: false),
                    kep_eleresi_ut = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    leiras = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__recept__3213E83F8E7CE522", x => x.id);
                    table.ForeignKey(
                        name: "FK__recept__kat_id__267ABA7A",
                        column: x => x.kat_id,
                        principalTable: "kategoria",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_recept_kat_id",
                table: "recept",
                column: "kat_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recept");

            migrationBuilder.DropTable(
                name: "kategoria");
        }
    }
}
