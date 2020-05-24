using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vanduo
{
    class Vanduo : IComparable<Vanduo>
    {
        public string Pavadinimas { get; set; }
        public string Valstybe { get; set; }
        public double Gylis { get; set; }

        public Vanduo(string pavadinimas, string valstybe, double gylis)
        {
            Pavadinimas = pavadinimas;
            Valstybe = valstybe;
            Gylis = gylis;
        }

        public int CompareTo(Vanduo other)
        {
            if (other == null) return 1;
            if (Gylis.CompareTo(other.Gylis) == 1)
            {
                return Pavadinimas.CompareTo(other.Pavadinimas);
            }
            else return Gylis.CompareTo(other.Gylis);
        }

        public override string ToString()
        {
            string duom = string.Format("{0, -20} {1, -20} {2, -20}", Pavadinimas, Valstybe, Gylis);
            return duom;
        }
    }
}
