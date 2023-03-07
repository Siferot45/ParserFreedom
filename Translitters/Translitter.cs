using ParserFreedom.Extensions;
using ParserFreedom.Getters;

namespace ParserFreedom.Translitters;

public class Translitter
{
    private List<TranslitSymbol> TranslitSymbols { get; set; }


    /// <summary>
    /// Метод транслитерации русского текста
    /// </summary>
    /// <param name="source">Исходная строка на русском</param>
    /// <returns></returns>
    public string Translit(string source)
    {
        var result = "";

        for (var i = 0; i < source.Length; i++)
        {
            result = result +
                     (TranslitSymbols.FirstOrDefault(x => x.SymbolRus == source[i].ToString()) == null
                ? source[i].ToString()
                : TranslitSymbols.First(x => x.SymbolRus == source[i].ToString()).SymbolEng);
        }
        return result.Trim();
    }
    // Конструктор - При создании заполняем справочники сопоставлений
    public  Translitter()
    {
        this.TranslitSymbols = new List<TranslitSymbol>();
        var iso = "а:a,б:b,в:v,г:g,д:d,е:e,ё:yo,ж:zh,з:z,и:i,й:j,к:k,л:l,м:m,н:n,о:o,п:p,р:r,с:s,т:t,у:u,ф:f,х:h,ц:c,ч:ch,ш:sh,щ:shh,ъ:\",ы:y,ь:,э:e,ю:ju,я:ya";

        // Заполняем сопоставления по ISO
        foreach (string item in iso.Split(","))
        {
            string[] symbols = item.Split(":");
            this.TranslitSymbols.Add(new TranslitSymbol
            {
                SymbolRus = symbols[0].ToLower(),
                SymbolEng = symbols[1].ToLower()
            });
            this.TranslitSymbols.Add(new TranslitSymbol
            {

                SymbolRus = symbols[0].ToUpper(),
                SymbolEng = symbols[1].ToUpper()
            });
        }
    }
}
