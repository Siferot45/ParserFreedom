namespace ParserFreedom.Extensions
{
    public static class UriExtension
    {
        /// <summary>
        /// Обединение Url и название новелы
        /// </summary>
        /// <param name="SystemUri">Базовые Url</param>
        /// <param name="nameNovel">Название новелы</param>
        /// <returns>Url</returns>
        public static Uri UriConcateation(this Uri SystemUri, string nameNovel)
        {
            return new Uri(SystemUri, nameNovel);
        }
    }
}
