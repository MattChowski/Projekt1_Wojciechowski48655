using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Projekt1_Wojciechowski48655 {

	/*----------------*/
	/* glowny program */
	/*----------------*/
	class Program {

		//konstruktor klasy, ustawia rozmiar konsoli
		static Program() {
			Console.SetWindowSize(100, 30);
		}
		/*-------------------------------------------------------------------*/
		/* Deklaracja zmiennych globalnych, mozna pozmieniac wedlug upodoban */
		/*-------------------------------------------------------------------*/
		static string tytulProgramu = "ProjektNr1 - funkcje matematyczne";
		static string[] ListaWyborow = {
				"A: Obliczenie sumy",
				"B: Obliczenie Iloczynu",
				"C: Obliczenie sredniej arytmetycznej",
				"D: Obliczenie sredniej wazonej",
				"E: Obliczenie ceny jednostki paszy",
				"F: Obliczenie sredniej harmonicznej",
				"G: Obliczenie sredniej geometrycznej",
				"H: Obliczenie sredniej kwadratowej",
				"I: Obliczenie sredniej potegowej",
				"Z: Zakonczenie programu (wyjscie)"
			};
		static int PredkoscPokazywaniaTekstu = 5;
		static ConsoleKeyInfo WybranyKlawisz;

		/*---------------------------------*/
		/* Metoda main, startujaca program */
		/*---------------------------------*/
		static void Main(string[] args) {

			PokazNazweProgramu(tytulProgramu);
			PokazListeWyborow();
			EgzekucjaFunkcji();
			Console.WriteLine();
		}

		/*------------------------------------------------*/
		/* Metody Interfejsu uzytkownika i inne przydatne */
		/*------------------------------------------------*/

		/* Metoda pokazujaca tytul programu z parametrem "s" ktorym jest zmienna "tytulProgramu" */
		static void PokazNazweProgramu(string s) {
			string lines = "";
			for (int x = 0; x < s.Length; x++) {
				lines += " ";
			}
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("");
			Console.WriteLine("{0," + ((Console.WindowWidth / 2) + lines.Length / 2) + "}", "|| " + lines + " ||");
			Console.WriteLine("{0," + ((Console.WindowWidth / 2) + s.Length / 2) + "}", "|| " + s + " ||");
			Console.WriteLine("{0," + ((Console.WindowWidth / 2) + lines.Length / 2) + "}", "|| " + lines + " ||");
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.White;
		}

		/* Metoda pokazujaca menu funkcjonalne programu */
		static void PokazListeWyborow() {

			foreach (var z in "Menu funkcjonalne:\n\n") {
				Console.Write(z);
				Thread.Sleep(PredkoscPokazywaniaTekstu * 5);
			}

			foreach (var x in ListaWyborow) {

				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.Write("\t" + x[0]);
				Console.ForegroundColor = ConsoleColor.Blue;

				foreach (var y in x.Skip(1)) {

					Console.Write(y);
					Thread.Sleep(PredkoscPokazywaniaTekstu);
				}
				Console.WriteLine("");
			}

			Console.ForegroundColor = ConsoleColor.White;
			foreach (var x in "\nWybierz Funkcje z powyzszych...") {
				Console.Write(x);
				Thread.Sleep(PredkoscPokazywaniaTekstu);

			}
		}

		/* Egzekucja wybranej funkcji w zaleznosci od zmiennej "WybranyKlawisz" */
		static void EgzekucjaFunkcji() {
			do 
			{
				WybranyKlawisz = Console.ReadKey();
				switch (WybranyKlawisz.Key) 
				{
					case ConsoleKey.A:
						Console.Clear();
						PokazNazweProgramu(tytulProgramu);
						SumaFunkcjiA();
						break;

					case ConsoleKey.B:
						Console.Clear();
						Console.WriteLine($"Wybrales funkcje: {ListaWyborow[1]}");
						break;

					case ConsoleKey.C:
						Console.Clear();
						Console.WriteLine($"Wybrales funkcje: {ListaWyborow[2]}");
						break;

					case ConsoleKey.D:
						Console.Clear();
						Console.WriteLine($"Wybrales funkcje: {ListaWyborow[3]}");
						break;

					case ConsoleKey.E:
						Console.Clear();
						Console.WriteLine($"Wybrales funkcje: {ListaWyborow[4]}");
						break;

					case ConsoleKey.F:
						Console.Clear();
						Console.WriteLine($"Wybrales funkcje: {ListaWyborow[5]}");
						break;

					case ConsoleKey.G:
						Console.Clear();
						Console.WriteLine($"Wybrales funkcje: {ListaWyborow[6]}");
						break;

					case ConsoleKey.H:
						Console.Clear();
						Console.WriteLine($"Wybrales funkcje: {ListaWyborow[7]}");
						break;

					case ConsoleKey.I:
						Console.Clear();
						Console.WriteLine($"Wybrales funkcje: {ListaWyborow[7]}");
						break;

					case ConsoleKey.Z:
						break;

					default:
						Console.WriteLine($"ERROR: Nie istnieje funkcja pod klawiszem \"{WybranyKlawisz}\"");
						Console.Write("Podaj Funkcje jeszcze raz: ");
						break;
				}
			}
			while (WybranyKlawisz.Key != ConsoleKey.E);
		}

		/*-------------------------------*/
		/* Metody funkcji matematycznych */
		/*-------------------------------*/

		/* A: Obliczenie sumy */
		static void SumaFunkcjiA() {

			//deklaracja zmiennych lokalnych
			int iloscCiagu;
			float suma = 0.0f;
			float wartoscWyrazuCiagu;

			//Pokaz nazwe funkcji obecnie obslugujacej
			foreach (var x in $"Teraz obslugujesz funkcje - ") {
				Console.Write(x);
				Thread.Sleep(PredkoscPokazywaniaTekstu);
			}

			Console.ForegroundColor = ConsoleColor.Blue;
			foreach (var x in $"{ListaWyborow[0]}".Skip(3)) {
				Console.Write(x);
				Thread.Sleep(PredkoscPokazywaniaTekstu);
			}
			Console.ForegroundColor = ConsoleColor.White;

			//Prosba o input
			Console.Write("\n\nPodaj dlugosc ciagu liczbowego: ");

			//sprawdzanie czy wpisany znak jest poprawny i <= 1
			do {
				while (!int.TryParse(Console.ReadLine(), out iloscCiagu)) {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("\nERROR: Wystapil niedozwolony znak, sproboj ponownie");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write("Podaj ponownie licznosc ciagu liczbowego: ");
					Console.ResetColor();
				}

				if (iloscCiagu <= 1) {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("\nERROR: Wartosc N musi byc wieksza od 1");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write("Podaj ponownie licznosc ciagu liczbowego: ");
					Console.ResetColor();
				}

			} while (iloscCiagu <= 1);

			//podawanie wartosci kazdego wyrazu z ciagu liczbowego
			for (int x = 1; x <= iloscCiagu; x++) {
				Console.Write($"Podaj wartosc {x}-go wyrazu ciagu liczbowego: ");

				while (!float.TryParse(Console.ReadLine(), out wartoscWyrazuCiagu)) {
					Console.WriteLine($"ERROR - Blad w zapisie {x}-go wyrazu");
					Console.Write("Sproboj ponownie: ");
				}

				//algorytm obliczania sumy
				suma += wartoscWyrazuCiagu;
			}

			/*---------------------------------------*/
			/* PRZEDSTAW WYNIK KONCOWY CALEJ FUNKCJI */
			/*---------------------------------------*/
			foreach (var x in $"WYNIK KONCOWY: {suma}") {
				Console.Write(x);
				Thread.Sleep(PredkoscPokazywaniaTekstu);
			}
		}
	}
}
