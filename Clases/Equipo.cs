using Clases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;



namespace Clases

{

    public class Equipo : IValidable, IEquatable<Equipo>

    {

        private int _idEquipo;

        private static int s_ultimoId = 1;

        private string _nombre;



        public int IdEquipo

        {

            get { return _idEquipo; }

            set { _idEquipo = value; }

        }



        public int S_ultimoId

        {

            get { return s_ultimoId; }

        }



        public string Nombre

        {

            get { return _nombre; }

            set { _nombre = value; }

        }



        public Equipo() { }



        public Equipo(string nombre)

        {

            _nombre = nombre;

        }



        private void ValidarNombre()

        {

            if (string.IsNullOrWhiteSpace(this.Nombre)) throw new Exception("Nombre no puede ser vacio");

        }



        public void AsignarId(Equipo nuevoEquipo)

        {

            nuevoEquipo.IdEquipo = s_ultimoId;

            s_ultimoId++;

        }



        public void Validar()

        {

            ValidarNombre();

        }



        public bool Equals(Equipo? other)

        {

            return other != null && this.IdEquipo == other.IdEquipo;

        }

    }

}













