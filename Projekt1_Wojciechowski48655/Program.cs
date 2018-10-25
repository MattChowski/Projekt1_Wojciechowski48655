/*
 * DO ZROBIENIA:
 * 4. Funkcja E
 * 8. Funkcja I
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Projekt1_Wojciechowski48655
{

    /*----------------*/
    /* glowny program */
    /*----------------*/
    class Program
    {

        /*-------------------------------------------------------------------*/
        /* Deklaracja zmiennych globalnych, mozna pozmieniac wedlug upodoban */
        /*-------------------------------------------------------------------*/
        static readonly string tytulProgramu = "ProjektNr1 - funkcje matematyczne";
        static readonly string[] ListaWyborow = {
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
		static readonly string wyjscieZFunkcji = "\nNacisnij dowolny klawisz aby wrocic do menu...";
        const int PredkoscPokazywaniaTekstu = 5;
        static ConsoleKeyInfo WybranyKlawisz;

        /*--------------------------------------------*/
        /* konstruktor klasy, ustawia rozmiar konsoli */
        /*--------------------------------------------*/
        Program()
        {
            Console.SetWindowSize(100, 30);
            Console.SetWindowPosition(0, 0);
        }

        /*------------------------------------------------*/
        /* Metody Interfejsu uzytkownika i inne przydatne */
        /*------------------------------------------------*/
        public class MainGUI
        {

            //pokazanie nazwy programu
            public void PokazNazweProgramu(string tytul)
            {
                string lines = "";
                for (int x = 0; x < tytul.Length; x++)
                {
                    lines += " ";
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("");
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (lines.Length / 2)) + "}", "|| " + lines + " ||");
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (tytul.Length / 2)) + "}", "|| " + tytul + " ||");
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (lines.Length / 2)) + "}", "|| " + lines + " ||");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
            }

            //pokazanie listy menu
            public void PokazListeWyborow()
            {

                foreach (var z in "Menu funkcjonalne:\n\n")
                {
                    Console.Write(z);
                    Thread.Sleep(PredkoscPokazywaniaTekstu * 5);
                }

                foreach (var x in ListaWyborow)
                {

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\t" + x[0]);
                    Console.ForegroundColor = ConsoleColor.Blue;

                    foreach (var y in x.Skip(1))
                    {

                        Console.Write(y);
                        Thread.Sleep(PredkoscPokazywaniaTekstu);
                    }
                    Console.WriteLine("");
                }

                Console.ForegroundColor = ConsoleColor.White;
                foreach (var x in "\nWybierz Funkcje z powyzszych...")
                {
                    Console.Write(x);
                    Thread.Sleep(PredkoscPokazywaniaTekstu);

                }
            }

            //pokazanie nazwy obecnej funkcji
            public void PokazNazweFunkcji(string s)
            {

                foreach (var x in $"Teraz obslugujesz funkcje - ")
                {
                    Console.Write(x);
                    Thread.Sleep(PredkoscPokazywaniaTekstu);
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (var x in s.Skip(3))
                {
                    Console.Write(x);
                    Thread.Sleep(PredkoscPokazywaniaTekstu);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }

            //wylaczenie programu
            public void PokazAutora(string autorProgramu, string numerAlbumu)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("");
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (autorProgramu.Length / 2)) + "}", autorProgramu);
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (numerAlbumu.Length / 2)) + "}", numerAlbumu);
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public class WkladListowy
        {

            /// <summary>
            /// Funkcja ktora nam zwraca dlugosc ciagu w formie Array, sprawdza rowniez czy dane sa poprawnie wpisane.
            /// </summary>
            /// <returns>CiagLiczbFloat</returns>
            public float[] PodajDlugoscCiagu()
            {

                //Prosba o wpisanei danych wejsciowych w formie listy oddzielona przecinkiem
                Console.Write("\n\n\tPodaj liczby oddzielając je przecinkiem ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("(i.e.: 1, 2, 3)");
                Console.ResetColor();
                Console.Write(": ");

                string[] CiagLiczbString = Console.ReadLine().Split(',');
                float[] CiagLiczbFloat = new float[CiagLiczbString.Length];
                int i = 0;

                // operacja przeksztalcania listy STRING w liste FLOAT, razem ze sprawdzaniem czy nie ma bledow w zapisie listy STRING
                foreach (string s in CiagLiczbString)
                {
                    while (!float.TryParse(s, out CiagLiczbFloat[i]))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nERROR: Wystapil niedozwolony znak w {i + 1} liczbie ciagu");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"Podaj ponownie {i + 1} cyfre ciagu: ");
                        Console.ResetColor();

                        if (float.TryParse(Console.ReadLine(), out CiagLiczbFloat[i]))
                        {
							Console.WriteLine();
                            break;
                        }
                        else
                        {
                            continue;
                        }

                    }
                    i++;
                }
                return CiagLiczbFloat;
            }

            /// <summary>
            /// Funkcja ktora nam zwraca dlugosc ciagu WAGI w formie Array, sprawdza rowniez czy dane sa poprawnie wpisane.
            /// </summary>
            /// <returns>CiagLiczbFloat</returns>
            public float[] PodajDlugoscWagi()
            {

                //Prosba o wpisanei danych wejsciowych w formie listy oddzielona przecinkiem
                Console.Write("\n\tPodaj wagi oddzielając je przecinkiem ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("(i.e.: 1, 2, 3)");
                Console.ResetColor();
                Console.Write(": ");

                string[] CiagLiczbStringWagi = Console.ReadLine().Split(',');
                float[] CiagLiczbFloatWagi = new float[CiagLiczbStringWagi.Length];

                int i = 0;

                foreach (string s in CiagLiczbStringWagi)
                {
                    while (!float.TryParse(s, out CiagLiczbFloatWagi[i]))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nERROR: Wystapil niedozwolony znak w {i + 1} liczbie ciagu");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"Podaj ponownie {i + 1} cyfre ciagu: ");
                        Console.ResetColor();

                        if (float.TryParse(Console.ReadLine(), out CiagLiczbFloatWagi[i]))
                        {
							Console.WriteLine();
							break;
                        }
                        else
                        {
                            continue;
                        }

                    }
                    i++;
                }

                return CiagLiczbFloatWagi;

            }
        }

        /*-----------------------------------------*/
        /* Klasy do wszystkich funkcji w programie */
        /*-----------------------------------------*/

        /// <summary>
        /// Klasa zawierajaca algorytm do obliczania sumy liczb
        /// </summary>
        public class FunkcjaA
        {

            //deklaracja zmiennych klasowych
            private int iloscCiagu;
            private float suma;
            private float wartoscWyrazuCiagu;

            /* deklarowanie ciagu liczbowego */
            public void PodajDlugoscCiagu()
            {
                Console.Write("\n\n\tPodaj dlugosc ciagu liczbowego: ");

                //sprawdzanie czy wpisany znak jest poprawny i <= 1
                do
                {
                    while (!int.TryParse(Console.ReadLine(), out iloscCiagu))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nERROR: Wystapil niedozwolony znak, sproboj ponownie");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Podaj ponownie licznosc ciagu liczbowego: ");
                        Console.ResetColor();
                    }

                    if (iloscCiagu <= 1)
                    {
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
            public void PodajKazdyWyrazCiagu()
            {

                //resetowanie zmiennych w razie powtorzenia funkcji
                suma = 0.0f;

                //operacja podawania wyrazow ciagu
                for (int x = 1; x <= iloscCiagu; x++)
                {
                    Console.Write($"\tPodaj wartosc {x}-go wyrazu ciagu liczbowego: ");

                    while (!float.TryParse(Console.ReadLine(), out wartoscWyrazuCiagu))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nERROR - Blad w zapisie {x}-go wyrazu");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Sproboj ponownie: ");
                        Console.ResetColor();
                    }

                    //algorytm obliczania sumy
                    suma += wartoscWyrazuCiagu;
                }

                Console.WriteLine();
            }

            /* PRZEDSTAW WYNIK KONCOWY CALEJ FUNKCJI */
            public void WynikFunkcji()
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var x in "WYNIK KONCOWY: ")
                {
                    Console.Write(x);
                    Thread.Sleep(PredkoscPokazywaniaTekstu);
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var x in Convert.ToString(suma))
                {
                    Console.Write(x);
                    Thread.Sleep(PredkoscPokazywaniaTekstu);
                }
                Console.ResetColor();

                Console.Write("\n\nNacisnij dowolny klawisz aby wrocic do menu...");
                Console.ReadKey();

            }

        }

        /// <summary>
        /// Klasa zawierajaca algorytm do obliczania iloczynu
        /// </summary>
        public class FunkcjaB
        {

            //deklaracja zmiennych klasowych
            private int iloscCiagu;
            private float suma;
            private float wartoscWyrazuCiagu;

            /* deklarowanie ciagu liczbowego */
            public void PodajDlugoscCiagu()
            {
                Console.Write("\n\n\tPodaj dlugosc ciagu liczbowego: ");

                //sprawdzanie czy wpisany znak jest poprawny i <= 1
                do
                {
                    while (!int.TryParse(Console.ReadLine(), out iloscCiagu))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nERROR: Wystapil niedozwolony znak, sproboj ponownie");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Podaj ponownie licznosc ciagu liczbowego: ");
                        Console.ResetColor();
                    }

                    if (iloscCiagu <= 1)
                    {
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
            public void PodajKazdyWyrazCiagu()
            {

                //resetowanie zmiennych w razie powtorzenia funkcji
                suma = 1.0f;

                //operacja podawania wyrazow ciagu
                for (int x = 1; x <= iloscCiagu; x++)
                {
                    Console.Write($"\tPodaj wartosc {x}-go wyrazu ciagu liczbowego: ");

                    while (!float.TryParse(Console.ReadLine(), out wartoscWyrazuCiagu))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nERROR - Blad w zapisie {x}-go wyrazu");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Sproboj ponownie: ");
                        Console.ResetColor();
                    }

                    //algorytm obliczania sumy
                    suma *= wartoscWyrazuCiagu;
                }

                Console.WriteLine();
            }

            /* PRZEDSTAW WYNIK KONCOWY CALEJ FUNKCJI */
            public void WynikFunkcji()
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var x in "WYNIK KONCOWY: ")
                {
                    Console.Write(x);
                    Thread.Sleep(PredkoscPokazywaniaTekstu);
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var x in Convert.ToString(suma))
                {
                    Console.Write(x);
                    Thread.Sleep(PredkoscPokazywaniaTekstu);
                }
                Console.ResetColor();

                Console.Write("\n\nNacisnij dowolny klawisz aby wrocic do menu...");
                Console.ReadKey();

            }
        }

        /// <summary>
        /// Klasa zawierajaca algorytm do obliczania sredniej arytmetycznej (Average Mean)
        /// </summary>
        public class FunkcjaC : WkladListowy
        {

            /// <summary>
            /// Funkcja obliczajaca srednia arytmetyczna
            /// </summary>
            /// <returns>Wynik algorytmu</returns>
            /// <param name="lista">Parametr lista powinien miec jako argument funkcje "PodajDlugoscCiagu" z klasy "WkladListowy"</param>
            public double SredniaArytmetyczna(float[] lista)
            {

                float sumaCiagu = 0.0f;

                foreach (int x in lista)
                {
                    sumaCiagu += x;
                }

                double wynik = sumaCiagu / lista.Length;

                return wynik;
            }

            /// <summary>
            /// Funkcja okazujaca w konsoli wynik algorytmu, przywoluje tez funkcje proszaca o dane wejsciowe
            /// </summary>
            public void WynikFunkcji()
            {
                double wynik = SredniaArytmetyczna(PodajDlugoscCiagu());
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var x in "\nWYNIK KONCOWY: ")
                {
                    Console.Write(x);
                    Thread.Sleep(PredkoscPokazywaniaTekstu);
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var x in Convert.ToString(wynik))
                {
                    Console.Write(x);
                    Thread.Sleep(PredkoscPokazywaniaTekstu);
                }
                Console.ResetColor();

                Console.Write(wyjscieZFunkcji);
                Console.ReadKey();

            }

        }

        /// <summary>
        /// Klasa zawierajaca algorytm do obliczania sredniej wazonej (Weighted Mean)
        /// </summary>
        public class FunkcjaD : WkladListowy
        {

            /// <summary>
            /// Funkcja obliczajaca srednia wazona
            /// </summary>
            /// <returns>Wynik algorytmu</returns>
            /// <param name="lista">Parametr lista powinien miec jako argument funkcje "PodajDlugoscCiagu" z klasy "WkladListowy"</param>
            /// <param name="listaWag">Parametr lista powinien miec jako argument funkcje "PodajDlugoscCiaguWagi" z klasy "WkladListowy"</param>
            public double SredniaWazona(float[] lista, float[] listaWag)
            {

                float[] wynikKazdejWagi = new float[lista.Length];

                for (int x = 0; x < lista.Length; x++)
                {
                    wynikKazdejWagi[x] = (lista[x] * listaWag[x]);
                }

                double wynik = wynikKazdejWagi.Sum() / listaWag.Sum();

                return wynik;

            }

            /// <summary>
            /// Funkcja okazujaca w konsoli wynik algorytmu, przywoluje tez funkcje proszaca o dane wejsciowe
            /// </summary>
            public void WynikFunkcji()
            {

                double wynik = SredniaWazona(PodajDlugoscCiagu(), PodajDlugoscWagi());

                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var x in "\nWYNIK KONCOWY: ")
                {
                    Console.Write(x);
                    Thread.Sleep(PredkoscPokazywaniaTekstu);
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var x in wynik.ToString("N3"))
                {
                    Console.Write(x);
                    Thread.Sleep(PredkoscPokazywaniaTekstu);
                }
                Console.ResetColor();

                Console.Write(wyjscieZFunkcji);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Klasa zawierajaca algorytm do obliczania ceny jednostki paszy
        /// </summary>
        public class FunkcjaE
        {

        }

        /// <summary>
        /// Klasa zawierajaca algorytm do obliczania sredniej harmonicznej (Harmonic Mean)
        /// </summary>
        public class FunkcjaF : WkladListowy
        {

            /// <summary>
            /// Funkcja obliczajaca srednia kwadratowa
            /// </summary>
            /// <returns>Wynik algorytmu</returns>
            /// <param name="lista">Parametr lista powinien miec jako argument funkcje "PodajDlugoscCiagu" z klasy "WkladListowy"</param>
            public double SredniaHarmoniczna(float[] lista)
            {

                double wynik = 0.0d;
                int i;

                for (i = 0; i < lista.Length; i++)
                {
                    wynik += (1.0f) / lista[i];
                }

                wynik = lista.Length * Math.Pow(wynik, -1.0);
                return wynik;
            }

            /// <summary>
            /// Funkcja okazujaca w konsoli wynik algorytmu, przywoluje tez funkcje proszaca o dane wejsciowe
            /// </summary>
            public void WynikFunkcji()
            {

                double wynik = SredniaHarmoniczna(PodajDlugoscCiagu());

                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var x in "\nWYNIK KONCOWY: ")
                {
                    Console.Write(x);
                    Thread.Sleep(PredkoscPokazywaniaTekstu);
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var x in wynik.ToString("N3"))
                {
                    Console.Write(x);
                    Thread.Sleep(PredkoscPokazywaniaTekstu);
                }
                Console.ResetColor();

                Console.Write(wyjscieZFunkcji);
                Console.ReadKey();

            }
        }

        /// <summary>
        /// Klasa zawierajaca algorytm do obliczania sredniej geometrycznej (Geometric Mean)
        /// </summary>
        public class FunkcjaG : WkladListowy
        {

            /// <summary>
            /// Funkcja obliczajaca srednia geometryczna
            /// </summary>
            /// <returns>Wynik algorytmu</returns>
            /// <param name="lista">Parametr lista powinien miec jako argument funkcje "PodajDlugoscCiagu" z klasy "WkladListowy"</param>
            public double SredniaGeometryczna(float[] lista)
            {

                double wynik = 1.0d;
                int i;

                for (i = 0; i < lista.Length; i++)
                {

                    wynik *= lista[i];

                }

                wynik = Math.Pow(wynik, 1.0 / lista.Length);

                return wynik;
            }

            /// <summary>
            /// Funkcja okazujaca w konsoli wynik algorytmu, przywoluje tez funkcje proszaca o dane wejsciowe
            /// </summary>
            public void WynikFunkcji()
            {

                double wynik = SredniaGeometryczna(PodajDlugoscCiagu());

                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var x in "\nWYNIK KONCOWY: ")
                {
                    Console.Write(x);
                    Thread.Sleep(PredkoscPokazywaniaTekstu);
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var x in wynik.ToString("N3"))
                {
                    Console.Write(x);
                    Thread.Sleep(PredkoscPokazywaniaTekstu);
                }
                Console.ResetColor();

                Console.Write(wyjscieZFunkcji);
                Console.ReadKey();

            }

        }

        /// <summary>
        /// Klasa zawierajaca algorytm do obliczania sredniej kwadratowej (RMS)
        /// </summary>
        public class FunkcjaH : WkladListowy
        {

            /// <summary>
            /// Funkcja obliczajaca srednia kwadratowa
            /// </summary>
            /// <returns>Wynik algorytmu</returns>
            /// <param name="lista">Parametr lista powinien miec jako argument funkcje "PodajDlugoscCiagu" z klasy "WkladListowy"</param>
            public double SredniaKwadratowa(float[] lista)
            {
                double wynik = 0.0d;
                double sumaLicznika = 0.0d;
                int i;
                for (i = 0; i < lista.Length; i++)
                {
                    sumaLicznika += (lista[i] * lista[i]);
                }

                wynik = Math.Sqrt(sumaLicznika / lista.Length);

                return wynik;
            }

            /// <summary>
            /// Funkcja okazujaca w konsoli wynik algorytmu, przywoluje tez funkcje proszaca o dane wejsciowe
            /// </summary>
            public void WynikFunkcji()
            {

                double wynik = SredniaKwadratowa(PodajDlugoscCiagu());

                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var x in "\nWYNIK KONCOWY: ")
                {
                    Console.Write(x);
                    Thread.Sleep(PredkoscPokazywaniaTekstu);
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var x in wynik.ToString("N3"))
                {
                    Console.Write(x);
                    Thread.Sleep(PredkoscPokazywaniaTekstu);
                }
                Console.ResetColor();

                Console.Write(wyjscieZFunkcji);
                Console.ReadKey();

            }
        }

        /// <summary>
        /// Klasa zawierajaca algorytm do obliczania sredniej potegowej (Generalized Mean)
        /// </summary>
        public class FunkcjaI : WkladListowy
        {

			/// <summary>
			/// Funkcja zwraca rzad K do sredniej potegowej
			/// </summary>
			/// <returns></returns>
			public int rzadSredniejPotegowej() {
				int rzad;

				foreach (var x in "\tProszę podac rzad do średniej potegowej: ") {
					Console.Write(x);
					Thread.Sleep(PredkoscPokazywaniaTekstu);
				}

				while (!int.TryParse(Console.ReadLine(), out rzad)) {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("\nERROR: wystapił niedozwolony znak w zapisaniu wartości");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write("Proszę wpisać ponownie wartość: ");
					Console.ResetColor();
				}
				return rzad;
			}

			/// <summary>
			/// Funkcja obliczajaca srednia kwadratowa
			/// </summary>
			/// <returns>Wynik algorytmu</returns>
			/// <param name="lista">Parametr lista powinien miec jako argument funkcje "PodajDlugoscCiagu" z klasy "WkladListowy"</param>
			public double SredniaPotegowa(float[] lista) {

				int rzadK = rzadSredniejPotegowej();

				double wynik = 0.0d;
				double sumaLicznika = 0.0d;
				int i;

				for (i = 0; i < lista.Length; i++) {
					sumaLicznika += Math.Pow(lista[i], rzadK);
				}

				wynik = Math.Pow(sumaLicznika / lista.Length, 1.0 / rzadK);
				return wynik;
			}

			/// <summary>
			/// Funkcja okazujaca w konsoli wynik algorytmu, przywoluje tez funkcje proszaca o dane wejsciowe
			/// </summary>
			public void WynikFunkcji() {

				double wynik = SredniaPotegowa(PodajDlugoscCiagu());

				Console.ForegroundColor = ConsoleColor.Cyan;
				foreach (var x in "\nWYNIK KONCOWY: ") {
					Console.Write(x);
					Thread.Sleep(PredkoscPokazywaniaTekstu);
				}

				Console.ForegroundColor = ConsoleColor.Yellow;
				foreach (var x in wynik.ToString("N3")) {
					Console.Write(x);
					Thread.Sleep(PredkoscPokazywaniaTekstu);
				}
				Console.ResetColor();

				Console.Write(wyjscieZFunkcji);
				Console.ReadKey();

			}

		}

        /*---------------------------------*/
        /* Metoda main, startujaca program */
        /*---------------------------------*/

        static void Main(string[] args)
        {

            //deklaracja instancji klas
            MainGUI mainGUI = new MainGUI();
            FunkcjaA funkcjaA = new FunkcjaA();
            FunkcjaB funkcjaB = new FunkcjaB();
            FunkcjaC funkcjaC = new FunkcjaC();
            FunkcjaD funkcjaD = new FunkcjaD();
            FunkcjaF funkcjaF = new FunkcjaF();
            FunkcjaG funkcjaG = new FunkcjaG();
            FunkcjaH funkcjaH = new FunkcjaH();
			FunkcjaI funkcjaI = new FunkcjaI();

            //glowna petla powtarzajaca program
            do
            {
                Console.Clear();

                mainGUI.PokazNazweProgramu(tytulProgramu);
                mainGUI.PokazListeWyborow();

                WybranyKlawisz = Console.ReadKey(true);

                switch (WybranyKlawisz.Key)
                {
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
                        mainGUI.PokazNazweProgramu(tytulProgramu);
                        mainGUI.PokazNazweFunkcji(ListaWyborow[2]);

                        funkcjaC.WynikFunkcji();
                        Console.WriteLine($"Wybrales funkcje: {ListaWyborow[2]}");
                        break;

                    case ConsoleKey.D:
                        Console.Clear();
                        mainGUI.PokazNazweProgramu(tytulProgramu);
                        mainGUI.PokazNazweFunkcji(ListaWyborow[3]);

                        funkcjaD.WynikFunkcji();
                        Console.WriteLine($"Wybrales funkcje: {ListaWyborow[3]}");
                        break;

                    case ConsoleKey.E:
                        Console.Clear();
                        Console.WriteLine($"Wybrales funkcje: {ListaWyborow[4]}");
                        break;

                    case ConsoleKey.F:
                        Console.Clear();
                        mainGUI.PokazNazweProgramu(tytulProgramu);
                        mainGUI.PokazNazweFunkcji(ListaWyborow[5]);

                        funkcjaF.WynikFunkcji();
                        break;

                    case ConsoleKey.G:
                        Console.Clear();
                        mainGUI.PokazNazweProgramu(tytulProgramu);
                        mainGUI.PokazNazweFunkcji(ListaWyborow[6]);

                        funkcjaG.WynikFunkcji();
                        break;

                    case ConsoleKey.H:
                        Console.Clear();
                        mainGUI.PokazNazweProgramu(tytulProgramu);
                        mainGUI.PokazNazweFunkcji(ListaWyborow[7]);

                        funkcjaH.WynikFunkcji();
                        break;

                    case ConsoleKey.I:
                        Console.Clear();
						mainGUI.PokazNazweProgramu(tytulProgramu);
						mainGUI.PokazNazweFunkcji(ListaWyborow[8]);

						funkcjaI.WynikFunkcji();
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
