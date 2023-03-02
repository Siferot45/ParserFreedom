using HtmlAgilityPack;
using System.Net;
using System.Text;

namespace ParserFreedom.Extensions
{
    public static class HttpClientExtension
    {
        private const int MaxTryCount = 3;
        private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(1);
        private static TimeSpan GetTimeout(TimeSpan errorTimeoout)
        {
            return errorTimeoout == default ? Timeout : errorTimeoout;
        }
        /// <summary>
        /// Get запрос с проверками
        /// </summary>
        /// <param name="client"></param>
        /// <param name="uri"></param>
        /// <param name="errorTimeout"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> GetWithTriesAsync(this HttpClient client, Uri uri,
                                                                             TimeSpan errorTimeout = default)
        {
            for (int i = 0; i < MaxTryCount; i++)
            {
                try
                {
                    var response = await client.GetAsync(uri);

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        await Task.Delay(GetTimeout(errorTimeout));
                        continue;
                    }
                    return response;
                }
                catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
                {
                    ProcessTimeout();
                    await Task.Delay(GetTimeout(errorTimeout));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.Delay(GetTimeout(errorTimeout));
                }
            }
            return default;
        }
        public static void ProcessTimeout()
        {
            Console.WriteLine($"Сервер не успевает ответить");
        }
        /// <summary>
        /// Отправка Get запроса. Преобразование ответа в Html
        /// </summary>
        /// <param name="client"></param>
        /// <param name="uri"></param>
        /// <param name="encoding"></param>
        /// <returns>HtmlDocument</returns>
        public static async Task<HtmlDocument> GetHtmlDocWithTriesAsync(this HttpClient client, Uri uri,
                                                                             Encoding encoding = null)
        {
            using var response = await client.GetWithTriesAsync(uri);
            return await response.Content.ReadAsStreamAsync().ContinueWith(t => t.Result.AsHtmlDoc(encoding));
        }
    }
}
