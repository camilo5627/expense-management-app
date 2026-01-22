using Clases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Clases
{
    public abstract class Pago : IValidable
    {
        private int _idPagos;
        private static int s_ultimoId = 0;
        private DateTime _fechaCompra;
        private string _descripcion;
        private MetodoPago _metodoDePago;
        private Gasto _tipoGasto;
        private Usuario _usuario;
        private double _monto;

        public int IdPagos
        {
            get { return _idPagos; }
            set { _idPagos = value; }
        }
        public DateTime FechaCompra
        {
            get { return _fechaCompra; }
            set { _fechaCompra = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public MetodoPago MetodoDePago
        {
            get { return _metodoDePago; }
            set { _metodoDePago = value; }
        }

        public double Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }

        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public Gasto TipoDeGasto
        {
            get { return _tipoGasto; }
            set { _tipoGasto = value; }
        }



        public Pago()
        {
            _idPagos = ++s_ultimoId;
        }

        public Pago(DateTime fechaCompra, string descripcion, MetodoPago metodoDePago, Gasto tipoGasto, Usuario usuario, double monto)
        {
            _idPagos = ++s_ultimoId;
            _fechaCompra = fechaCompra;
            _descripcion = descripcion;
            _metodoDePago = metodoDePago;
            _tipoGasto = tipoGasto;
            _usuario = usuario;
            _monto = monto;
        }

        private void ValidarMetodoPago()
        {
            if (this._metodoDePago == null)
            {
                throw new Exception("El metodo de pago no puede estar vacio");
            }
            if (!(Enum.IsDefined(typeof(MetodoPago), this._metodoDePago)))
            {
                throw new Exception("Ingrese un metodo de pago valido");
            }
        }

        private void ValidarMonto()
        {
            if (!(this.Monto > 0))
            {
                throw new Exception("Ingrese un monto valido");
            }
        }

        private void ValidarDescripcion()
        {
            if (string.IsNullOrWhiteSpace(this.Descripcion))
            {
                throw new Exception("Ingrese una descripcion");
            }
        }

        private void ValidarFechaCompra()
        {
            if (this.FechaCompra > DateTime.Now || this.FechaCompra == DateTime.MinValue)
            {
                throw new Exception("Ingrese una fecha de compra valida");
            }
        }

        public abstract void AplicarCalculosAlPago(Pago nuevoPago);

        public virtual void Validar()
        {
            ValidarMetodoPago();
            ValidarMonto();
            ValidarDescripcion();
            ValidarFechaCompra();
        }

    }
}