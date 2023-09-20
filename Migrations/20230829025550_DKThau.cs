using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppMvc.Net.Migrations
{
    public partial class DKThau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DKThaus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhaThau = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    MaST = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NguoiLH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmailLH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FileBaoGia = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BangBaoGia = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    HSKhac = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IDNhaThau = table.Column<int>(type: "int", nullable: true),
                    Ngay = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DKThaus", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DKThaus");
        }
    }
}
