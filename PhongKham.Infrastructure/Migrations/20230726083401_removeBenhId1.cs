using Microsoft.EntityFrameworkCore.Migrations;

namespace PhongKham.Infrastructure.Migrations
{
    public partial class removeBenhId1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_phieuKhamBenhs_benhs_BenhId1",
                table: "phieuKhamBenhs");

            migrationBuilder.DropIndex(
                name: "IX_phieuKhamBenhs_BenhId1",
                table: "phieuKhamBenhs");

            migrationBuilder.DropColumn(
                name: "BenhId1",
                table: "phieuKhamBenhs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BenhId1",
                table: "phieuKhamBenhs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_phieuKhamBenhs_BenhId1",
                table: "phieuKhamBenhs",
                column: "BenhId1");

            migrationBuilder.AddForeignKey(
                name: "FK_phieuKhamBenhs_benhs_BenhId1",
                table: "phieuKhamBenhs",
                column: "BenhId1",
                principalTable: "benhs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
