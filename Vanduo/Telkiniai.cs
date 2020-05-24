using System;
using System.Collections;
using System.Collections.Generic;

namespace Vanduo
{
    class Telkiniai<tipas> : IEnumerable<tipas>
        where tipas: IComparable<tipas>
    {
        private class Mazgas<type> where type : IComparable<type>
        {
            public Mazgas<type> Kaire { get; set; }
            public Mazgas<type> Desine { get; set; }
            public type Duom { get; set; }

            public Mazgas(Mazgas<type> kaire, Mazgas<type> desine, type vanduo)
            {
                Kaire = kaire;
                Desine = desine;
                Duom = vanduo;
            }
        }
        private Mazgas<tipas> pr;
        private Mazgas<tipas> pb;
        private Mazgas<tipas> d;

        public Telkiniai()
        {
            pr = null;
            pb = null;
            d = null;
        }

        public void Pradzia()
        {
            d = pr;
        }

        public bool Yra()
        {
            return d != null;
        }

        public void KitasD()
        {
            d = d.Desine;
        }

        public void KitasK()
        {
            d = d.Kaire;
        }

        public void Pabaiga()
        {
            d = pb;
        }

        public tipas ImtiDuomenis()
        {
            return d.Duom;
        }

       /* public void DetiDuomenisT(tipas vanduo)
        {
            var dd = new Mazgas<tipas>(pb, null, vanduo);
            if (pr != null) pb.Desine = dd;
            else pr = dd;
            pb = dd;
        }

        public void DetiDuomenisA(tipas vanduo)
        {
            var dd = new Mazgas<tipas>(null, pr, vanduo);
            if (pr != null) pr.Kaire = dd;
            else pb = dd;
            pr = dd;
        }*/

        public void DetiDuomenisT(tipas Vanduo)
        {
            var dd = new Mazgas<tipas>(pb, null, Vanduo);
            if (pr != null) pb.Desine = dd;
            else pr = dd;
            pb = dd;
        }

        public void DetiDuomenisA(tipas Vanduo)
        {
            var dd = new Mazgas<tipas>(null, pr, Vanduo);
            if (pr != null) pr.Kaire = dd;
            else pb = dd;
            pr = dd;
        }

        public IEnumerator<tipas> GetEnumerator()
        {
            for(Mazgas<tipas> dd = pr; dd != null; dd = dd.Desine)
            {
                yield return dd.Duom;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Rikiuoti()
        {
            for(Mazgas<tipas> d1 = pr; d1 != null; d1 = d1.Desine)
            {
                Mazgas<tipas> laik = d1;
                for (Mazgas<tipas> dd = d1.Desine; dd != null; dd = dd.Desine)
                {
                    if (dd.Duom.CompareTo(laik.Duom) == -1) laik = dd;
                }
                tipas vanduo = d1.Duom;
                d1.Duom = laik.Duom;
                laik.Duom = vanduo;
            }
        }
    }
}