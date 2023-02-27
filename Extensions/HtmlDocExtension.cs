using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;

namespace ParserFreedom.Extensions
{
    public static class HtmlDocExtension
    {
        public static string GetTextBySelector(this HtmlDocument document, string selector)
        {
            return document.DocumentNode.GetTextBySelector(selector);
        }
        public static string GetTextBySelector(this HtmlNode node, string selector)
        {
            return node.QuerySelector(selector).GetText();
        }
        public static string GetText(this HtmlNode node)
        {
            return node?.InnerText?.HtmlDecode();
        }
    }
}
