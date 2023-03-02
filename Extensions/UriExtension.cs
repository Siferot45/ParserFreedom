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
        public static Uri UriConcateation(this Uri uri, string nameNovel)
        {
            return new Uri(uri, nameNovel);
        }
        /// <summary>
        /// Добавление ranobe к Url
        /// </summary>
        /// <param name="SystemUri"></param>
        /// <returns></returns>
        public static Uri AddRanode(this Uri uri)
        {
            return new Uri(uri, "ranobe/");
        }public static Uri AddRanod(this Uri uri)
        {
            return new Uri(uri, "/");
        }
    }
}
