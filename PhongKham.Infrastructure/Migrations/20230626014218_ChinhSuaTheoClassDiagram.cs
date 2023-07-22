using Microsoft.EntityFrameworkCore.Migrations;

namespace PhongKham.Infrastructure.Migrations
{
    public partial class ChinhSuaTheoClassDiagram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_phieuTiemPhongs_lichHens_LichHenId",
                table: "phieuTiemPhongs");

            migrationBuilder.DropForeignKey(
                name: "FK_phieuTuVans_lichHens_LichHenId",
                table: "phieuTuVans");

            migrationBuilder.DropForeignKey(
                name: "FK_phieuXetNghiems_lichHens_LichHenId",
                table: "phieuXetNghiems");

            migrationBuilder.DropIndex(
                name: "IX_phieuXetNghiems_LichHenId",
                table: "phieuXetNghiems");

            migrationBuilder.DropIndex(
                name: "IX_phieuTiemPhongs_LichHenId",
                table: "phieuTiemPhongs");

            migrationBuilder.DropIndex(
                name: "IX_phieuKhamBenhs_LichHenId",
                table: "phieuKhamBenhs");

            migrationBuilder.DropColumn(
                name: "ThanhTien",
                table: "toaThuocs");

            migrationBuilder.DropColumn(
                name: "Gia",
                table: "thuocs");

            migrationBuilder.DropColumn(
                name: "LichHenId",
                table: "phieuXetNghiems");

            migrationBuilder.DropColumn(
                name: "LichHenId",
                table: "phieuTiemPhongs");

            migrationBuilder.DropColumn(
                name: "ThanhTien",
                table: "phieuKhamBenhs");

            migrationBuilder.DropColumn(
                name: "DichVu",
                table: "lichHens");

            migrationBuilder.RenameColumn(
                name: "unitInStock",
                table: "thuocs",
                newName: "donVi");

            migrationBuilder.RenameColumn(
                name: "LichHenId",
                table: "phieuTuVans",
                newName: "lichHenId");

            migrationBuilder.RenameIndex(
                name: "IX_phieuTuVans_LichHenId",
                table: "phieuTuVans",
                newName: "IX_phieuTuVans_lichHenId");

            migrationBuilder.RenameColumn(
                name: "TenBenh",
                table: "phieuKhamBenhs",
                newName: "TrieuChung");

            migrationBuilder.RenameColumn(
                name: "tenBenhNha",
                table: "lichHens",
                newName: "tenBenhNhan");

            migrationBuilder.AddColumn<int>(
                name: "TongTienThuoc",
                table: "toaThuocs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DonGia",
                table: "thuocs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cachDung",
                table: "thuocs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "lichHenId",
                table: "phieuTuVans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TenTiemPhong",
                table: "phieuTiemPhongs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Ghichu",
                table: "phieuTiemPhongs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "dChiBN",
                table: "benhNhans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "gioiTinh",
                table: "benhNhans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "sdtBN",
                table: "benhNhans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "diaChiBS",
                table: "bacSis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "sdtBS",
                table: "bacSis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "hoaDons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhieuKhamBenhId = table.Column<int>(type: "int", nullable: false),
                    TongThanhToan = table.Column<int>(type: "int", nullable: false),
                    BenhNhanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hoaDons_benhNhans_BenhNhanId",
                        column: x => x.BenhNhanId,
                        principalTable: "benhNhans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hoaDons_phieuKhamBenhs_PhieuKhamBenhId",
                        column: x => x.PhieuKhamBenhId,
                        principalTable: "phieuKhamBenhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_phieuKhamBenhs_LichHenId",
                table: "phieuKhamBenhs",
                column: "LichHenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_BenhNhanId",
                table: "hoaDons",
                column: "BenhNhanId");

            migrationBuilder.CreateIndex(
                name: "IX_hoaDons_PhieuKhamBenhId",
                table: "hoaDons",
                column: "PhieuKhamBenhId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_phieuTuVans_lichHens_lichHenId",
                table: "phieuTuVans",
                column: "lichHenId",
                principalTable: "lichHens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_phieuTuVans_lichHens_lichHenId",
                table: "phieuTuVans");

            migrationBuilder.DropTable(
                name: "hoaDons");

            migrationBuilder.DropIndex(
                name: "IX_phieuKhamBenhs_LichHenId",
                table: "phieuKhamBenhs");

            migrationBuilder.DropColumn(
                name: "TongTienThuoc",
                table: "toaThuocs");

            migrationBuilder.DropColumn(
                name: "DonGia",
                table: "thuocs");

            migrationBuilder.DropColumn(
                name: "cachDung",
                table: "thuocs");

            migrationBuilder.DropColumn(
                name: "dChiBN",
                table: "benhNhans");

            migrationBuilder.DropColumn(
                name: "gioiTinh",
                table: "benhNhans");

            migrationBuilder.DropColumn(
                name: "sdtBN",
                table: "benhNhans");

            migrationBuilder.DropColumn(
                name: "diaChiBS",
                table: "bacSis");

            migrationBuilder.DropColumn(
                name: "sdtBS",
                table: "bacSis");

            migrationBuilder.RenameColumn(
                name: "donVi",
                table: "thuocs",
                newName: "unitInStock");

            migrationBuilder.RenameColumn(
                name: "lichHenId",
                table: "phieuTuVans",
                newName: "LichHenId");

            migrationBuilder.RenameIndex(
                name: "IX_phieuTuVans_lichHenId",
                table: "phieuTuVans",
                newName: "IX_phieuTuVans_LichHenId");

            migrationBuilder.RenameColumn(
                name: "TrieuChung",
                table: "phieuKhamBenhs",
                newName: "TenBenh");

            migrationBuilder.RenameColumn(
                name: "tenBenhNhan",
                table: "lichHens",
                newName: "tenBenhNha");

            migrationBuilder.AddColumn<double>(
                name: "ThanhTien",
                table: "toaThuocs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Gia",
                table: "thuocs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "LichHenId",
                table: "phieuXetNghiems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "LichHenId",
                table: "phieuTuVans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenTiemPhong",
                table: "phieuTiemPhongs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ghichu",
                table: "phieuTiemPhongs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LichHenId",
                table: "phieuTiemPhongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThanhTien",
                table: "phieuKhamBenhs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DichVu",
                table: "lichHens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_phieuXetNghiems_LichHenId",
                table: "phieuXetNghiems",
                column: "LichHenId");

            migrationBuilder.CreateIndex(
                name: "IX_phieuTiemPhongs_LichHenId",
                table: "phieuTiemPhongs",
                column: "LichHenId");

            migrationBuilder.CreateIndex(
                name: "IX_phieuKhamBenhs_LichHenId",
                table: "phieuKhamBenhs",
                column: "LichHenId");

            migrationBuilder.AddForeignKey(
                name: "FK_phieuTiemPhongs_lichHens_LichHenId",
                table: "phieuTiemPhongs",
                column: "LichHenId",
                principalTable: "lichHens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_phieuTuVans_lichHens_LichHenId",
                table: "phieuTuVans",
                column: "LichHenId",
                principalTable: "lichHens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_phieuXetNghiems_lichHens_LichHenId",
                table: "phieuXetNghiems",
                column: "LichHenId",
                principalTable: "lichHens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
