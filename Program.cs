using ParserFreedom.Configs;
using ParserFreedom.Getters;
using ParserFreedom.Models;
using System.Net;


using var client = new HttpClient();
using var getter = new HttpConfig(client);
Console.WriteLine("Ведите название книги.");
var novelName = Console.ReadLine();
try
{
    var i = new FreedomInfoGetter(getter);
    
    i.Get(novelName);
    
}
catch (Exception)
{
    throw;
}




