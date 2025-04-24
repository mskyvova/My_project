namespace HelloWorld;
class Program
{
    static void Main(string[] args)
    {


        Console.WriteLine("Obratena Kuna nese nanuk je: " + Reverse.Reversing("Kuna nese nanuk"));

        string[] slova = new string[] { "kajak", "program", "rotor", "Czechitas", "madam", "Jarda", "radar", "nepotopen" };

        Console.WriteLine("Palindromy:");
        foreach (string slovo in slova)
        {
            if (Reverse.JePalindrom(slovo))
            {
                Console.WriteLine(slovo);
            }
        }

        string capsLock = "jAK mICROSOFT wORD POZNA ZAPNUTY cAPSLOCK";

        string opravenyText = Reverse.OpravCapsLock(capsLock);

        Console.WriteLine("Opravený text: " + opravenyText);

        string sifra = "Wzcpsob!qsbdf!.!hsbuvmvkj!b!ktfn!ob!Ufcf!qztoz";

        Console.WriteLine("Dešifrovaná správa:" + Reverse.Desifruj(sifra));

    }
}


// Method that calculates area of rectangle without an instance of class Rectangle
class Rectangle
{
    public static int Calculate(int a, int b)
    {
        return a * b;
    }
}


class Reverse
{
    public static string Reversing(string s)
    {

        // Otočenie znakov pomocou ToCharArray a Array.Reverse
        char[] characters = s.ToCharArray();
        Array.Reverse(characters);

        string reversed = new string(characters);


        return (reversed);
    }

    public static bool JePalindrom(string slovo)
    {
        string lower = slovo.ToLower();
        char[] znaky = lower.ToCharArray();
        Array.Reverse(znaky);
        string otocene = new string(znaky);

        return lower == otocene;
    }

    public static string OpravCapsLock(string text)
    {
        char[] opraveny = new char[text.Length];

        for (int i = 0; i < text.Length; i++)
        {
            char znak = text[i];

            if (char.IsUpper(znak))
                opraveny[i] = char.ToLower(znak);
            else if (char.IsLower(znak))
                opraveny[i] = char.ToUpper(znak);
            else
                opraveny[i] = znak; // nechaj medzery a iné znaky nezmenené
        }

        return new string(opraveny);
    }

    public static string Desifruj(string vstup)
    {
        char[] znaky = vstup.ToCharArray();

        for (int i = 0; i < znaky.Length; i++)
        {
            char znak = znaky[i];

            znaky[i] = (char)(znak - 1);

        }

        return new string(znaky);
    }
}









