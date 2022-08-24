using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket1._0
{
    class StavkaRacuna
    {
        public StavkaRacuna()
        {
        }

        public int  StavkaRacunaId { get; set; }
       
        public decimal Kolicina { get; set; }
        public Proizvod Proizvod { get; set; }
        public Racun Racun { get; set; }

        public decimal Cijena { get; set; }

        public override bool Equals(object obj)
        {
            return obj is StavkaRacuna racuna &&
                   StavkaRacunaId == racuna.StavkaRacunaId;
        }

        public override int GetHashCode()
        {
            int hashCode = 1028076892;
            hashCode = hashCode * -1521134295 + StavkaRacunaId.GetHashCode();
            hashCode = hashCode * -1521134295 + Kolicina.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Proizvod>.Default.GetHashCode(Proizvod);
            hashCode = hashCode * -1521134295 + EqualityComparer<Racun>.Default.GetHashCode(Racun);
            return hashCode;
        }
    }
}
