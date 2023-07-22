using Microsoft.EntityFrameworkCore.Migrations;

namespace PhongKham.Infrastructure.Migrations
{
    public partial class ToaThuocId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hoaDons_toaThuocs_ToaThuocId",
                table: "hoaDons");

            migrationBuilder.AlterColumn<int>(
                name: "ToaThuocId",
                table: "hoaDons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "ToaThuocId",
                table: "hoaDons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_hoaDons_toaThuocs_ToaThuocId",
                table: "hoaDons",
                column: "ToaThuocId",
                principalTable: "toaThuocs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
