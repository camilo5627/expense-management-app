using Clases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Gasto : IValidable, IEquatable<Gasto>
    {
        private int _id; private static int s_ultimoId = 0; private string _nombre; private string _descripcion;

        public int Id
        {
            get { return _id; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public Gasto() { }

        public Gasto(string nombre, string descripcion)
        {
            _id = ++s_ultimoId;
            _nombre = nombre;
            _descripcion = descripcion;
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrWhiteSpace(this.Nombre)) throw new Exception("Nombre no puede ser vacio");
        }

        private bool ValidarDescripcion()
        {
            bool aRetornar = true;

            if (string.IsNullOrEmpty(this.Descripcion))
            {
                aRetornar = false;
            }

            return aRetornar;
        }

        public void Validar()
        {
            ValidarNombre();
            ValidarDescripcion();
        }

        public bool Equals(Gasto? other)
        {
            return other != null && this.Nombre == other.Nombre;
        }
    }


}



