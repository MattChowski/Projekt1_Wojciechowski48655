/*
 * DO ZROBIENIA:
 * 1. Funkcja B
 * 2. Funkcja C
 * 3. Funkcja D
 * 4. Funkcja E
 * 5. Funkcja F
 * 6. Funkcja G
 * 7. Funkcja H
 * 8. Funkcja I
 */

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
		const int PredkoscPokazywaniaTekstu = 5;
		static ConsoleKeyInfo WybranyKlawisz;

		/*--------------------------------------------*/
		/* konstruktor klasy, ustawia rozmiar konsoli */
		/*--------------------------------------------*/
		Program() {
			Console.SetWindowSize(100, 30);
			Console.SetWindowPosition(0, 0);
		}

		/*------------------------------------------------*/
		/* Metody Interfejsu uzytkownika i inne przydatne */
		/*------------------------------------------------*/
		class MainGUI {

			//pokazanie nazwy programu
			public void PokazNazweProgramu(string tytul) {
				string lines = "";
				for (int x = 0; x < tytul.Length; x++) {
					lines += " ";
				}
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("");
				Console.WriteLine("{0," + ((Console.WindowWidth / 2) + lines.Length / 2) + "}", "|| " + lines + " ||");
				Console.WriteLine("{0," + ((Console.WindowWidth / 2) + tytul.Length / 2) + "}", "|| " + tytul + " ||");
				Console.WriteLine("{0," + ((Console.WindowWidth / 2) + lines.Length / 2) + "}", "|| " + lines + " ||");
				Console.WriteLine("");
				Console.ForegroundColor = ConsoleColor.White;
			}

			//pokazanie listy menu
			public void PokazListeWyborow() {

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

			//pokazanie nazwy obecnej funkcji
			public void PokazNazweFunkcji(string s) {

				foreach (var x in $"Teraz obslugujesz funkcje - ") {
					Console.Write(x);
					Thread.Sleep(PredkoscPokazywaniaTekstu);
				}

				Console.ForegroundColor = ConsoleColor.Blue;
				foreach (var x in s.Skip(3)) {
					Console.Write(x);
					Thread.Sleep(PredkoscPokazywaniaTekstu);
				}
				Console.ForegroundColor = ConsoleColor.White;
			}

			//wylaczenie programu
			public void PokazAutora(string autorProgramu, string numerAlbumu) {
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("");
				Console.WriteLine("{0," + ((Console.WindowWidth / 2) + autorProgramu.Length / 2) + "}", autorProgramu);
				Console.WriteLine("{0," + ((Console.WindowWidth / 2) + numerAlbumu.Length / 2) + "}", numerAlbumu);
				Console.WriteLine("");
				Console.ForegroundColor = ConsoleColor.White;
			}
		}

		/*-----------------------------------------*/
		/* Klasy do wszystkich funkcji w programie */
		/*-----------------------------------------*/
		class FunkcjaA : MainGUI {
			//deklaracja zmiennych klasowych
			private int iloscCiagu;
			private float suma = 0.0f;
			private float wartoscWyrazuCiagu;

			/* deklarowanie ciagu liczbowego */
			public void PodajDlugoscCiagu() {
				Console.Write("\n\n\tPodaj dlugosc ciagu liczbowego: ");

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

				Console.WriteLine();
			}

			/* podawanie wartosci kazdego wyrazu z ciagu liczbowego */
			public void PodajKazdyWyrazCiagu() {
				
				for (int x = 1; x <= iloscCiagu; x++) {
					Console.Write($"\tPodaj wartosc {x}-go wyrazu ciagu liczbowego: ");

					while (!float.TryParse(Console.ReadLine(), out wartoscWyrazuCiagu)) {
						Console.WriteLine($"ERROR - Blad w zapisie {x}-go wyrazu");
						Console.Write("Sproboj ponownie: ");
					}

					//algorytm obliczania sumy
					suma += wartoscWyrazuCiagu;
				}

				Console.WriteLine();
			}

			/* PRZEDSTAW WYNIK KONCOWY CALEJ FUNKCJI */
			public void WynikFunkcji() {

				Console.ForegroundColor = ConsoleColor.Cyan;
				foreach (var x in "WYNIK KONCOWY: ") {
					Console.Write(x);
					Thread.Sleep(PredkoscPokazywaniaTekstu);
				}

				Console.ForegroundColor = ConsoleColor.Yellow;
				foreach (var x in Convert.ToString(suma)) {
					Console.Write(x);
					Thread.Sleep(PredkoscPokazywaniaTekstu);
				}
				Console.ResetColor();

				Console.Write("\n\nNacisnij dowolny klawisz aby wrocic do menu...");
				Console.ReadKey();
				
			}
			
		}

		class FunkcjaB : MainGUI {
			//deklaracja zmiennych klasowych
			private int iloscCiagu;
			private float suma = 1.0f;
			private float wartoscWyrazuCiagu;

			/* deklarowanie ciagu liczbowego */
			public void PodajDlugoscCiagu() {
				Console.Write("\n\n\tPodaj dlugosc ciagu liczbowego: ");

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

				Console.WriteLine();
			}

			/* podawanie wartosci kazdego wyrazu z ciagu liczbowego */
			public void PodajKazdyWyrazCiagu() {

				for (int x = 1; x <= iloscCiagu; x++) {
					Console.Write($"\tPodaj wartosc {x}-go wyrazu ciagu liczbowego: ");

					while (!float.TryParse(Console.ReadLine(), out wartoscWyrazuCiagu)) {
						Console.WriteLine($"ERROR - Blad w zapisie {x}-go wyrazu");
						Console.Write("Sproboj ponownie: ");
					}

					//algorytm obliczania sumy
					suma *= wartoscWyrazuCiagu;
				}

				Console.WriteLine();
			}

			/* PRZEDSTAW WYNIK KONCOWY CALEJ FUNKCJI */
			public void WynikFunkcji() {

				Console.ForegroundColor = ConsoleColor.Cyan;
				foreach (var x in "WYNIK KONCOWY: ") {
					Console.Write(x);
					Thread.Sleep(PredkoscPokazywaniaTekstu);
				}

				Console.ForegroundColor = ConsoleColor.Yellow;
				foreach (var x in Convert.ToString(suma)) {
					Console.Write(x);
					Thread.Sleep(PredkoscPokazywaniaTekstu);
				}
				Console.ResetColor();

				Console.Write("\n\nNacisnij dowolny klawisz aby wrocic do menu...");
				Console.ReadKey();

			}
		}

		class FunkcjaC : MainGUI {

		}

		class FunkcjaD : MainGUI {

		}

		class FunkcjaE : MainGUI {

		}

		class FunkcjaF : MainGUI {

		}

		class FunkcjaG : MainGUI {

		}

		class FunkcjaH : MainGUI {

		}

		class FunkcjaI : MainGUI {

		}

		/*---------------------------------*/
		/* Metoda main, startujaca program */
		/*---------------------------------*/

		static void Main(string[] args) {

			//deklaracja instancji klas
			MainGUI mainGUI = new MainGUI();
			FunkcjaA funkcjaA = new FunkcjaA();
			FunkcjaB funkcjaB = new FunkcjaB();

			//glowna petla powtarzajaca program
			do {
				Console.Clear();

				mainGUI.PokazNazweProgramu(tytulProgramu);
				mainGUI.PokazListeWyborow();

				WybranyKlawisz = Console.ReadKey(true);

				switch (WybranyKlawisz.Key) {
					case ConsoleKey.A:
						Console.Clear();
						mainGUI.PokazNazweProgramu(tytulProgramu);
						mainGUI.PokazNazweFunkcji(ListaWyborow[0]);

						funkcjaA.PodajDlugoscCiagu();
						funkcjaA.PodajKazdyWyrazCiagu();
						funkcjaA.WynikFunkcji();

						break;

					case ConsoleKey.B:
						Console.Clear();
						mainGUI.PokazNazweProgramu(tytulProgramu);
						mainGUI.PokazNazweFunkcji(ListaWyborow[1]);

						funkcjaB.PodajDlugoscCiagu();
						funkcjaB.PodajKazdyWyrazCiagu();
						funkcjaB.WynikFunkcji();
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
						mainGUI.PokazAutora("Mateusz Wojciechowski", "48655");
						Thread.Sleep(5000);
						break;

					default:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine($"\n\nERROR: Nie istnieje funkcja pod klawiszem \"{WybranyKlawisz.Key}\"");
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.Write("Podaj Funkcje jeszcze raz...");
						Console.ResetColor();
						Thread.Sleep(2000);
						break;
				}

			} while (WybranyKlawisz.Key != ConsoleKey.Z);

			Console.WriteLine();

		}
	}
}
