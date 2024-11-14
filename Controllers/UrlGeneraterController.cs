using Microsoft.AspNetCore.Mvc;
using UrlShortener.Domain.Services.IServices;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlGeneraterController : ControllerBase
    {
        private readonly IUrlService _linkService;

        public UrlGeneraterController(IUrlService linkService)
        {
            _linkService = linkService;
        }

        [HttpPost("shorturl")]
        public IActionResult ShortUrl([FromQuery] string url)
        {
            var shortUrl = _linkService.ShortUrl(url);
            return Ok(new { shortUrl });
        }

        [HttpGet("findurl")]
        public IActionResult FindUrl([FromQuery] string shortUrl)
        {
            var url = _linkService.FindUrl(shortUrl);
            if (string.IsNullOrEmpty(url))
                return NotFound();

            return Ok(url);
        }
    }
}
