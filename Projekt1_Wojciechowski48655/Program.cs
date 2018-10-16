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
		/*---------------------------------*/
		/* Deklaracja zmiennych globalnych */
		/*---------------------------------*/
		static string tytulProgramu= "ProjektNr1 - funkcje matematyczne";
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
			PoprosWyborFunkcji();

			Console.WriteLine("");
			Console.ReadLine();
		}

		/* Metoda pokazujaca tytul programu */
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
			string menu = "Menu funkcjonalne:\n\n";

			foreach (var z in menu) {
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
		}

		static void PoprosWyborFunkcji() {
			Console.ForegroundColor = ConsoleColor.White;
			foreach (var x in "\nWybierz Funkcje z powyzszych: ") {
				Console.Write(x);
				Thread.Sleep(PredkoscPokazywaniaTekstu);
				
			}
			Console.ReadKey();
		}
	}
}
