using Clases.Interfaces;
using System.Threading;

namespace Clases
{
    public class Usuario : IValidable, IEquatable<Usuario>
    {
        private int _id;
        private static int s_ultimoId = 0;
        private string _nombre;
        private string _apellido;
        private string _contrasenia;
        private string _email;
        private DateTime _fechaIncorporacion;
        private Equipo _equipo;
        private Rol _rol;

        public int Id
        {
            get { return _id; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string Contrasenia
        {
            get { return _contrasenia; }
            set { _contrasenia = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public Equipo Equipo
        {
            get { return _equipo; }
            set { _equipo = value; }
        }

        public DateTime FechaIncorporacion
        {
            get { return _fechaIncorporacion; }
            set { _fechaIncorporacion = value; }
        }

        public Rol Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }


        public Usuario()
        {
            _id = ++s_ultimoId;
        }

        public Usuario(string nombre, string apellido, string contrasenia, string email, DateTime FechaIncorporacion, Equipo equipo, Rol rol)
        {
            _id = ++s_ultimoId;
            _nombre = nombre;
            _apellido = apellido;
            _contrasenia = contrasenia;
            _email = email;
            _fechaIncorporacion = FechaIncorporacion;
            _equipo = equipo;
            _rol = rol;

        }

        public void Validar()
        {
            this.ValidarNombre();
            this.ValidarApellido();
            this.ValidarContrasenia();
            this.ValidarEquipo();
            this.ValidarFechaIncorporacion();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrWhiteSpace(this.Nombre)) throw new Exception("Nombre no puede ser vacio");
        }

        private void ValidarApellido()
        {
            if (string.IsNullOrWhiteSpace(this.Apellido)) throw new Exception("Apellido no puede ser vacio");
        }

        private void ValidarContrasenia()
        {
            if (string.IsNullOrWhiteSpace(this.Contrasenia) || this.Contrasenia.Length < 8) throw new Exception("Contrasenia no puede ser vacio y tiene que tener un minimo de 8 caracteres");
        }

        private void ValidarEquipo()
        {
            if (Equipo == null) throw new Exception("El usuario debe pertenecer a un equipo");
        }

        private void ValidarFechaIncorporacion()
        {
            if (FechaIncorporacion > DateTime.Now || FechaIncorporacion.Year < 1900) throw new Exception("Fecha de incorporacion invalida");
        }

        public bool EsGerente()
        {
            return this.Rol.Equals(Rol.Gerente);
        }

        public bool Equals(Usuario? other)
        {
            return other != null && this.Email == other.Email;
        }
    }
}