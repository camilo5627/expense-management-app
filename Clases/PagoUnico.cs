using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class PagoUnico : Pago
    {
        private int _numeroRecibo;

        public int NumeroRecibo
        {
            get { return _numeroRecibo; }
            set { _numeroRecibo = value; }
        }

        public PagoUnico()
        {

        }

        public PagoUnico(DateTime fechaCompra, string descripcion, MetodoPago metodoDePago, Gasto tipoDeGasto, Usuario usuario, double monto, int numeroRecibo) : base(fechaCompra, descripcion, metodoDePago, tipoDeGasto, usuario, monto)
        {
            _numeroRecibo = numeroRecibo;
        }


        private void ValidarNumeroRecibo()
        {
            if (this._numeroRecibo <= 0)
            {
                throw new Exception("Ingrese un numero de recibo valido");
            }
        }

        public override void AplicarCalculosAlPago(Pago nuevoPago)
        {
            if (nuevoPago.MetodoDePago == MetodoPago.EFECTIVO)
            {
                nuevoPago.Monto = Monto - (Monto * 0.20);
            }
            else
            {
                nuevoPago.Monto = Monto - (Monto * 0.10);
            }
        }

        public override void Validar()
        {
            base.Validar();
            ValidarNumeroRecibo();
        }

    }
}