using System.Net;

namespace ParserFreedom.Configs
{
    public  class HttpConfig : IDisposable
    {
        public HttpClient Client { get; }
        public CookieContainer CookieContainer { get; }
        public TempFolder.TempFolder TempFolder { get; }
        public HttpConfig(HttpClient client, CookieContainer cookieContainer, TempFolder.TempFolder tempFolder)
        {
            Client = client;
            CookieContainer = cookieContainer;
            TempFolder = tempFolder;
        }

        public void Dispose()
        {
            TempFolder?.Dispose();
            Client?.Dispose();
        }
    }
}
