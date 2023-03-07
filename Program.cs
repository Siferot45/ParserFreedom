using ParserFreedom.Configs;
using ParserFreedom.Getters;
using ParserFreedom.Login;
using ParserFreedom.Models;
using ParserFreedom.Prints;
using System.Net;
using System.Reflection;
using System.Text;
using TempFolder;

var cookieContainer = new CookieContainer();

using var handler = new HttpClientHandler
{
    AutomaticDecompression = DecompressionMethods.GZip |
                             DecompressionMethods.Deflate |
                             DecompressionMethods.Brotli,
    ServerCertificateCustomValidationCallback = (_, _, _, _) => true,
    CookieContainer = cookieContainer,
    Proxy = null,
    UseProxy = false
};
using var client = new HttpClient(handler);

using var getterConfig = new HttpConfig(client, cookieContainer, TempFolderFactory.Create());
var novelInfo = new FreedomInfoGetter(getterConfig);
var novelChapter = new FreedomGetter(getterConfig);
var novel = new NovelModel();


Console.WriteLine("Ведите название книги.");
var novelName = Console.ReadLine();

try
{
    var t = await novelInfo.Get(novelName);
    PrintInfoNovel.PrintInfo(t);

    Console.WriteLine("Хотите скачать ранобэ нажмите Y");
    var novelDownload = Console.ReadLine();

    if (novelDownload?.ToLower() == "y")
    {
        var s = await novelChapter.Get(t.UriBook.ToString());
        await s.Save(GetBuilder(), "Patterns");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
static BuilderBase GetBuilder()
{
    return Fb2Builder.Create();
}