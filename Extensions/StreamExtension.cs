using HtmlAgilityPack;
using System.Text;

namespace ParserFreedom.Extensions
{
    public static class StreamExtension
    {
        public static HtmlDocument AsHtmlDoc(this Stream stream, Encoding encoding = null)
        {
            var doc = new HtmlDocument();
            doc.Load(stream, encoding ?? Encoding.UTF8);
            return doc;
        }
    }
}
