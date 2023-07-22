using Microsoft.EntityFrameworkCore.Migrations;

namespace PhongKham.Infrastructure.Migrations
{
    public partial class PKBhave1Benh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_benhs_phieuKhamBenhs_PhieuKhamBenhId",
                table: "benhs");

            migrationBuilder.DropIndex(
                name: "IX_benhs_PhieuKhamBenhId",
                table: "benhs");

            migrationBuilder.DropColumn(
                name: "PhieuKhamBenhId",
                table: "benhs");

            migrationBuilder.AddColumn<int>(
                name: "BenhId",
                table: "phieuKhamBenhs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_phieuKhamBenhs_BenhId",
                table: "phieuKhamBenhs",
                column: "BenhId");

            migrationBuilder.AddForeignKey(
                name: "FK_phieuKhamBenhs_benhs_BenhId",
                table: "phieuKhamBenhs",
                column: "BenhId",
                principalTable: "benhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_phieuKhamBenhs_benhs_BenhId",
                table: "phieuKhamBenhs");

            migrationBuilder.DropIndex(
                name: "IX_phieuKhamBenhs_BenhId",
                table: "phieuKhamBenhs");

            migrationBuilder.DropColumn(
                name: "BenhId",
                table: "phieuKhamBenhs");

            migrationBuilder.AddColumn<int>(
                name: "PhieuKhamBenhId",
                table: "benhs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_benhs_PhieuKhamBenhId",
                table: "benhs",
                column: "PhieuKhamBenhId");

            migrationBuilder.AddForeignKey(
                name: "FK_benhs_phieuKhamBenhs_PhieuKhamBenhId",
                table: "benhs",
                column: "PhieuKhamBenhId",
                principalTable: "phieuKhamBenhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
