using System;
using System.Collections.Generic;
using Samochody;

namespace TestSamochodu
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Samochod> komis = new List<Samochod>(100)
            {
                new Samochod()
                {
                    Marka = "Audi", Model = "A3", RokProdukcji = 2007,
                    Cena = 100000
                },
                new Samochod()
                {
                    Marka = "Opel", Model = "Vectra", RokProdukcji = 2000,
                    Cena = 10000
                },
                new Samochod()
                {
                    Marka = "Syrena", Model = "105L", RokProdukcji = 1978,
                    Cena = 100
                },
                new Samochod()
                {
                    Marka = "Fiat", Model = "125", RokProdukcji = 1980,
                    Cena = 105
                }
            };
            char c;
            do
            {
                c = Menu();
                switch (c)
                {
                    case 'a':
                    case 'A':
                        komis.Add(DodajSamochod());
                        break;
                    case 'b':
                    case 'B':
                        komis.Sort();
                        WypiszSamochody(komis);
                        break;
                    case 'c':
                    case 'C':
                        komis.Sort(new Samochod.PoRokuProdukcji());
                        WypiszSamochody(komis);
                        break;
                    case 'd':
                    case 'D':
                        komis.Sort(new Samochod.PoModelu());
                        WypiszSamochody(komis);
                        break;
                    case 'e':
                    case 'E':
                        komis.Sort(new Samochod.PoCenie());
                        WypiszSamochody(komis);
                        break;
                }
            } 
            while (!(c == 'k' || c == 'K'));
        }
        
        public static void WypiszSamochody(List<Samochod> komis)
        {
            Console.Clear();
            for (int i = 1; i <= komis.Count; i++)
            {
                Console.WriteLine("{0,3}. {1}", i, komis[i - 1]);
                if (i % Console.WindowHeight == 0)
                    Console.ReadKey(false);
            }

            Console.ReadKey();
        }

        public static char Menu()
        {
            Console.Clear();
            Console.WriteLine("A - Dodaj samochód");
            Console.WriteLine("B - Wypisz wedug nazwy marki");
            Console.WriteLine("C - Wypisz według roku produkcji");
            Console.WriteLine("D - Wypisz według nazwy modelu");
            Console.WriteLine("E - Wypisz według ceny");
            Console.WriteLine("K - Koniec");
            return Console.ReadKey().KeyChar;
        }

        private static Samochod DodajSamochod()
        {
            Console.WriteLine("Podaj markę samochodu: ");
            string marka = Console.ReadLine();
            Console.WriteLine("Podaj model samochodu: ");
            string model = Console.ReadLine();
            decimal cena;
            do
            {
                Console.WriteLine("Podaj cenę samochodu: ");
            } while (!decimal.TryParse(Console.ReadLine(), out cena));

            int rokProdukcji;
            do
            {
                Console.WriteLine("Podaj rok produkcji samochodu: ");
            } while (!int.TryParse(Console.ReadLine(), out rokProdukcji));

            return new Samochod()
            {
                Cena = cena,
                RokProdukcji = rokProdukcji,
                Model = model,
                Marka = marka
            };
        }
    }
}