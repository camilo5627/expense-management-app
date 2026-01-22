using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Ordenamiento
{
    public class OrdenarUsuariosXMail : IComparer<Usuario>
    {
        public int Compare(Usuario? este, Usuario? otro)
        {
            return este.Email.CompareTo(otro.Email);
        }
    }
}
