using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Models;
using Microsoft.AspNetCore.Authorization;
using App.Data;
using ThongTinNhaThauModel = App.Models.ThongTinNhaThaus.ThongTinNhaThau;
using DKThauModel = App.Models.DKThaus.DKThau;
using App.Models.ThongTinNhaThaus;
using App.Models.DKThaus;
using System.IO;
namespace App.Areas.ExportToExel.Controllers
{
    [Area("ExportToExcel")]
    
    public class ExportToExelController : Controller
    {
        private readonly AppDbContext _context;

        public ExportToExelController(AppDbContext context)
        {
            _context = context;
        }
        
        public IActionResult ExportToExcel()
        {   
            var data = _context.DKThaus.ToList(); // Thay thế bằng cách lấy dữ liệu từ Model thích hợp
            var stream = new MemoryStream();
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Danh sách nhà thầu");
                worksheet.Cells["A1"].Value = "Tên Nhà Thầu";
                worksheet.Cells["B1"].Value = "Số điện thoại";
                worksheet.Cells["C1"].Value = "Mã Số Thuế";
                worksheet.Cells["D1"].Value = "Người Liên Hệ";
                worksheet.Cells["E1"].Value = "Email";

                // Đặt tiêu đề cho các cột
                using (var range = worksheet.Cells["A1:E1"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                }

                var rowIndex = 2;
                foreach (var item in data)
                {
                    worksheet.Cells["A" + rowIndex].Value = item.TenNhaThau;
                    worksheet.Cells["B" + rowIndex].Value = item.DT;
                    worksheet.Cells["C" + rowIndex].Value = item.MaST;
                    worksheet.Cells["D" + rowIndex].Value = item.NguoiLH;
                    worksheet.Cells["E" + rowIndex].Value = item.EmailLH;
                    rowIndex++;
                }

                package.Save();
            }

                stream.Position = 0;
                string excelName = $"DanhSachNhaThau_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";

            // Trả về một FileResult để tải tệp Excel
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
    }
}
       