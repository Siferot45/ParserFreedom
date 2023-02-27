namespace ParserFreedom.Models
{
    public class NovelModel
    {
        /// <summary>
        /// Novel title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Number of chapters
        /// </summary>
        public int CurentChapter { get; set; }
        /// <summary>
        /// Chapter model
        /// </summary>
        public IEnumerable<ChapterModel> Chapters { get; set; } = new List<ChapterModel>();
        /// <summary>
        /// Is the novel finished
        /// </summary>
        public bool NovelFinished { get; set; }
        /// <summary>
        /// Uri novel location
        /// </summary>
        public Uri UriBook { get; set; }
        public NovelModel(Uri uri)
        {
            UriBook = uri;
        }

    }
}
