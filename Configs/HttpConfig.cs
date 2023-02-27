namespace ParserFreedom.Configs
{
    public  class HttpConfig : IDisposable
    {
        public HttpClient Client { get; set; }
        public HttpConfig(HttpClient client)
        {
            Client = client;
        }
        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}
