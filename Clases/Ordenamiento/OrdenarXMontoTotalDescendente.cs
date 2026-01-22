using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Ordenamiento
{
    public class OrdenarXMontoTotalDescendente : IComparer<Pago>
    {
        public int Compare(Pago? este, Pago? otro)
        {
            return otro.Monto.CompareTo(este.Monto);
        }
    }
}
