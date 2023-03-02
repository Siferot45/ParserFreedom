using ParserFreedom.Configs;
using ParserFreedom.Getters;
using ParserFreedom.Models;
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

using var getterConfig = new HttpConfig(client, cookieContainer);

Console.WriteLine("Ведите название книги.");
var novelName = "Сильнейшая Система Убийцы Драконов";

try
{
    var novelInfo = new FreedomInfoGetter(getterConfig);
    var t = await novelInfo.Get(novelName);
    Console.Clear();
    Console.WriteLine($"{t.Title}");
    Console.WriteLine($"\nКоличество глав - {t.CurentChapter}");
    Console.WriteLine($"\n{t.NovelFinished}");
    Console.WriteLine($"\nПоследнее обновление - {t.LatestAddition}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
