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
        private static readonly string tytulProgramu = "ProjektNr1 - funkcje matematyczne";
        private static readonly string[] ListaWyborow = {
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
        enum InputChoices { Suma, Iloczyn, SredniaArytmetyczna, SredniaWazona };

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

        /*-----------------------------------------*/
        /* Klasy do wszystkich funkcji w programie */
        /*-----------------------------------------*/
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

        public class FunkcjaC
        {

            //deklaracja zmiennych klasowych
            float suma;
            float tymczasowaZmienna;

            /* funkcja dzieki ktorej podajemy ciag liczbowy */
            public void PodajDlugoscCiagu()
            {

                //resetowanie zmiennych w razie powtorzenia funkcji
                suma = 0.0f;
                tymczasowaZmienna = 0.0f;

                //Prosba o wpisanei danych wejsciowych w formie listy oddzielona przecinkiem
                Console.Write("\n\n\tPodaj liczby oddzielając je przecinkiem (i.e.: 1 , 2, 3): ");
                string[] CiagLiczbString = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
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
                            break;
                        }
                        else
                        {
                            continue;
                        }

                    }
                    i++;
                }

                foreach (int x in CiagLiczbFloat)
                {
                    tymczasowaZmienna += x;
                }

                //algorytm do obliczania sredniej
                suma = tymczasowaZmienna / CiagLiczbFloat.Length;
            }

            /* PRZEDSTAW WYNIK KONCOWY CALEJ FUNKCJI */
            public void WynikFunkcji()
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var x in "\nWYNIK KONCOWY: ")
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

        public class FunkcjaD
        {

            //deklaracja zmiennych klasowych
            string[] CiagLiczbString;
            float[] CiagLiczbFloat;

            string[] CiagLiczbStringWagi;
            float[] CiagLiczbFloatWagi;


            /* funkcja dzieki ktorej podajemy ciag liczbowy */
            public void PodajDlugoscCiagu()
            {

                //Prosba o wpisanei danych wejsciowych w formie listy oddzielona przecinkiem
                Console.Write("\n\n\tPodaj liczby oddzielając je przecinkiem (i.e.: 1 , 2, 3): ");
                CiagLiczbString = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                CiagLiczbFloat = new float[CiagLiczbString.Length];
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
                            break;
                        }
                        else
                        {
                            continue;
                        }

                    }
                    i++;
                }
            }

            public void PodajDlugoscWagi()
            {

                //Prosba o wpisanei danych wejsciowych w formie listy oddzielona przecinkiem
                Console.Write("\n\n\tPodaj wagi oddzielając je przecinkiem (i.e.: 1, 2, 3): ");
                CiagLiczbStringWagi = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                CiagLiczbFloatWagi = new float[CiagLiczbStringWagi.Length];

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
                            break;
                        }
                        else
                        {
                            continue;
                        }

                    }
                    i++;
                }

            }

            public void WynikFunkcji()
            {

                float[] WynikWag = new float[CiagLiczbFloat.Length];

                for (int x = 0; x < CiagLiczbFloat.Length; x++)
                {
                    WynikWag[x] = (CiagLiczbFloat[x] * CiagLiczbFloatWagi[x]);
                }

                float suma = WynikWag.Sum() / CiagLiczbFloatWagi.Sum();

                Console.WriteLine(string.Join(", ", WynikWag));
                Console.WriteLine($"Wynik to: {suma}");
                Console.ReadKey();

            }
        }

        public class FunkcjaE
        {

        }

        public class FunkcjaF
        {

            //deklaracja zmiennych klasowych
            string[] CiagLiczbString;
            float[] CiagLiczbFloat;

            /* funkcja dzieki ktorej podajemy ciag liczbowy */
            public float[] PodajDlugoscCiagu()
            {

                //Prosba o wpisanei danych wejsciowych w formie listy oddzielona przecinkiem
                Console.Write("\n\n\tPodaj liczby oddzielając je przecinkiem (i.e.: 1 , 2, 3): ");
                CiagLiczbString = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                CiagLiczbFloat = new float[CiagLiczbString.Length];
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


            /* funkcja do obliczania sredniej harmonicznej z parametrem array ktorym jest lista wynikajaca z "PodajDlugoscCiagu()" */
            public double SredniaHarmoniczna(float[] array)
            {

                double wynik = 0.0d;
                int i;

                for (i = 0; i < array.Length; i++)
                {
                    wynik += (1.0f) / array[i];
                }

                wynik = array.Length * Math.Pow(wynik, -1.0);
                return wynik;
            }

            /* PRZEDSTAW WYNIK KONCOWY CALEJ FUNKCJI */
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

                Console.Write("\n\nNacisnij dowolny klawisz aby wrocic do menu...");
                Console.ReadKey();

            }
        }

        public class FunkcjaG
        {

            //deklaracja zmiennych klasowych
            string[] CiagLiczbString;
            float[] CiagLiczbFloat;

            /* funkcja dzieki ktorej podajemy ciag liczbowy */
            public float[] PodajDlugoscCiagu()
            {

                //Prosba o wpisanei danych wejsciowych w formie listy oddzielona przecinkiem
                Console.Write("\n\n\tPodaj liczby oddzielając je przecinkiem (i.e.: 1 , 2, 3): ");
                CiagLiczbString = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                CiagLiczbFloat = new float[CiagLiczbString.Length];
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

            /* funkcja do obliczania sredniej geometrycznej z parametrem array pochodzacym od PodajDlugoscCiagu */
            public double SredniaGeometryczna(float[] array)
            {

                double wynik = 1.0d;
                int i;

                for (i = 0; i < array.Length; i++)
                {

                    wynik *= array[i];

                }

                Console.WriteLine(wynik);

                wynik = Math.Pow(wynik, 1.0 / array.Length);

                return wynik;
            }

            /* PRZEDSTAW WYNIK KONCOWY CALEJ FUNKCJI */
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

                Console.Write("\n\nNacisnij dowolny klawisz aby wrocic do menu...");
                Console.ReadKey();

            }

        }

        public class FunkcjaH
        {

            //deklaracja zmiennych klasowych
            string[] CiagLiczbString;
            float[] CiagLiczbFloat;

            /* funkcja dzieki ktorej podajemy ciag liczbowy */
            public float[] PodajDlugoscCiagu()
            {

                //Prosba o wpisanei danych wejsciowych w formie listy oddzielona przecinkiem
                Console.Write("\n\n\tPodaj liczby oddzielając je przecinkiem (i.e.: 1 , 2, 3): ");
                CiagLiczbString = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                CiagLiczbFloat = new float[CiagLiczbString.Length];
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

            public double SredniaKwadratowa(float[] array)
            {
                double wynik = 0.0d;
                double sumaLicznika = 0.0d;
                int i;
                for (i = 0; i < array.Length; i++)
                {
                    sumaLicznika += (array[i] * array[i]);
                }

                wynik = Math.Sqrt(sumaLicznika / array.Length);

                return wynik;
            }

            /* PRZEDSTAW WYNIK KONCOWY CALEJ FUNKCJI */
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

                Console.Write("\n\nNacisnij dowolny klawisz aby wrocic do menu...");
                Console.ReadKey();

            }
        }

        public class FunkcjaI
        {

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

                        funkcjaC.PodajDlugoscCiagu();
                        funkcjaC.WynikFunkcji();
                        Console.WriteLine($"Wybrales funkcje: {ListaWyborow[2]}");
                        break;

                    case ConsoleKey.D:
                        Console.Clear();
                        mainGUI.PokazNazweProgramu(tytulProgramu);
                        mainGUI.PokazNazweFunkcji(ListaWyborow[3]);

                        funkcjaD.PodajDlugoscCiagu();
                        funkcjaD.PodajDlugoscWagi();
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
