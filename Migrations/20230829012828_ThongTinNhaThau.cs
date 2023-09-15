using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppMvc.Net.Migrations
{
    public partial class ThongTinNhaThau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThongTinNhaThaus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Anh = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Ngay = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MoTa = table.Column<string>(type: "text", nullable: true),
                    TenDA = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    PhanLoai = table.Column<int>(type: "int", nullable: true),
                    DT = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Nam = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    NguoiLienHe = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FilMau = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinNhaThaus", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThongTinNhaThaus");
        }
    }
}
