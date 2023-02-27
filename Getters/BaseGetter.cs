using ParserFreedom.Configs;
using ParserFreedom.Models;

namespace ParserFreedom.Getters
{
    public abstract class BaseGetter : IDisposable
    {
        protected readonly HttpConfig Config;
        /// <summary>
        /// Базовые Url
        /// </summary>
        public abstract Uri SystemUri { get; }
        public BaseGetter(HttpConfig config)
        {
            Config = config;
        }
        public abstract Task<NovelModel> Get(string rawNonelTitle);

        public void Dispose()
        {
            Config.Dispose();
        }
    }
}
