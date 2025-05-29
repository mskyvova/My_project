using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Knihovna
{
    private List<Book> books = new List<Book>();

    public void AddBook(string title, string author, string dateString, string pagesString)
    {
        if (!DateTime.TryParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime publishedDate))
            throw new ArgumentException("Neplatný formát data. Použijte YYYY-MM-DD.");

        if (!int.TryParse(pagesString, out int pages) || pages <= 0)
            throw new ArgumentException("Počet stran musí být kladné číslo.");

        books.Add(new Book
        {
            Title = title,
            Author = author,
            PublishedDate = publishedDate,
            Pages = pages
        });
    }

    public IEnumerable<Book> ListBooks()
    {
        return books.OrderBy(b => b.PublishedDate);
    }

    public void ShowStats()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Žádné knihy nejsou k dispozici.");
            return;
        }

        double averagePages = books.Select(b => b.Pages).Average();

        var booksByAuthor = books
            .GroupBy(b => b.Author)
            .Select(g => new { Author = g.Key, Count = g.Count() });

        var uniqueWords = books
            .SelectMany(b => b.Title.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .Select(w => new string(w.Where(char.IsLetterOrDigit).ToArray()).ToLower())
            .Where(w => !string.IsNullOrWhiteSpace(w))
            .Distinct();

        Console.WriteLine();
        Console.WriteLine("Statistiky:");
        Console.WriteLine($"Průměrný počet stran: {(int)averagePages}");
        Console.WriteLine("Počet knih podle autora:");
        foreach (var item in booksByAuthor)
        {
            Console.WriteLine($" - {item.Author}: {item.Count}");
        }
        Console.WriteLine();
        Console.WriteLine($"Počet unikátních slov v názvech knih: {uniqueWords.Count()}");
    }

    public IEnumerable<Book> FindBooks(string keyword)
    {
        keyword = keyword.ToLower();
        return books.Where(b => b.Title.ToLower().Contains(keyword));
    }
}