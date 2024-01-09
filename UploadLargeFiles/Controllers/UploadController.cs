using Microsoft.AspNetCore.Mvc;

namespace UploadLargeFiles.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly ILogger<UploadController> _logger;

        public UploadController(ILogger<UploadController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file)
        {
            var fileName = file.FileName;
            await using (var stream = System.IO.File.Create(fileName))
            {
                await file.CopyToAsync(stream);
            }

            return Ok();
        }
    }
}
