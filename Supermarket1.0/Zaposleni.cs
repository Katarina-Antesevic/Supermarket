using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket1._0
{
    class Zaposleni
    {
        public Zaposleni()
        {
        }

        public int ZaposleniId { get; set; }
        public string JMB { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public decimal Plata { get; set; }
        public DateTime DatumOd { get; set; }

        public string KrajRadnogOdnosa { get; set; }


        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public VrstaZaposlenog VrstaZaposlenog { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Zaposleni zaposleni &&
                   ZaposleniId == zaposleni.ZaposleniId;
        }

        public override int GetHashCode()
        {
            int hashCode = 1959821759;
            hashCode = hashCode * -1521134295 + ZaposleniId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Ime);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Prezime);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BrojTelefona);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + Plata.GetHashCode();
            hashCode = hashCode * -1521134295 + DatumOd.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(KorisnickoIme);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Lozinka);
            hashCode = hashCode * -1521134295 + EqualityComparer<VrstaZaposlenog>.Default.GetHashCode(VrstaZaposlenog);
            return hashCode;
        }
    }
}
