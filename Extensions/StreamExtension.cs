using HtmlAgilityPack;
using System.Text;

namespace ParserFreedom.Extensions
{
    public static class StreamExtension
    {
        /// <summary>
        /// Конвертация потока байт в HtmlDocument
        /// </summary>
        /// <param name="stream">Поток байт</param>
        /// <param name="encoding"></param>
        /// <returns>HtmlDocument</returns>
        public static HtmlDocument AsHtmlDoc(this Stream stream, Encoding encoding = null)
        {
            var doc = new HtmlDocument();
            doc.Load(stream, encoding ?? Encoding.UTF8);
            return doc;
        }
    }
}
