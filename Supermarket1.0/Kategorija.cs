using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket1._0
{
    class Kategorija
    {
        public int KategorijaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Kategorija kategorija &&
                   KategorijaId == kategorija.KategorijaId;
        }

        public override int GetHashCode()
        {
            return -470950499 + KategorijaId.GetHashCode();
        }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
