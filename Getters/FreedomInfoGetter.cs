using HtmlAgilityPack.CssSelectors.NetCore;
using ParserFreedom.Configs;
using ParserFreedom.Extensions;
using ParserFreedom.Models;
using ParserFreedom.Translitters;

namespace ParserFreedom.Getters
{
    public class FreedomInfoGetter : BaseGetter
    {
        public override Uri SystemUri => new("https://ifreedom.su/");
        public FreedomInfoGetter(HttpConfig config) : base(config) { }

        public override async Task<NovelModel> Get(string rawNonelTitle)
        {
             var novelTitle = TitleTranslate(rawNonelTitle);
             var freedomTitle = CastFreedomTitle(novelTitle);

            var addRanobe = SystemUri.AddRanode();
            var url = addRanobe.UriConcateation(freedomTitle);

            await GetMainUrl(url);

            var doc = await Config.Client.GetHtmlDocWithTriesAsync(url);

            var novel = new NovelModel(url)
            {
                Title = doc.GetTextBySelector("/html/body/div[1]/main/div/div[2]/div[1]/div[2]/h1"),
                CurentChapter = doc.GetTextBySelector("(//div[contains(@class,'data-value')])[8]"),
                NovelFinished = doc.GetTextBySelector("/html/body/div[1]/main/div/div[2]/div[1]/div[2]/div[7]/div[2]")
            };
            Console.WriteLine(novel.Title);
            Console.WriteLine(novel.CurentChapter);
            Console.WriteLine(novel.NovelFinished);
            return novel;
        }
        private string TitleTranslate(string rawTitle)
        {
            var titleNovel = new Translitter();
            
            return titleNovel.Translit(rawTitle);
        }
        private string CastFreedomTitle(string novelTitle) 
        { 
            return novelTitle.DashToSpaces().CharacterReplacement().DashSeparation();
        }
        private async Task<Uri> GetMainUrl(Uri uri)
        {
            var doc = await Config.Client.GetHtmlDocWithTriesAsync(uri);
            return uri.UriConcateation(doc.QuerySelector("div.bun2 a").Attributes["href"].Value);
        }
    }
}
