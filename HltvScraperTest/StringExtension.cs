namespace HltvScraperTest
{
    public static class StringExtension
    {
        public static string Replacify(this string text)
        {
            return text
                .Replace("Group stage", string.Empty)
                .Replace("Grand final (Bo5)", string.Empty)
                .Replace(" + Grand final", string.Empty)
                .Replace("Semi-finals", string.Empty);
        }
    }
}