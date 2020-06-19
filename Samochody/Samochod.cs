using System;
using System.Collections;
using System.Collections.Generic;

namespace Samochody
{
    public class Samochod : IComparable<Samochod>
    {
        public string Marka { set; get; }
        public string Model { set; get; }
        public int RokProdukcji { set; get; }
        public decimal Cena { set; get; }

        public Samochod()
        {
        }

        public Samochod(string marka, string model, int rokProdukcji, decimal cena)
        {
            Marka = marka;
            Model = model;
            RokProdukcji = rokProdukcji;
            Cena = cena;
        }

        public override string ToString()
        {
            return string.Format("Samochód {0,-10} {1,-10} cena: {2,-10} "
                                 +
                                 "rok produkcji {3,-10}", Marka, Model, Cena,
                RokProdukcji);
        }

        public int CompareTo(Samochod other)
        {
            return Marka.CompareTo(other.Marka);
        }
        
        public class PoModelu : IComparer<Samochod>
        {
            public int Compare(Samochod x,Samochod y)
            {
                return string.Compare(x.Model, y.Model, true);
            }
        }

        public class PoCenie : IComparer<Samochod>
        {
            public int Compare(Samochod x, Samochod y)
            {
                return x.Cena.CompareTo(y.Cena);
            }
        }

        public class PoRokuProdukcji : IComparer<Samochod>
        {
            public int Compare(Samochod x, Samochod y)
            {
                return x.RokProdukcji.CompareTo(y.RokProdukcji);
            }
        }
        
        

    }
}