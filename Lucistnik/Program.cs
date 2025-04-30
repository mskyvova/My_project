using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Zadej jméno lučištníka: ");
        string jmeno = Console.ReadLine();
        Lucistnik lucistnik = new Lucistnik(jmeno, 5); // výchozí počet šípů

        while (true)
        {
            lucistnik.ZobrazStav();

            Console.WriteLine("\nMenu:");
            Console.WriteLine("1 - Vystřelit šíp");
            Console.WriteLine("2 - Přidat šípy");
            Console.WriteLine("3 - Konec");

            Console.Write("Zadej volbu: ");
            string volba = Console.ReadLine();

            switch (volba)
            {
                case "1":
                    lucistnik.Vystrel();
                    break;

                case "2":
                    int pocet = NactiCeleCisloZKonzole("Zadej počet šípů k přidání: ");
                    lucistnik.PridejSipy(pocet);
                    break;

                case "3":
                    Console.WriteLine("Program ukončen.");
                    return;

                default:
                    Console.WriteLine("Neplatná volba. Zkus to znovu.");
                    break;
            }
        }
    }

    public static int NactiCeleCisloZKonzole(string vyzva)
    {
        int cislo;
        while (true)
        {
            Console.Write(vyzva);
            string vstup = Console.ReadLine();
            if (int.TryParse(vstup, out cislo) && cislo >= 0)
            {
                return cislo;
            }
            else
            {
                Console.WriteLine("Neplatný vstup. Zadej nezáporné celé číslo.");
            }
        }
    }
}

public class Lucistnik
{
    public string Jmeno { get; private set; }
    public int PocetSipu { get; private set; }

    public Lucistnik(string jmeno, int pocatecniPocetSipu)
    {
        Jmeno = jmeno;
        PocetSipu = pocatecniPocetSipu;
    }

    public void Vystrel()
    {
        if (PocetSipu > 0)
        {
            PocetSipu--;
            Console.WriteLine($"{Jmeno} vystřelil šíp. Zbývá {PocetSipu} šípů.");
        }
        else
        {
            Console.WriteLine($"{Jmeno} nemá žádné šípy!");
        }
    }

    public void PridejSipy(int pocet)
    {
        if (pocet > 0)
        {
            PocetSipu += pocet;
            Console.WriteLine($"{Jmeno} přidal {pocet} šípů. Aktuální počet: {PocetSipu}");
        }
        else
        {
            Console.WriteLine("Nelze přidat záporný nebo nulový počet šípů.");
        }
    }

    public void ZobrazStav()
    {
        Console.WriteLine($"\nLučištník: {Jmeno}, Počet šípů: {PocetSipu}");
    }
}