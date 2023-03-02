using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;

namespace ParserFreedom.Extensions
{
    public static class HtmlDocExtension
    {
        /// <summary>
        /// HtmlDocument в HtmlNode
        /// </summary>
        /// <param name="document"></param>
        /// <param name="selector">XPath</param>
        /// <returns>HtmlDocument</returns>
        public static string GetTextBySelector(this HtmlDocument document, string selector)
        {
            return document.DocumentNode.GetTextBySelector(selector);
        }
        /// <summary>
        /// Поиск XPath
        /// </summary>
        /// <param name="node"></param>
        /// <param name="selector">XPath</param>
        /// <returns>HtmlNode</returns>
        public static string GetTextBySelector(this HtmlNode node, string selector)
        {
            return node.SelectNodes(selector).First().GetText();
        }
        /// <summary>
        /// Заберает текст из HtmlNode
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static string GetText(this HtmlNode node)
        {
            return node?.InnerText?.HtmlDecode();
        }
    }
}
