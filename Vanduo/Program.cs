using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Vanduo
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Telkiniai<Vanduo> A = new Telkiniai<Vanduo>();
            p.Skaitymas("Duom.txt", A);
            double giliausias = p.Giliausias(A);
            Telkiniai<Vanduo> B = p.Giliausi(A, giliausias);
            StreamWriter sw = new StreamWriter("Rezultatai.txt");
            p.Rasymas(B, sw, "IKI RIKAVIMO:");
            B.Rikiuoti();
            p.Rasymas(B, sw, "PO RIKAVIMO:");
            sw.Close();
        }

        Telkiniai<Vanduo> Giliausi(Telkiniai<Vanduo> A, double giliausias)
        {
            Telkiniai<Vanduo> B = new Telkiniai<Vanduo>();
            double desimtproc = giliausias * 0.1;
            giliausias = giliausias - desimtproc;
            foreach(var telkinys in A)
            {
                if (telkinys.Gylis >= giliausias) B.DetiDuomenisT(telkinys);

            }
            return B;
        }

        double Giliausias(Telkiniai<Vanduo> telkiniai)
        {
            double giliausias = 0;
            foreach(var telkinys in telkiniai)
            {
                if (telkinys.Gylis > giliausias) giliausias = telkinys.Gylis;
            }
            return giliausias;
        }


        void Rasymas(Telkiniai<Vanduo> telkiniai, StreamWriter sw, string customtext = null)
        {
            if (customtext != null) sw.WriteLine(customtext);
            string duom = string.Format("{0, -20} {1, -20} {2, -20}", "Pavadinimas", "Valstybe", "Gylis");
            sw.WriteLine(duom);
            foreach (var telkinys in telkiniai)
            {
                sw.WriteLine(telkinys);
            }
        }

        void Skaitymas(string failas, Telkiniai<Vanduo> telkiniai)
        {
            using(StreamReader reader = new StreamReader(failas))
            {
                string eilute = null;
                while(null != (eilute = reader.ReadLine()))
                {
                    string[] duom = eilute.Split(';');
                    Vanduo vanduo = new Vanduo(duom[0], duom[1], double.Parse(duom[2]));
                    telkiniai.DetiDuomenisT(vanduo);
                }
            }
        }
    }
}
