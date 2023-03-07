using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using ParserFreedom.Configs;
using ParserFreedom.Extensions;
using ParserFreedom.Models;

namespace ParserFreedom.Getters;

public class FreedomGetter : BaseGetter
{
    public override Uri SystemUri => new("https://ifreedom.su/");
    public FreedomGetter(HttpConfig config) :base(config){ }

    public override async Task<NovelModel> Get(string rawNonelTitle)
    {
        Uri uri = new Uri(rawNonelTitle);

        var doc = await Config.Client.GetHtmlDocWithTriesAsync(uri);

        var novel = new NovelModel(uri)
        {
            Title = doc.GetTextBySelector("/html/body/div[1]/main/div/div[2]/div[1]/div[2]/h1"),
            Chapters = await FillChapters(doc, uri)
        };
        return novel;
    }
    private async Task<IEnumerable<ChapterModel>> FillChapters(HtmlDocument document, Uri uri)
    {
        var resalt = new List<ChapterModel>();

        var novelСollection = document.QuerySelectorAll("div.li-col1-ranobe a")
            .Select(a => new UrlChapter(uri.UriConcateation(a.Attributes["href"].Value), a.GetText()))
            .Reverse()
            .ToList();
        foreach (var urlChapter in novelСollection)
        {
            var chapter = new ChapterModel
            {
                Title = urlChapter.Title
            };
            Console.WriteLine($"Загрузка главы {urlChapter.Title}");

            var chapterDoc = await GetChapter(urlChapter.Uri);

            if (chapterDoc != default)
            {
                chapter.Content = chapterDoc.DocumentNode.InnerHtml;
            }
            resalt.Add(chapter);
        }
        return resalt;
    }
    private async Task<HtmlDocument> GetChapter(Uri uri)
    {
        var doc = await Config.Client.GetHtmlDocWithTriesAsync(uri);
        var content = doc.QuerySelector("div.entry-content");
        var notice = content.QuerySelector("div.single-notice");

        return notice?.GetText() == "Для чтения купите главу." ? default : content.InnerHtml.AsHtmlDoc().RemoveNodes("div[class*=adv]");
    }
}

