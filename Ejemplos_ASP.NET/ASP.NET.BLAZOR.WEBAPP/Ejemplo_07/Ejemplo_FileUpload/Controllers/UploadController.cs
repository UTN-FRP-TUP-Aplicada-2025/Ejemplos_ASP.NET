using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_FileUpload.Controllers;

[ApiController]
[Route("api/upload")]
public class UploadController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> UploadFiles([FromForm] List<IFormFile> files)
    {
        if (files == null || files.Count == 0)
            return BadRequest("No se han enviado archivos.");

        foreach (var file in files)
        {
            var filePath = Path.Combine("Uploads", file.FileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
        }

        return Ok("Archivos subidos correctamente.");
    }
}
