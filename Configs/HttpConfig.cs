using System.Net;

namespace ParserFreedom.Configs
{
    public  class HttpConfig : IDisposable
    {
        public HttpClient Client { get; }
        public CookieContainer CookieContainer { get; }
        public HttpConfig(HttpClient client, CookieContainer cookieContainer)
        {
            Client = client;
            CookieContainer = cookieContainer;
        }

        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}
