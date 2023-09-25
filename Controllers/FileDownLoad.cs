using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using App.Models;
using Microsoft.EntityFrameworkCore;

public class FileDownloadController : Controller
{
    
    private readonly AppDbContext _context;
    public FileDownloadController(AppDbContext context)
        {
            
            _context = context;
        }
    [HttpGet("DownloadFile")]
    public IActionResult DownloadFile(string fileName)
    {

        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "DTCGNT", "PDFs","ZIPs" ,fileName);

            if (System.IO.File.Exists(filePath))
            {
                // Đọc dữ liệu từ file
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

                // Trả về file như là một phản hồi (Response)
                return File(fileBytes, "application/octet-stream", fileName);
            }

        // Nếu file không tồn tại hoặc có lỗi khác, bạn có thể xử lý lỗi hoặc hiển thị thông báo lỗi
        return NotFound(); // Hoặc return BadRequest("File không tồn tại");
    }
    
    
}
