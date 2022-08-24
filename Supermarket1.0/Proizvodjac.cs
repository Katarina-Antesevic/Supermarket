using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket1._0
{
    class Proizvodjac
    {
        public int ProizvodjacId { get; set; }
        public string JIB { get; set; }
        public string Naziv { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Proizvodjac proizvodjac &&
                   ProizvodjacId == proizvodjac.ProizvodjacId;
        }

        public override int GetHashCode()
        {
            return -1770635357 + ProizvodjacId.GetHashCode();
        }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
