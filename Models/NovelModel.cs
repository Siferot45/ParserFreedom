using ParserFreedom.Extensions;
using ParserFreedom.Login;

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
        public string CurentChapter { get; set; }
        /// <summary>
        /// Latest added chapters
        /// </summary>
        public string LatestAddition { get; set; }
        /// <summary>
        /// Chapter model
        /// </summary>
        public IEnumerable<ChapterModel> Chapters { get; set; } = new List<ChapterModel>();
        /// <summary>
        /// Is the novel finished
        /// </summary>
        public string NovelFinished { get; set; }
        /// <summary>
        /// Uri novel location
        /// </summary>
        public Uri UriBook { get; set; }

        public NovelModel(Uri uri)
        {
            UriBook = uri;
        }
        public NovelModel()
        {
        }
        public async Task Save(BuilderBase builder, string resourcesPath)
        {
            var title = $"{Title}".Crop(100);

            await builder
                .WithNovelUrl(UriBook)
                .WithTitle(title)
                .WithFiles(resourcesPath, "*.ttf")
                .WithFiles(resourcesPath, "*.css")
                .WithChapter(Chapters)
                .Builder(@"D:\ранобе", title);
        }
    }
}
