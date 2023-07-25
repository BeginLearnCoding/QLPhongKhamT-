using Microsoft.EntityFrameworkCore.Migrations;

namespace PhongKham.Infrastructure.Migrations
{
    public partial class fixRelationshipv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_phieuKhamBenhs_benhs_BenhId",
                table: "phieuKhamBenhs");

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

            migrationBuilder.AlterColumn<string>(
                name: "TenThuoc",
                table: "thuocs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NhanVienId",
                table: "phieuKhamBenhs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BenhNhanId",
                table: "phieuKhamBenhs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BenhId",
                table: "phieuKhamBenhs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BacSiId",
                table: "phieuKhamBenhs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BenhId1",
                table: "phieuKhamBenhs",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "tenBenh",
                table: "benhs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_toaThuocs_PhieuKhamBenhId",
                table: "toaThuocs",
                column: "PhieuKhamBenhId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_phieuKhamBenhs_BenhId1",
                table: "phieuKhamBenhs",
                column: "BenhId1");

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
                name: "FK_phieuKhamBenhs_benhs_BenhId",
                table: "phieuKhamBenhs",
                column: "BenhId",
                principalTable: "benhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_phieuKhamBenhs_benhs_BenhId1",
                table: "phieuKhamBenhs",
                column: "BenhId1",
                principalTable: "benhs",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_phieuKhamBenhs_benhs_BenhId",
                table: "phieuKhamBenhs");

            migrationBuilder.DropForeignKey(
                name: "FK_phieuKhamBenhs_benhs_BenhId1",
                table: "phieuKhamBenhs");

            migrationBuilder.DropForeignKey(
                name: "FK_toaThuocs_phieuKhamBenhs_PhieuKhamBenhId",
                table: "toaThuocs");

            migrationBuilder.DropIndex(
                name: "IX_toaThuocs_PhieuKhamBenhId",
                table: "toaThuocs");

            migrationBuilder.DropIndex(
                name: "IX_phieuKhamBenhs_BenhId1",
                table: "phieuKhamBenhs");

            migrationBuilder.DropIndex(
                name: "IX_hoaDons_PhieuKhamBenhId",
                table: "hoaDons");

            migrationBuilder.DropIndex(
                name: "IX_hoaDons_ToaThuocId",
                table: "hoaDons");

            migrationBuilder.DropColumn(
                name: "BenhId1",
                table: "phieuKhamBenhs");

            migrationBuilder.AlterColumn<int>(
                name: "PhieuKhamBenhId",
                table: "toaThuocs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TenThuoc",
                table: "thuocs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "NhanVienId",
                table: "phieuKhamBenhs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BenhNhanId",
                table: "phieuKhamBenhs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BenhId",
                table: "phieuKhamBenhs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BacSiId",
                table: "phieuKhamBenhs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "tenBenh",
                table: "benhs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                name: "FK_phieuKhamBenhs_benhs_BenhId",
                table: "phieuKhamBenhs",
                column: "BenhId",
                principalTable: "benhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_toaThuocs_phieuKhamBenhs_PhieuKhamBenhId",
                table: "toaThuocs",
                column: "PhieuKhamBenhId",
                principalTable: "phieuKhamBenhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
