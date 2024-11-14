namespace UrlShortener.Domain.Services.IServices
{
    public interface IUrlService
    {
        string ShortUrl(string url);
        string FindUrl(string shortUrl);
    }
}
