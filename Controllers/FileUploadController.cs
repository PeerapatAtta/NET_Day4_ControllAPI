using Microsoft.AspNetCore.Mvc;

namespace ControllerAPI2
{
    [ApiController]
    [Route("[controller]")]
    public class FileUploadController : ControllerBase
    {
        //Field:
        private readonly string _uploadsDir;
        //Constructor:
        public FileUploadController()
        {
            //Make directory
            _uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            if (!Directory.Exists(_uploadsDir))
            {
                Directory.CreateDirectory(_uploadsDir);
            }
        }
        //Endpoint: Upload file to directory
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded");
            }

            var filePath = Path.Combine(_uploadsDir, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok(new { file.FileName, file.Length });
        }

    }
}