using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket1._0
{
    class Racun
    {
        public Racun()
        {
        }

        public int RacunId { get; set; }
        public string BrojRacuna { get; set; }
        public decimal UkupnaCijena { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public Zaposleni Zaposleni { get; set; }
        
        public string RacunPath { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Racun racun &&
                   RacunId == racun.RacunId;
        }

        public override int GetHashCode()
        {
            return -1101688905 + RacunId.GetHashCode();
        }
    }
}
