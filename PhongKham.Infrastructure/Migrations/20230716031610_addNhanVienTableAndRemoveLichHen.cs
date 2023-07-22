using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhongKham.Infrastructure.Migrations
{
    public partial class addNhanVienTableAndRemoveLichHen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_phieuKhamBenhs_bacSis_BacSiId",
                table: "phieuKhamBenhs");

            migrationBuilder.DropForeignKey(
                name: "FK_phieuKhamBenhs_lichHens_LichHenId",
                table: "phieuKhamBenhs");

            migrationBuilder.DropTable(
                name: "phieuTiemPhongs");

            migrationBuilder.DropTable(
                name: "phieuTuVans");

            migrationBuilder.DropTable(
                name: "phieuXetNghiems");

            migrationBuilder.DropTable(
                name: "lichHens");

            migrationBuilder.DropIndex(
                name: "IX_phieuKhamBenhs_LichHenId",
                table: "phieuKhamBenhs");

            migrationBuilder.DropColumn(
                name: "TrieuChung",
                table: "phieuKhamBenhs");

            migrationBuilder.RenameColumn(
                name: "LichHenId",
                table: "phieuKhamBenhs",
                newName: "TienKhamBenh");

            migrationBuilder.AlterColumn<int>(
                name: "BacSiId",
                table: "phieuKhamBenhs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BenhNhanId",
                table: "phieuKhamBenhs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NhanVienId",
                table: "phieuKhamBenhs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateTimeHD",
                table: "hoaDons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "benhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenBenh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhieuKhamBenhId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_benhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_benhs_phieuKhamBenhs_PhieuKhamBenhId",
                        column: x => x.PhieuKhamBenhId,
                        principalTable: "phieuKhamBenhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nhanViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sdtNV = table.Column<int>(type: "int", nullable: false),
                    dChiNV = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhanViens", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_phieuKhamBenhs_BenhNhanId",
                table: "phieuKhamBenhs",
                column: "BenhNhanId");

            migrationBuilder.CreateIndex(
                name: "IX_phieuKhamBenhs_NhanVienId",
                table: "phieuKhamBenhs",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_benhs_PhieuKhamBenhId",
                table: "benhs",
                column: "PhieuKhamBenhId");

            migrationBuilder.AddForeignKey(
                name: "FK_phieuKhamBenhs_bacSis_BacSiId",
                table: "phieuKhamBenhs",
                column: "BacSiId",
                principalTable: "bacSis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_phieuKhamBenhs_benhNhans_BenhNhanId",
                table: "phieuKhamBenhs",
                column: "BenhNhanId",
                principalTable: "benhNhans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_phieuKhamBenhs_nhanViens_NhanVienId",
                table: "phieuKhamBenhs",
                column: "NhanVienId",
                principalTable: "nhanViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_phieuKhamBenhs_bacSis_BacSiId",
                table: "phieuKhamBenhs");

            migrationBuilder.DropForeignKey(
                name: "FK_phieuKhamBenhs_benhNhans_BenhNhanId",
                table: "phieuKhamBenhs");

            migrationBuilder.DropForeignKey(
                name: "FK_phieuKhamBenhs_nhanViens_NhanVienId",
                table: "phieuKhamBenhs");

            migrationBuilder.DropTable(
                name: "benhs");

            migrationBuilder.DropTable(
                name: "nhanViens");

            migrationBuilder.DropIndex(
                name: "IX_phieuKhamBenhs_BenhNhanId",
                table: "phieuKhamBenhs");

            migrationBuilder.DropIndex(
                name: "IX_phieuKhamBenhs_NhanVienId",
                table: "phieuKhamBenhs");

            migrationBuilder.DropColumn(
                name: "BenhNhanId",
                table: "phieuKhamBenhs");

            migrationBuilder.DropColumn(
                name: "NhanVienId",
                table: "phieuKhamBenhs");

            migrationBuilder.DropColumn(
                name: "dateTimeHD",
                table: "hoaDons");

            migrationBuilder.RenameColumn(
                name: "TienKhamBenh",
                table: "phieuKhamBenhs",
                newName: "LichHenId");

            migrationBuilder.AlterColumn<int>(
                name: "BacSiId",
                table: "phieuKhamBenhs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrieuChung",
                table: "phieuKhamBenhs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "lichHens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenhNhanId = table.Column<int>(type: "int", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateTimeLichHen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tenBenhNhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tenLichHen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lichHens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lichHens_benhNhans_BenhNhanId",
                        column: x => x.BenhNhanId,
                        principalTable: "benhNhans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "phieuTiemPhongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ghichu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTiemPhong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThanhTien = table.Column<int>(type: "int", nullable: false),
                    dateTimeTiemPhong = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phieuTiemPhongs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "phieuXetNghiems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenXetNghiem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThanhTien = table.Column<int>(type: "int", nullable: false),
                    dateTimeXetNghiem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ketQuaXetNghiem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phieuXetNghiems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "phieuTuVans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTuVan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThanhTien = table.Column<int>(type: "int", nullable: false),
                    dateTimeTuVan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lichHenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phieuTuVans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_phieuTuVans_lichHens_lichHenId",
                        column: x => x.lichHenId,
                        principalTable: "lichHens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_phieuKhamBenhs_LichHenId",
                table: "phieuKhamBenhs",
                column: "LichHenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_lichHens_BenhNhanId",
                table: "lichHens",
                column: "BenhNhanId");

            migrationBuilder.CreateIndex(
                name: "IX_phieuTuVans_lichHenId",
                table: "phieuTuVans",
                column: "lichHenId");

            migrationBuilder.AddForeignKey(
                name: "FK_phieuKhamBenhs_bacSis_BacSiId",
                table: "phieuKhamBenhs",
                column: "BacSiId",
                principalTable: "bacSis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_phieuKhamBenhs_lichHens_LichHenId",
                table: "phieuKhamBenhs",
                column: "LichHenId",
                principalTable: "lichHens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
