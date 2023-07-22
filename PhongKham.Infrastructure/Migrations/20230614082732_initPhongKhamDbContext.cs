using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhongKham.Infrastructure.Migrations
{
    public partial class initPhongKhamDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bacSis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBacSi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bacSis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "benhNhans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBenhNhan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_benhNhans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "thuocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gia = table.Column<double>(type: "float", nullable: false),
                    unitInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thuocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lichHens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTimeLichHen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DichVu = table.Column<int>(type: "int", nullable: false),
                    BenhNhanId = table.Column<int>(type: "int", nullable: true)
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
                name: "phieuKhamBenhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBenh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateTimeKhamBenh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LichHenId = table.Column<int>(type: "int", nullable: false),
                    BacSiId = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phieuKhamBenhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_phieuKhamBenhs_bacSis_BacSiId",
                        column: x => x.BacSiId,
                        principalTable: "bacSis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phieuKhamBenhs_lichHens_LichHenId",
                        column: x => x.LichHenId,
                        principalTable: "lichHens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phieuTiemPhongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTiemPhong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateTimeTiemPhong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LichHenId = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<int>(type: "int", nullable: false),
                    Ghichu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phieuTiemPhongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_phieuTiemPhongs_lichHens_LichHenId",
                        column: x => x.LichHenId,
                        principalTable: "lichHens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phieuTuVans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTuVan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateTimeTuVan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LichHenId = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phieuTuVans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_phieuTuVans_lichHens_LichHenId",
                        column: x => x.LichHenId,
                        principalTable: "lichHens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phieuXetNghiems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenXetNghiem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateTimeXetNghiem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LichHenId = table.Column<int>(type: "int", nullable: false),
                    ketQuaXetNghiem = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phieuXetNghiems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_phieuXetNghiems_lichHens_LichHenId",
                        column: x => x.LichHenId,
                        principalTable: "lichHens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "toaThuocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataTimeToaThuoc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThanhTien = table.Column<double>(type: "float", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhieuKhamBenhId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_toaThuocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_toaThuocs_phieuKhamBenhs_PhieuKhamBenhId",
                        column: x => x.PhieuKhamBenhId,
                        principalTable: "phieuKhamBenhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chiTietToaThuocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToaThuocId = table.Column<int>(type: "int", nullable: false),
                    ThuocId = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietToaThuocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chiTietToaThuocs_thuocs_ThuocId",
                        column: x => x.ThuocId,
                        principalTable: "thuocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietToaThuocs_toaThuocs_ToaThuocId",
                        column: x => x.ToaThuocId,
                        principalTable: "toaThuocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chiTietToaThuocs_ThuocId",
                table: "chiTietToaThuocs",
                column: "ThuocId");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietToaThuocs_ToaThuocId",
                table: "chiTietToaThuocs",
                column: "ToaThuocId");

            migrationBuilder.CreateIndex(
                name: "IX_lichHens_BenhNhanId",
                table: "lichHens",
                column: "BenhNhanId");

            migrationBuilder.CreateIndex(
                name: "IX_phieuKhamBenhs_BacSiId",
                table: "phieuKhamBenhs",
                column: "BacSiId");

            migrationBuilder.CreateIndex(
                name: "IX_phieuKhamBenhs_LichHenId",
                table: "phieuKhamBenhs",
                column: "LichHenId");

            migrationBuilder.CreateIndex(
                name: "IX_phieuTiemPhongs_LichHenId",
                table: "phieuTiemPhongs",
                column: "LichHenId");

            migrationBuilder.CreateIndex(
                name: "IX_phieuTuVans_LichHenId",
                table: "phieuTuVans",
                column: "LichHenId");

            migrationBuilder.CreateIndex(
                name: "IX_phieuXetNghiems_LichHenId",
                table: "phieuXetNghiems",
                column: "LichHenId");

            migrationBuilder.CreateIndex(
                name: "IX_toaThuocs_PhieuKhamBenhId",
                table: "toaThuocs",
                column: "PhieuKhamBenhId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chiTietToaThuocs");

            migrationBuilder.DropTable(
                name: "phieuTiemPhongs");

            migrationBuilder.DropTable(
                name: "phieuTuVans");

            migrationBuilder.DropTable(
                name: "phieuXetNghiems");

            migrationBuilder.DropTable(
                name: "thuocs");

            migrationBuilder.DropTable(
                name: "toaThuocs");

            migrationBuilder.DropTable(
                name: "phieuKhamBenhs");

            migrationBuilder.DropTable(
                name: "bacSis");

            migrationBuilder.DropTable(
                name: "lichHens");

            migrationBuilder.DropTable(
                name: "benhNhans");
        }
    }
}
