using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppMvc.Net.Migrations
{
    public partial class ThongTinKhachHang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DT",
                table: "ThongTinNhaThaus",
                newName: "DThoai");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DThoai",
                table: "ThongTinNhaThaus",
                newName: "DT");
        }
    }
}
