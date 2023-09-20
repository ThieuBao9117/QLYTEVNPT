using Microsoft.AspNetCore.Mvc;
using System.IO;

public class FileDownloadController : Controller
{
    [HttpGet("DownloadFile")]
    public IActionResult DownloadFile(string folderName, string fileName)
    {
        // Đường dẫn tới thư mục chứa file cần tải xuống
        string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", folderName);

        // Đường dẫn đến tệp cần tải xuống
        string filePath = Path.Combine(folderPath, fileName);

        if (System.IO.File.Exists(filePath))
        {
            // Đọc dữ liệu từ file
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            // Trả về file như là một phản hồi (Response)
            return File(fileBytes, "application/octet-stream", fileName);
        }
        else
        {
            // Nếu file không tồn tại, bạn có thể xử lý lỗi tại đây
            return NotFound();
        }
    }
}
