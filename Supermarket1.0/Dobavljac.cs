using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket1._0
{
    class Dobavljac
    {
        public int DobavljacId { get; set; }
        public string JIB { get; set; }
        public string Naziv { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Dobavljac dobavljac &&
                   DobavljacId == dobavljac.DobavljacId;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
