using Microsoft.EntityFrameworkCore.Migrations;

namespace PhongKham.Infrastructure.Migrations
{
    public partial class FixSomeIsuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hoaDons_toaThuocs_ToaThuocId",
                table: "hoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_toaThuocs_phieuKhamBenhs_PhieuKhamBenhId",
                table: "toaThuocs");

            migrationBuilder.DropIndex(
                name: "IX_toaThuocs_PhieuKhamBenhId",
                table: "toaThuocs");

            migrationBuilder.DropIndex(
                name: "IX_hoaDons_PhieuKhamBenhId",
                table: "hoaDons");

            migrationBuilder.DropIndex(
                name: "IX_hoaDons_ToaThuocId",
                table: "hoaDons");

            migrationBuilder.AlterColumn<int>(
                name: "PhieuKhamBenhId",
                table: "toaThuocs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ToaThuocId",
                table: "hoaDons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_toaThuocs_PhieuKhamBenhId",
                table: "toaThuocs",
                column: "PhieuKhamBenhId");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_PhieuKhamBenhId",
                table: "hoaDons",
                column: "PhieuKhamBenhId");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_ToaThuocId",
                table: "hoaDons",
                column: "ToaThuocId");

            migrationBuilder.AddForeignKey(
                name: "FK_hoaDons_toaThuocs_ToaThuocId",
                table: "hoaDons",
                column: "ToaThuocId",
                principalTable: "toaThuocs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_toaThuocs_phieuKhamBenhs_PhieuKhamBenhId",
                table: "toaThuocs",
                column: "PhieuKhamBenhId",
                principalTable: "phieuKhamBenhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hoaDons_toaThuocs_ToaThuocId",
                table: "hoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_toaThuocs_phieuKhamBenhs_PhieuKhamBenhId",
                table: "toaThuocs");

            migrationBuilder.DropIndex(
                name: "IX_toaThuocs_PhieuKhamBenhId",
                table: "toaThuocs");

            migrationBuilder.DropIndex(
                name: "IX_hoaDons_PhieuKhamBenhId",
                table: "hoaDons");

            migrationBuilder.DropIndex(
                name: "IX_hoaDons_ToaThuocId",
                table: "hoaDons");

            migrationBuilder.AlterColumn<int>(
                name: "PhieuKhamBenhId",
                table: "toaThuocs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ToaThuocId",
                table: "hoaDons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_toaThuocs_PhieuKhamBenhId",
                table: "toaThuocs",
                column: "PhieuKhamBenhId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_PhieuKhamBenhId",
                table: "hoaDons",
                column: "PhieuKhamBenhId",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_toaThuocs_phieuKhamBenhs_PhieuKhamBenhId",
                table: "toaThuocs",
                column: "PhieuKhamBenhId",
                principalTable: "phieuKhamBenhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
