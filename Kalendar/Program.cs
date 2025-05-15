using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class Program
{
    static void Main()
    {
        List<MyEvent> events = new List<MyEvent>();

        Console.WriteLine("Zadej příkazy (EVENT;název;datum | LIST | STATS | END):");

        while (true)
        {
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            string[] parts = input.Split(';');

            string command = parts[0].Trim().ToUpper();

            if (command == "END")
                break;

            if (command == "EVENT")
            {
                if (parts.Length != 3)
                {
                    Console.WriteLine("Neplatný formát. Použij: EVENT;název;YYYY-MM-DD");
                    continue;
                }

                string name = parts[1].Trim();
                string dateString = parts[2].Trim();

                if (DateTime.TryParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    events.Add(new  MyEvent(name, date));
                    Console.WriteLine("Událost přidána.");
                }
                else
                {
                    Console.WriteLine("Neplatné datum. Použij formát YYYY-MM-DD.");
                }
            }
            else if (command == "LIST")
            {
                if (events.Count == 0)
                {
                    Console.WriteLine("Žádné události.");
                    continue;
                }

                foreach (var ev in events.OrderBy(e => e.Date))
                {
                    Console.WriteLine(ev.GetInfo());
                }
            }
            else if (command == "STATS")
            {
                if (events.Count == 0)
                {
                    Console.WriteLine("Žádné události.");
                    continue;
                }

                var stats = new Dictionary<DateTime, int>();

                foreach (var ev in events)
                {
                    if (stats.ContainsKey(ev.Date))
                        stats[ev.Date]++;
                    else
                        stats[ev.Date] = 1;
                }

                foreach (var entry in stats.OrderBy(k => k.Key))
                {
                    Console.WriteLine($"Date: {entry.Key:yyyy-MM-dd}: events: {entry.Value}");
                }
            }
            else
            {
                Console.WriteLine("Neznámý příkaz. Použij: EVENT, LIST, STATS nebo END.");
            }
        }

        Console.WriteLine("Program ukončen.");
    }
}
