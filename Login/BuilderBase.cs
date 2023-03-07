using ParserFreedom.Models;

namespace ParserFreedom.Login;

public abstract class BuilderBase
{
    public abstract BuilderBase WithTitle(string title);
    public abstract BuilderBase WithNovelUrl(Uri uri);
    public abstract BuilderBase WithFiles(string directory, string searchPatern);
    public abstract BuilderBase WithChapter(IEnumerable<ChapterModel> chapters);
    public abstract string GetFileName(string name);
    public abstract Task BuildInternal(string name);
    public async Task Builder(string directory, string name)
    {
        var fileName = GetFileName(name);
        if (!string.IsNullOrWhiteSpace(directory))
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            fileName = Path.Combine(directory, fileName);
        }
        Console.WriteLine($"Наченаю сохранение книги {fileName}");

        await BuildInternal(fileName);

        Console.WriteLine($"Книга {fileName} сохранена");
    }
}