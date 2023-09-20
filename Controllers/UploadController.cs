using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class FileUploadController : ControllerBase
{
    
    [HttpPost("upload")]
    
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        // You can customize the file upload logic here.
        // For example, save the file to a specific location or perform additional processing.

        // Example: Save the file to the wwwroot/uploads directory
        
        var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "DTCGNT", "PDFs","ZIPs");
        Directory.CreateDirectory(uploadPath);

        var filePath = Path.Combine(uploadPath, file.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Ok(uploadPath + "/" + file.FileName);
    }
    
}