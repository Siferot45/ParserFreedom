﻿using ParserFreedom.Configs;
using ParserFreedom.Getters;
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

using var getterConfig = new HttpConfig(client, cookieContainer);
var novelInfo = new FreedomInfoGetter(getterConfig);

Console.WriteLine("Ведите название книги.");
var novelName = "Сильнейшая Система Убийцы Драконов";

try
{
    var t = await novelInfo.Get(novelName);
    PrintInfoNovel.PrintInfo(t);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
