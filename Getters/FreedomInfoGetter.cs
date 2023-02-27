using ParserFreedom.Configs;
using ParserFreedom.Extensions;
using ParserFreedom.Models;
using ParserFreedom.Translitters;

namespace ParserFreedom.Getters
{
    public class FreedomInfoGetter : BaseGetter
    {
        public override Uri SystemUri => new("https://ifreedom.su/ranobe/");
        public FreedomInfoGetter(HttpConfig config) : base(config) { }

        public override async Task<NovelModel> Get(string rawNonelTitle)
        {
            var novelTitle = TitleTranslate(rawNonelTitle);
            var freedomTitle = CastFreedomTitle(novelTitle);
            var url = SystemUri.UriConcateation(freedomTitle);

            var doc = await Config.Client.GetHtmlDocWithTriesAsunc(url);
            var novel = new NovelModel(url) 
            { 
                Title = doc.GetTextBySelector("h1.entry-title")
              //  CurentChapter,
               // NovelFinished
            };
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
    }
}
