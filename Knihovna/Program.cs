using System;

public partial class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var knihovna = new Knihovna();

        while (true)
        {
            string input = Console.ReadLine() ?? "";
            if (input == null) continue;

            var parts = input.Split(';');

            try
            {
                switch (parts[0].ToUpper())
                {
                    case "ADD":
                        if (parts.Length != 5)
                            Console.WriteLine("Neplatný počet argumentů pro ADD.");
                        else
                            knihovna.AddBook(parts[1], parts[2], parts[3], parts[4]);
                        break;

                    case "LIST":
                        foreach (var book in knihovna.ListBooks())
                            Console.WriteLine(book);
                        break;

                    case "STATS":
                        knihovna.ShowStats();
                        break;

                    case "FIND":
                        if (parts.Length < 2)
                            Console.WriteLine("Chybějící klíčové slovo.");
                        else
                        {
                            var results = knihovna.FindBooks(parts[1]);
                            if (!results.Any())
                                Console.WriteLine($"Nebyly nalezeny žádné knihy obsahující \"{parts[1]}\".");
                            else
                            {
                                Console.WriteLine($"Výsledky hledání pro \"{parts[1]}\":");
                                foreach (var b in results)
                                    Console.WriteLine($" - {b.Title}");
                            }
                        }
                        break;

                    case "END":
                        return;

                    default:
                        Console.WriteLine("Neznámý příkaz.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba: {ex.Message}");
            }
        }
    }
}