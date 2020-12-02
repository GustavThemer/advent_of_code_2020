namespace Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string ToIframeUrl(this string url) => $"//aka.ms/ampembed?url={url}";
    }
}