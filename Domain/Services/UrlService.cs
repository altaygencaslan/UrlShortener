using UrlShortener.Domain.DTO;
using UrlShortener.Domain.Services.IServices;

namespace UrlShortener.Domain.Services
{
    public class UrlService : IUrlService
    {
        private readonly Dictionary<string, UrlDto> _urlList = new();

        public string ShortUrl(string originalUrl)
        {
            var shortUrl = string.Empty;

            while (string.IsNullOrEmpty(shortUrl) ||
                _urlList.GetValueOrDefault(shortUrl) != null)
            {
                shortUrl = GenerateShortUrl();
            }

            shortUrl += ".lty";
            _urlList[shortUrl] = new UrlDto { Id = Guid.NewGuid().ToString(), Url = originalUrl, ShortUrl = shortUrl };
            return shortUrl;
        }

        public string FindUrl(string shortUrl)
        {
            if (_urlList.TryGetValue(shortUrl, out var link))
            {
                return link.Url;
            }

            return string.Empty;
        }

        private string GenerateShortUrl()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var shortUrl = new char[6];

            var random = new Random();
            shortUrl = new char[6];

            for (int i = 0; i < shortUrl.Length; i++)
            {
                shortUrl[i] = chars[random.Next(chars.Length)];
            }

            return new string(shortUrl);
        }
    }
}
