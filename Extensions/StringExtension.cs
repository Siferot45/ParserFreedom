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
            return Regex.Replace(rawSentence, "[!\"#$%&'()*+,-./—:;<=>?@\\[\\]^_`{|}~]", string.Empty).ToLower();
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
    }
}
