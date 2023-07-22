using Microsoft.EntityFrameworkCore.Migrations;

namespace PhongKham.Infrastructure.Migrations
{
    public partial class FixRelationshipHD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToaThuocId",
                table: "hoaDons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_ToaThuocId",
                table: "hoaDons",
                column: "ToaThuocId",
                unique: true,
                filter: "[ToaThuocId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_hoaDons_toaThuocs_ToaThuocId",
                table: "hoaDons",
                column: "ToaThuocId",
                principalTable: "toaThuocs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hoaDons_toaThuocs_ToaThuocId",
                table: "hoaDons");

            migrationBuilder.DropIndex(
                name: "IX_hoaDons_ToaThuocId",
                table: "hoaDons");

            migrationBuilder.DropColumn(
                name: "ToaThuocId",
                table: "hoaDons");
        }
    }
}
