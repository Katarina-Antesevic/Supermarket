using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket1._0
{
    class VrstaZaposlenog
    {
        public int VrstaZaposlenogId { get; set; }
        public string Naziv { get; set; }

        public override bool Equals(object obj)
        {
            return obj is VrstaZaposlenog zaposlenog &&
                   VrstaZaposlenogId == zaposlenog.VrstaZaposlenogId;
        }

        public override int GetHashCode()
        {
            return 1237228374 + VrstaZaposlenogId.GetHashCode();
        }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
