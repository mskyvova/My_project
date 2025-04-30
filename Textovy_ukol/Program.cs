using System;

public class Program
{
	public static void Main()
	{
		int padding = 45;
		string text = @"""Hurry up, boy!"" shouted Uncle Vernon from the kitchen. ""What are you
doing, checking for letter bombs?"" He chuckled at his own joke.

Harry went back to the kitchen, still staring at his letter. He handed
Uncle Vernon the bill and the postcard, sat down, and slowly began to
open the yellow envelope.

Uncle Vernon ripped open the bill, snorted in disgust, and flipped over
the postcard.

""Marge's ill,"" he informed Aunt Petunia. ""Ate a funny whelk. --.""

""Dad!"" said Dudley suddenly. ""Dad, Harry's got something!""

Harry was on the point of unfolding his letter, which was written on the
same heavy parchment as the envelope, when it was jerked sharply out of
his hand by Uncle Vernon.

""That's mine!"" said Harry, trying to snatch it back.

""Who'd be writing to you?"" sneered Uncle Vernon, shaking the letter open
with one hand and glancing at it. His face went from red to green faster
than a set of traffic lights. And it didn't stop there. Within seconds
it was the grayish white of old porridge.";

		// 1. Ověření smysluplnosti textu
		bool textMaSmysl = !string.IsNullOrWhiteSpace(text);
		Console.WriteLine("Text dava smysl - ".PadRight(padding) + (textMaSmysl == true));

		// 2. Délka textu
		int delkaTextu = text.Replace("\r", "").Length;
		Console.WriteLine("Delka text je spravna - ".PadRight(padding) + (delkaTextu == 1001));

		// 3. Oddělovač z pomlček
		string oddelovac = new string('-', 20);
		Console.WriteLine("Oddelovac ma 20 pomlcek - ".PadRight(padding) + (oddelovac == "--------------------"));

		// 4. Porovnání jmen bez ohledu na velikost
		string jmeno1 = "Katka";
		string jmeno2 = "katka";
		bool jeStejne = string.Equals(jmeno1, jmeno2, StringComparison.OrdinalIgnoreCase);
		Console.WriteLine("Obe promenne obsahuji stejne jmeno - ".PadRight(padding) + jeStejne);

		// 5. Zmínka o Marge
		bool piseSeOMarge = text.Contains("Marge");
		Console.WriteLine("V textu se zminuje Harryho 'teticka' - ".PadRight(padding) + (piseSeOMarge == true));

		// 6. Interpunkce na konci
		bool jeSpravneUkoncen = ".!?".Contains(text.TrimEnd().Substring(text.TrimEnd().Length - 1));
		Console.WriteLine("Text je spravne ukoncen interpunkci - ".PadRight(padding) + (jeSpravneUkoncen == true));

		// 7. Abecední porovnání
		string blabol1 = "abbc";
		string blabol2 = "acbc";
		string blabol3 = "abbb";
		string prvni = blabol1;
		if (string.Compare(blabol2, prvni) < 0) prvni = blabol2;
		if (string.Compare(blabol3, prvni) < 0) prvni = blabol3;
		Console.WriteLine("Prvni v abecede je blabol3 - ".PadRight(padding) + (prvni == blabol3));

		// 8. První rozkazovací věta (ukončená vykřičníkem)
		string veta = null;
		int start = text.IndexOf("\"Hurry up, boy!\"");
		if (start >= 0)
		{
			veta = text.Substring(start + 1, "Hurry up, boy".Length); // +1 kvůli odstranění úvodní uvozovky
		}
		Console.WriteLine("Prvni rozkazovaci veta je 'Hurry up, boy' - ".PadRight(padding) + (veta == "Hurry up, boy"));

		// 9. Kolikrát se v textu vyskytuje " and " (mezerami obklopené)
		int pocetAnd = 0;
		string textLower = text.ToLower();
		int index = 0;
		while ((index = textLower.IndexOf(" and ", index)) != -1)
		{
			pocetAnd++;
			index += 5; // posun na další výskyt
		}
		Console.WriteLine("Text obsahuje slovo 'and' celkem 5x' - ".PadRight(padding) + (pocetAnd == 5));
	}
}