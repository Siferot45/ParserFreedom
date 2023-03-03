using ParserFreedom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserFreedom.Prints
{
    public static class PrintInfoNovel
    {
        public static void PrintInfo(NovelModel novel)
        {
            Console.Clear();
            Console.WriteLine($"{novel.Title}");
            Console.WriteLine($"\nКоличество глав - {novel.CurentChapter}");
            Console.WriteLine($"\n{novel.NovelFinished}");
            Console.WriteLine($"\nПоследнее обновление - {novel.LatestAddition}");
        }
       
    }
}
