using ParserFreedom.Extensions;
using ParserFreedom.Getters;

namespace ParserFreedom.Translitters;

public class Translitter
{
    private List<TranslitSymbol> TranslitSymbols { get; set; }


    /// <summary>
    /// ����� �������������� �������� ������
    /// </summary>
    /// <param name="source">�������� ������ �� �������</param>
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
    // ����������� - ��� �������� ��������� ����������� �������������
    public  Translitter()
    {
        this.TranslitSymbols = new List<TranslitSymbol>();
        var iso = "�:a,�:b,�:v,�:g,�:d,�:e,�:yo,�:zh,�:z,�:i,�:j,�:k,�:l,�:m,�:n,�:o,�:p,�:r,�:s,�:t,�:u,�:f,�:h,�:c,�:ch,�:sh,�:shh,�:\",�:y,�:,�:e,�:ju,�:ya";

        // ��������� ������������� �� ISO
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
