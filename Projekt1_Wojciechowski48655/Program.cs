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
        static readonly string MWtytulProgramu = "ProjektNr1_Wojciechowski48655";
        static readonly string[] MWlistaWyborow = {
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
		static readonly string MWwyjscieZFunkcji = "\nNacisnij dowolny klawisz aby wrocic do menu...";
        const int MWpredkoscPokazywaniaTekstu = 5;
        static ConsoleKeyInfo MWwybranyKlawisz;

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
        public class MWGlownyInterfejs
        {

            /// <summary>
			/// Pokazanie nazwe programu i wycentrowanie go
			/// </summary>
			/// <param name="MWtytul"></param>
            public void MWpokazNazweProgramu(string MWtytul)
            {
                string MWpusteLinie = "";
                for (int x = 0; x < MWtytul.Length; x++)
                {
                    MWpusteLinie += " ";
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("");
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (MWpusteLinie.Length / 2)) + "}", "|| " + MWpusteLinie + " ||");
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (MWtytul.Length / 2)) + "}", "|| " + MWtytul + " ||");
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (MWpusteLinie.Length / 2)) + "}", "|| " + MWpusteLinie + " ||");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
            }

            /// <summary>
			/// Funkcja pokazuje liste menu uzywajac zmienna MWlistaWyborow
			/// </summary>
            public void MWpokazListeWyborow()
            {

                foreach (var z in "Menu funkcjonalne:\n\n")
                {
                    Console.Write(z);
                    Thread.Sleep(MWpredkoscPokazywaniaTekstu * 5);
                }

                foreach (var x in MWlistaWyborow)
                {

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\t" + x[0]);
                    Console.ForegroundColor = ConsoleColor.Blue;

                    foreach (var y in x.Skip(1))
                    {

                        Console.Write(y);
                        Thread.Sleep(MWpredkoscPokazywaniaTekstu);
                    }
                    Console.WriteLine("");
                }

                Console.ForegroundColor = ConsoleColor.White;
                foreach (var x in "\nWybierz Funkcje z powyzszych...")
                {
                    Console.Write(x);
                    Thread.Sleep(MWpredkoscPokazywaniaTekstu);

                }
            }

            /// <summary>
			/// Funkcja pokazuje w konsoli obecna uzywana funkcje
			/// </summary>
			/// <param name="s"></param>
            public void MWpokazNazweFunkcji(string s)
            {

                foreach (var x in $"Teraz obslugujesz funkcje - ")
                {
                    Console.Write(x);
                    Thread.Sleep(MWpredkoscPokazywaniaTekstu);
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (var x in s.Skip(3))
                {
                    Console.Write(x);
                    Thread.Sleep(MWpredkoscPokazywaniaTekstu);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }

            /// <summary>
			/// Funkcja wylacza program, pokazujac autora programu i numer albumu studenta
			/// </summary>
			/// <param name="MWautorProgramu">Nazwa Autora programu</param>
			/// <param name="MWnumerAlbumu">Numer Albumu studenta</param>
            public void PokazAutora(string MWautorProgramu, string MWnumerAlbumu)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n");
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (MWautorProgramu.Length / 2)) + "}", MWautorProgramu);
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (MWnumerAlbumu.Length / 2)) + "}", MWnumerAlbumu);
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public class MWWkladListowy
        {
			//Deklaracja zmiennych klasowych
			string[] MWciagLiczbString;
			float[] MWciagLiczbFloat;

			string[] MWciagLiczbStringWagi;
			float[] MWciagLiczbFloatWagi;

			/// <summary>
			/// Funkcja ktora nam zwraca dlugosc ciagu w formie Array, sprawdza rowniez czy dane sa poprawnie wpisane.
			/// </summary>
			/// <returns>CiagLiczbFloat</returns>
			public float[] MWpodajDlugoscCiagu()
            {
                //Prosba o wpisanei danych wejsciowych w formie listy oddzielona przecinkiem
                Console.Write("\n\n\tPodaj liczby oddzielając je przecinkiem ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("(i.e.: 1, 2, 3)");
                Console.ResetColor();
                Console.Write(": ");

                MWciagLiczbString = Console.ReadLine().Split(',');
                MWciagLiczbFloat = new float[MWciagLiczbString.Length];
                int MWiteracyjna = 0;

                // operacja przeksztalcania listy STRING w liste FLOAT, razem ze sprawdzaniem czy nie ma bledow w zapisie listy STRING
                foreach (string s in MWciagLiczbString)
                {
                    while (!float.TryParse(s, out MWciagLiczbFloat[MWiteracyjna]))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nERROR: Wystapil niedozwolony znak w {MWiteracyjna + 1} liczbie ciagu");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"Podaj ponownie {MWiteracyjna + 1} cyfre ciagu: ");
                        Console.ResetColor();

                        if (float.TryParse(Console.ReadLine(), out MWciagLiczbFloat[MWiteracyjna]))
                        {
							Console.WriteLine();
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    MWiteracyjna++;
                }
                return MWciagLiczbFloat;
            }

            /// <summary>
            /// Funkcja ktora nam zwraca dlugosc ciagu WAGI w formie Array, sprawdza rowniez czy dane sa poprawnie wpisane.
            /// </summary>
            /// <returns>CiagLiczbFloat</returns>
            public float[] MWpodajDlugoscWagi()
            {
                //Prosba o wpisanei danych wejsciowych w formie listy oddzielona przecinkiem
                Console.Write("\tPodaj wagi oddzielając je przecinkiem ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("(i.e.: 1, 2, 3)");
                Console.ResetColor();
                Console.Write(": ");

				MWciagLiczbStringWagi = Console.ReadLine().Split(',');
				while (MWciagLiczbStringWagi.Length != MWciagLiczbString.Length) {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine($"\nERROR: Pamietaj! Ciag wag musi miec tyle samo elementow co ciag liczbowy");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write($"Podaj ponownie ponownie ciag wag: ");
					Console.ResetColor();
					MWciagLiczbStringWagi = Console.ReadLine().Split(',');
				}

				MWciagLiczbFloatWagi = new float[MWciagLiczbStringWagi.Length];
                int MWiteracyjna = 0;

                foreach (string s in MWciagLiczbStringWagi)
                {
                    while (!float.TryParse(s, out MWciagLiczbFloatWagi[MWiteracyjna]))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nERROR: Wystapil niedozwolony znak w {MWiteracyjna + 1} liczbie ciagu");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"Podaj ponownie {MWiteracyjna + 1} cyfre ciagu: ");
                        Console.ResetColor();

                        if (float.TryParse(Console.ReadLine(), out MWciagLiczbFloatWagi[MWiteracyjna]))
                        {
							Console.WriteLine();
							break;
                        }
                        else
                        {
                            continue;
                        }
                    }

					while (MWciagLiczbFloatWagi[MWiteracyjna] < 0)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine($"\nERROR: Waga nie moze byc nizsza od 0");
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.Write($"Podaj ponownie {MWiteracyjna + 1} cyfre ciagu: ");
						Console.ResetColor();
						MWciagLiczbFloatWagi[MWiteracyjna] = float.Parse(Console.ReadLine());
					}
                    MWiteracyjna++;
                }
                return MWciagLiczbFloatWagi;
            }
        }

        /*-----------------------------------------*/
        /* Klasy do wszystkich funkcji w programie */
        /*-----------------------------------------*/

        /// <summary>
        /// Klasa zawierajaca algorytm do obliczania sumy liczb
        /// </summary>
        public class MWFunkcjaA
        {

            //deklaracja zmiennych klasowych
            private int MWiloscCiagu;
            private float MWsuma;
            private float MWwartoscWyrazuCiagu;

            /// <summary>
			/// Podawanie ciagu liczbowego
			/// </summary>
            public void MWpodajDlugoscCiagu()
            {
                Console.Write("\n\n\tPodaj dlugosc ciagu liczbowego: ");

                //sprawdzanie czy wpisany znak jest poprawny i <= 1
                do
                {
                    while (!int.TryParse(Console.ReadLine(), out MWiloscCiagu))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nERROR: Wystapil niedozwolony znak, sproboj ponownie");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Podaj ponownie licznosc ciagu liczbowego: ");
                        Console.ResetColor();
                    }

                    if (MWiloscCiagu <= 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nERROR: Wartosc N musi byc wieksza od 1");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Podaj ponownie licznosc ciagu liczbowego: ");
                        Console.ResetColor();
                    }

                } while (MWiloscCiagu <= 1);

                Console.WriteLine();
            }

			/// <summary>
			/// Podawanie wartosci kazdego wyrazu z ciagu liczbowego
			/// </summary>
			public void MWpodajKazdyWyrazCiagu()
            {

                //resetowanie zmiennych w razie powtorzenia funkcji
                MWsuma = 0.0f;

                //operacja podawania wyrazow ciagu
                for (int x = 1; x <= MWiloscCiagu; x++)
                {
                    Console.Write($"\tPodaj wartosc {x}-go wyrazu ciagu liczbowego: ");

                    while (!float.TryParse(Console.ReadLine(), out MWwartoscWyrazuCiagu))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nERROR - Blad w zapisie {x}-go wyrazu");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Sproboj ponownie: ");
                        Console.ResetColor();
                    }

                    //algorytm obliczania sumy
                    MWsuma += MWwartoscWyrazuCiagu;
                }

                Console.WriteLine();
            }

			/// <summary>
			/// Przedstaw wynik koncowy calej funkcji
			/// </summary>
			public void MWwynikFunkcji()
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var x in "WYNIK KONCOWY: ")
                {
                    Console.Write(x);
                    Thread.Sleep(MWpredkoscPokazywaniaTekstu);
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var x in Convert.ToString(MWsuma))
                {
                    Console.Write(x);
                    Thread.Sleep(MWpredkoscPokazywaniaTekstu);
                }
                Console.ResetColor();

                Console.Write(MWwyjscieZFunkcji);
                Console.ReadKey();

            }

        }

        /// <summary>
        /// Klasa zawierajaca algorytm do obliczania iloczynu
        /// </summary>
        public class MWFunkcjaB
        {

            //deklaracja zmiennych klasowych
            private int MWiloscCiagu;
            private float MWsuma;
            private float MWwartoscWyrazuCiagu;

			/// <summary>
			/// Podawanie ciagu liczbowego
			/// </summary>
			public void MWpodajDlugoscCiagu()
            {
                Console.Write("\n\n\tPodaj dlugosc ciagu liczbowego: ");

                //sprawdzanie czy wpisany znak jest poprawny i <= 1
                do
                {
                    while (!int.TryParse(Console.ReadLine(), out MWiloscCiagu))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nERROR: Wystapil niedozwolony znak, sproboj ponownie");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Podaj ponownie licznosc ciagu liczbowego: ");
                        Console.ResetColor();
                    }

                    if (MWiloscCiagu <= 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nERROR: Wartosc N musi byc wieksza od 1");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Podaj ponownie licznosc ciagu liczbowego: ");
                        Console.ResetColor();
                    }

                } while (MWiloscCiagu <= 1);

                Console.WriteLine();
            }

			/// <summary>
			/// Podawanie wartosci kazdego wyrazu z ciagu liczbowego
			/// </summary>
			public void MWpodajKazdyWyrazCiagu()
            {

                //resetowanie zmiennych w razie powtorzenia funkcji
                MWsuma = 1.0f;

                //operacja podawania wyrazow ciagu
                for (int x = 1; x <= MWiloscCiagu; x++)
                {
                    Console.Write($"\tPodaj wartosc {x}-go wyrazu ciagu liczbowego: ");

                    while (!float.TryParse(Console.ReadLine(), out MWwartoscWyrazuCiagu))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nERROR - Blad w zapisie {x}-go wyrazu");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Sproboj ponownie: ");
                        Console.ResetColor();
                    }

                    //algorytm obliczania sumy
                    MWsuma *= MWwartoscWyrazuCiagu;
                }

                Console.WriteLine();
            }

			/// <summary>
			/// Przedstaw wynik koncowy calej funkcji
			/// </summary>
			public void MWwynikFunkcji()
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var x in "WYNIK KONCOWY: ")
                {
                    Console.Write(x);
                    Thread.Sleep(MWpredkoscPokazywaniaTekstu);
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var x in Convert.ToString(MWsuma))
                {
                    Console.Write(x);
                    Thread.Sleep(MWpredkoscPokazywaniaTekstu);
                }
                Console.ResetColor();

                Console.Write(MWwyjscieZFunkcji);
                Console.ReadKey();

            }
        }

        /// <summary>
        /// Klasa zawierajaca algorytm do obliczania sredniej arytmetycznej (Average Mean)
        /// </summary>
        public class MWFunkcjaC : MWWkladListowy
        {

            /// <summary>
            /// Funkcja obliczajaca srednia arytmetyczna
            /// </summary>
            /// <returns>Wynik algorytmu</returns>
            /// <param name="MWlista">Parametr lista powinien miec jako argument funkcje "PodajDlugoscCiagu" z klasy "WkladListowy"</param>
            public double MWsredniaArytmetyczna(float[] MWlista)
            {

                float MWsumaCiagu = 0.0f;

                foreach (int x in MWlista)
                {
                    MWsumaCiagu += x;
                }

                double MWwynik = MWsumaCiagu / MWlista.Length;

                return MWwynik;
            }

            /// <summary>
            /// Funkcja okazujaca w konsoli wynik algorytmu, przywoluje tez funkcje proszaca o dane wejsciowe
            /// </summary>
            public void MWwynikFunkcji()
            {
                double MWwynik = MWsredniaArytmetyczna(MWpodajDlugoscCiagu());
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var x in "\nWYNIK KONCOWY: ")
                {
                    Console.Write(x);
                    Thread.Sleep(MWpredkoscPokazywaniaTekstu);
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var x in Convert.ToString(MWwynik))
                {
                    Console.Write(x);
                    Thread.Sleep(MWpredkoscPokazywaniaTekstu);
                }
                Console.ResetColor();

                Console.Write(MWwyjscieZFunkcji);
                Console.ReadKey();

            }

        }

        /// <summary>
        /// Klasa zawierajaca algorytm do obliczania sredniej wazonej (Weighted Mean)
        /// </summary>
        public class MWFunkcjaD : MWWkladListowy
        {

            /// <summary>
            /// Funkcja obliczajaca srednia wazona
            /// </summary>
            /// <returns>Wynik algorytmu</returns>
            /// <param name="MWlista">Parametr lista powinien miec jako argument funkcje "PodajDlugoscCiagu" z klasy "WkladListowy"</param>
            /// <param name="MWlistaWag">Parametr lista powinien miec jako argument funkcje "PodajDlugoscCiaguWagi" z klasy "WkladListowy"</param>
            public double MWsredniaWazona(float[] MWlista, float[] MWlistaWag)
            {

                float[] MWwynikKazdejWagi = new float[MWlista.Length];

                for (int x = 0; x < MWlista.Length; x++)
                {
                    MWwynikKazdejWagi[x] = (MWlista[x] * MWlistaWag[x]);
                }

                double MWwynik = MWwynikKazdejWagi.Sum() / MWlistaWag.Sum();

                return MWwynik;

            }

            /// <summary>
            /// Funkcja okazujaca w konsoli wynik algorytmu, przywoluje tez funkcje proszaca o dane wejsciowe
            /// </summary>
            public void WynikFunkcji()
            {

                double wynik = MWsredniaWazona(MWpodajDlugoscCiagu(), MWpodajDlugoscWagi());

                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var x in "\nWYNIK KONCOWY: ")
                {
                    Console.Write(x);
                    Thread.Sleep(MWpredkoscPokazywaniaTekstu);
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var x in wynik.ToString("N3"))
                {
                    Console.Write(x);
                    Thread.Sleep(MWpredkoscPokazywaniaTekstu);
                }
                Console.ResetColor();

                Console.Write(MWwyjscieZFunkcji);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Klasa zawierajaca algorytm do obliczania ceny jednostki paszy
        /// </summary>
        public class MWFunkcjaE
        {

        }

        /// <summary>
        /// Klasa zawierajaca algorytm do obliczania sredniej harmonicznej (Harmonic Mean)
        /// </summary>
        public class MWFunkcjaF : MWWkladListowy
        {

            /// <summary>
            /// Funkcja obliczajaca srednia kwadratowa
            /// </summary>
            /// <returns>Wynik algorytmu</returns>
            /// <param name="MWlista">Parametr lista powinien miec jako argument funkcje "PodajDlugoscCiagu" z klasy "WkladListowy"</param>
            public double MWsredniaHarmoniczna(float[] MWlista)
            {

                double MWwynik = 0.0d;
                int MWiteracyjna;

                for (MWiteracyjna = 0; MWiteracyjna < MWlista.Length; MWiteracyjna++)
                {
                    MWwynik += (1.0f) / MWlista[MWiteracyjna];
                }

                MWwynik = MWlista.Length * Math.Pow(MWwynik, -1.0);
                return MWwynik;
            }

            /// <summary>
            /// Funkcja okazujaca w konsoli wynik algorytmu, przywoluje tez funkcje proszaca o dane wejsciowe
            /// </summary>
            public void MWwynikFunkcji()
            {

                double MWwynik = MWsredniaHarmoniczna(MWpodajDlugoscCiagu());

                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var x in "\nWYNIK KONCOWY: ")
                {
                    Console.Write(x);
                    Thread.Sleep(MWpredkoscPokazywaniaTekstu);
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var x in MWwynik.ToString("N3"))
                {
                    Console.Write(x);
                    Thread.Sleep(MWpredkoscPokazywaniaTekstu);
                }
                Console.ResetColor();

                Console.Write(MWwyjscieZFunkcji);
                Console.ReadKey();

            }
        }

        /// <summary>
        /// Klasa zawierajaca algorytm do obliczania sredniej geometrycznej (Geometric Mean)
        /// </summary>
        public class MWFunkcjaG : MWWkladListowy
        {

            /// <summary>
            /// Funkcja obliczajaca srednia geometryczna
            /// </summary>
            /// <returns>Wynik algorytmu</returns>
            /// <param name="MWlista">Parametr lista powinien miec jako argument funkcje "PodajDlugoscCiagu" z klasy "WkladListowy"</param>
            public double MWsredniaGeometryczna(float[] MWlista)
            {

                double MWwynik = 1.0d;
                int MWiteracyjna;

                for (MWiteracyjna = 0; MWiteracyjna < MWlista.Length; MWiteracyjna++)
                {

                    MWwynik *= MWlista[MWiteracyjna];

                }

                MWwynik = Math.Pow(MWwynik, 1.0 / MWlista.Length);

                return MWwynik;
            }

            /// <summary>
            /// Funkcja okazujaca w konsoli wynik algorytmu, przywoluje tez funkcje proszaca o dane wejsciowe
            /// </summary>
            public void MWwynikFunkcji()
            {

                double MWwynik = MWsredniaGeometryczna(MWpodajDlugoscCiagu());

                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var x in "\nWYNIK KONCOWY: ")
                {
                    Console.Write(x);
                    Thread.Sleep(MWpredkoscPokazywaniaTekstu);
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var x in MWwynik.ToString("N3"))
                {
                    Console.Write(x);
                    Thread.Sleep(MWpredkoscPokazywaniaTekstu);
                }
                Console.ResetColor();

                Console.Write(MWwyjscieZFunkcji);
                Console.ReadKey();

            }

        }

        /// <summary>
        /// Klasa zawierajaca algorytm do obliczania sredniej kwadratowej (RMS)
        /// </summary>
        public class MWFunkcjaH : MWWkladListowy
        {

            /// <summary>
            /// Funkcja obliczajaca srednia kwadratowa
            /// </summary>
            /// <returns>Wynik algorytmu</returns>
            /// <param name="MWlista">Parametr lista powinien miec jako argument funkcje "PodajDlugoscCiagu" z klasy "WkladListowy"</param>
            public double MWsredniaKwadratowa(float[] MWlista)
            {
                double MWwynik = 0.0d;
                double MWsumaLicznika = 0.0d;
                int MWiteracyjna;
                for (MWiteracyjna = 0; MWiteracyjna < MWlista.Length; MWiteracyjna++)
                {
                    MWsumaLicznika += (MWlista[MWiteracyjna] * MWlista[MWiteracyjna]);
                }

                MWwynik = Math.Sqrt(MWsumaLicznika / MWlista.Length);

                return MWwynik;
            }

            /// <summary>
            /// Funkcja okazujaca w konsoli wynik algorytmu, przywoluje tez funkcje proszaca o dane wejsciowe
            /// </summary>
            public void MWwynikFunkcji()
            {

                double MWwynik = MWsredniaKwadratowa(MWpodajDlugoscCiagu());

                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var x in "\nWYNIK KONCOWY: ")
                {
                    Console.Write(x);
                    Thread.Sleep(MWpredkoscPokazywaniaTekstu);
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var x in MWwynik.ToString("N3"))
                {
                    Console.Write(x);
                    Thread.Sleep(MWpredkoscPokazywaniaTekstu);
                }
                Console.ResetColor();

                Console.Write(MWwyjscieZFunkcji);
                Console.ReadKey();

            }
        }

        /// <summary>
        /// Klasa zawierajaca algorytm do obliczania sredniej potegowej (Generalized Mean)
        /// </summary>
        public class MWFunkcjaI : MWWkladListowy
        {

			/// <summary>
			/// Funkcja zwraca rzad K do sredniej potegowej
			/// </summary>
			/// <returns></returns>
			public int MWrzadSredniejPotegowej() {

				int MWrzad;

				foreach (var x in "\tProszę podac rzad do średniej potegowej: ") {
					Console.Write(x);
					Thread.Sleep(MWpredkoscPokazywaniaTekstu);
				}

				while (!int.TryParse(Console.ReadLine(), out MWrzad)) {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("\nERROR: wystapił niedozwolony znak w zapisaniu wartości");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write("Proszę wpisać ponownie wartość: ");
					Console.ResetColor();
				}
				return MWrzad;
			}

			/// <summary>
			/// Funkcja obliczajaca srednia kwadratowa
			/// </summary>
			/// <returns>Wynik algorytmu</returns>
			/// <param name="MWlista">Parametr lista powinien miec jako argument funkcje "PodajDlugoscCiagu" z klasy "WkladListowy"</param>
			public double MWsredniaPotegowa(float[] MWlista) {

				int MWrzadK = MWrzadSredniejPotegowej();

				double MWwynik = 0.0d;
				double MWsumaLicznika = 0.0d;
				int MWiteracyjna;

				for (MWiteracyjna = 0; MWiteracyjna < MWlista.Length; MWiteracyjna++) {
					MWsumaLicznika += Math.Pow(MWlista[MWiteracyjna], MWrzadK);
				}

				MWwynik = Math.Pow(MWsumaLicznika / MWlista.Length, 1.0 / MWrzadK);
				return MWwynik;
			}

			/// <summary>
			/// Funkcja okazujaca w konsoli wynik algorytmu, przywoluje tez funkcje proszaca o dane wejsciowe
			/// </summary>
			public void MWwynikFunkcji() {

				double MWwynik = MWsredniaPotegowa(MWpodajDlugoscCiagu());

				Console.ForegroundColor = ConsoleColor.Cyan;
				foreach (var x in "\nWYNIK KONCOWY: ") {
					Console.Write(x);
					Thread.Sleep(MWpredkoscPokazywaniaTekstu);
				}

				Console.ForegroundColor = ConsoleColor.Yellow;
				foreach (var x in MWwynik.ToString("N3")) {
					Console.Write(x);
					Thread.Sleep(MWpredkoscPokazywaniaTekstu);
				}
				Console.ResetColor();

				Console.Write(MWwyjscieZFunkcji);
				Console.ReadKey();

			}

		}

        /*---------------------------------*/
        /* Metoda main, startujaca program */
        /*---------------------------------*/

        static void Main(string[] args)
        {

            //deklaracja instancji klas
            MWGlownyInterfejs MWmainGUI = new MWGlownyInterfejs();
            MWFunkcjaA MWfunkcjaA = new MWFunkcjaA();
            MWFunkcjaB MWfunkcjaB = new MWFunkcjaB();
            MWFunkcjaC MWfunkcjaC = new MWFunkcjaC();
            MWFunkcjaD MWfunkcjaD = new MWFunkcjaD();
            MWFunkcjaF MWfunkcjaF = new MWFunkcjaF();
            MWFunkcjaG MWfunkcjaG = new MWFunkcjaG();
            MWFunkcjaH MWfunkcjaH = new MWFunkcjaH();
			MWFunkcjaI MWfunkcjaI = new MWFunkcjaI();

            //glowna petla powtarzajaca program
            do
            {
                Console.Clear();

                MWmainGUI.MWpokazNazweProgramu(MWtytulProgramu);
                MWmainGUI.MWpokazListeWyborow();

                MWwybranyKlawisz = Console.ReadKey(true);

                switch (MWwybranyKlawisz.Key)
                {
                    case ConsoleKey.A:
                        Console.Clear();
                        MWmainGUI.MWpokazNazweProgramu(MWtytulProgramu);
                        MWmainGUI.MWpokazNazweFunkcji(MWlistaWyborow[0]);

                        MWfunkcjaA.MWpodajDlugoscCiagu();
                        MWfunkcjaA.MWpodajKazdyWyrazCiagu();
                        MWfunkcjaA.MWwynikFunkcji();

                        break;

                    case ConsoleKey.B:
                        Console.Clear();
                        MWmainGUI.MWpokazNazweProgramu(MWtytulProgramu);
                        MWmainGUI.MWpokazNazweFunkcji(MWlistaWyborow[1]);

                        MWfunkcjaB.MWpodajDlugoscCiagu();
                        MWfunkcjaB.MWpodajKazdyWyrazCiagu();
                        MWfunkcjaB.MWwynikFunkcji();
                        break;

                    case ConsoleKey.C:
                        Console.Clear();
                        MWmainGUI.MWpokazNazweProgramu(MWtytulProgramu);
                        MWmainGUI.MWpokazNazweFunkcji(MWlistaWyborow[2]);

                        MWfunkcjaC.MWwynikFunkcji();
                        Console.WriteLine($"Wybrales funkcje: {MWlistaWyborow[2]}");
                        break;

                    case ConsoleKey.D:
                        Console.Clear();
                        MWmainGUI.MWpokazNazweProgramu(MWtytulProgramu);
                        MWmainGUI.MWpokazNazweFunkcji(MWlistaWyborow[3]);

                        MWfunkcjaD.WynikFunkcji();
                        Console.WriteLine($"Wybrales funkcje: {MWlistaWyborow[3]}");
                        break;

                    case ConsoleKey.E:
                        Console.Clear();
                        Console.WriteLine($"Wybrales funkcje: {MWlistaWyborow[4]}");
                        break;

                    case ConsoleKey.F:
                        Console.Clear();
                        MWmainGUI.MWpokazNazweProgramu(MWtytulProgramu);
                        MWmainGUI.MWpokazNazweFunkcji(MWlistaWyborow[5]);

                        MWfunkcjaF.MWwynikFunkcji();
                        break;

                    case ConsoleKey.G:
                        Console.Clear();
                        MWmainGUI.MWpokazNazweProgramu(MWtytulProgramu);
                        MWmainGUI.MWpokazNazweFunkcji(MWlistaWyborow[6]);

                        MWfunkcjaG.MWwynikFunkcji();
                        break;

                    case ConsoleKey.H:
                        Console.Clear();
                        MWmainGUI.MWpokazNazweProgramu(MWtytulProgramu);
                        MWmainGUI.MWpokazNazweFunkcji(MWlistaWyborow[7]);

                        MWfunkcjaH.MWwynikFunkcji();
                        break;

                    case ConsoleKey.I:
                        Console.Clear();
						MWmainGUI.MWpokazNazweProgramu(MWtytulProgramu);
						MWmainGUI.MWpokazNazweFunkcji(MWlistaWyborow[8]);

						MWfunkcjaI.MWwynikFunkcji();
						break;

                    case ConsoleKey.Z:
                        MWmainGUI.PokazAutora("Mateusz Wojciechowski", "Numer Albumu: 48655");
                        Thread.Sleep(5000);
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n\nERROR: Nie istnieje funkcja pod klawiszem \"{MWwybranyKlawisz.Key}\"");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Podaj Funkcje jeszcze raz...");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        break;
                }

            } while (MWwybranyKlawisz.Key != ConsoleKey.Z);

            Console.WriteLine();

        }
    }
}
