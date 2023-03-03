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
        }
        return resalt;
    }
}

