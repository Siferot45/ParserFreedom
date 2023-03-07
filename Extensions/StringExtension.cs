using HtmlAgilityPack;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace ParserFreedom.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Удаление знаков препенания
        /// </summary>
        /// <param name="rawSentence"></param>
        /// <returns></returns>
        public static string CharacterReplacement(this string rawSentence)
        {
            return Regex.Replace(rawSentence, "[!\"#$%&'()*+«»,-/.—:;<=>?@\\[\\]^_`{|}~]", string.Empty).ToLower();
        }
        /// <summary>
        /// Удаление лишних пробелов
        /// </summary>
        /// <param name="rawSentence"></param>
        /// <returns></returns>
        public static string RemovingSpaces(this string rawSentence)
        {
            return rawSentence.Replace("  ","").RemovingsSpaces();
        }
        /// <summary>
        /// Замена проделов на тере 
        /// </summary>
        /// <param name="rawSentence"></param>
        /// <returns></returns>
        public static string DashSeparation(this string rawSentence)
        {
            return rawSentence.Replace(' ', '-');
        }
        /// <summary>
        /// Замена тире на пробелы
        /// </summary>
        /// <param name="rawSentence"></param>
        /// <returns></returns>
        public static string DashToSpaces(this string rawSentence)
        {
            return rawSentence.Replace('-', ' ').RemovingSpaces();
        }
        /// <summary>
        /// Удаление лишних пробелов
        /// </summary>
        /// <param name="rawSentence"></param>
        /// <returns></returns>
        public static string RemovingsSpaces(this string rawSentence)
        {
            return rawSentence.Replace("   ", "");
        }
        public static string HtmlDecode(this string self)
        {
            var temp = HttpUtility.HtmlDecode(self.Replace("&gt;", "").Replace("&lt;", ""));
            while (temp != self)
            {
                self = temp;
                temp = HttpUtility.HtmlDecode(self.Replace("&gt;", "").Replace("&lt;", ""));
            }

            return self.Trim();
        }
        /// <summary>
        /// Конвертация строки в HtmlDocument
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static HtmlDocument AsHtmlDoc(this string self)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(self.HtmlDecode());
            return doc;
        }
        public static string ReplaceNewLine(this string self)
        {
            return string.IsNullOrWhiteSpace(self) ? self : Regex.Replace(self, "\t|\n", " ").CollapseWhitespace().Trim();
        }
        public static string CleanInvalidXmlChars(this string self)
        {
            return string.IsNullOrWhiteSpace(self) ? self : Regex.Replace(self, "[\x00-\x08\x0B\x0C\x0E-\x1F\x26]", string.Empty, RegexOptions.Compiled);
        }
        public static string CollapseWhitespace(this string self)
        {
            return !string.IsNullOrEmpty(self) ? Regex.Replace(self, @"\s+", " ") : self;
        }
        public static string RemoveInvalidChars(this string self)
        {
            var sb = new StringBuilder(self);
            foreach (var invalidFileNameChar in Path.GetInvalidFileNameChars().Union(new[] { '"' }))
            {
                sb.Replace(invalidFileNameChar, ' ');
            }

            return sb.ToString();
        }
        public static string Crop(this string self, int lenght)
        {
            return self.Length > lenght ? self[..lenght] : self;
        }
    }
}
