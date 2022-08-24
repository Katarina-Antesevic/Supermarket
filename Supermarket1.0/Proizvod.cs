using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket1._0
{
    class Proizvod
    {
        public int ProizvodId { get; set; }
        public string Barkod { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public decimal Kolicina { get; set; }

        public Kategorija Kategorija { get; set; }
        public Proizvodjac Proizvodjac { get; set; }
        public Dobavljac Dobavljac { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Proizvod proizvod &&
                   ProizvodId == proizvod.ProizvodId;
        }

        public override int GetHashCode()
        {
            return -1838510319 + ProizvodId.GetHashCode();
        }
    }
}
