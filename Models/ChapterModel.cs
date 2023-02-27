namespace ParserFreedom.Models
{
    public class ChapterModel
    {
        /// <summary>
        /// Chapter title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Chapter content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Chapter validation check
        /// </summary>
        public bool IsValid => !string.IsNullOrWhiteSpace(Content);
    }
}
