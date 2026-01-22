using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class PagoRecurrente : Pago
    {
        private DateTime _fechaFin;
        private bool _tieneLimite;

        public DateTime FechaFin
        {
            get { return _fechaFin; }
            set { _fechaFin = value; }
        }
        public bool TieneLimite
        {
            get { return _tieneLimite; }
            set { _tieneLimite = value; }
        }

        public PagoRecurrente()
        {

        }

        public PagoRecurrente(DateTime fechaCompra, string descripcion, MetodoPago metodoDePago, Gasto tipoGasto, Usuario usuario, double monto, DateTime fechaFin) : base(fechaCompra, descripcion, metodoDePago, tipoGasto, usuario, monto)
        {
            _fechaFin = fechaFin;
        }

        private void ValidarFechaFin()
        {
            if (FechaFin == DateTime.MinValue)
            {
                TieneLimite = false;
            }
            else
            {
                if (this.FechaFin < this.FechaCompra)
                {
                    throw new Exception("Ingrese una fecha de fin valida");
                }
                TieneLimite = true;
            }
        }


        public override void Validar()
        {
            base.Validar();
            ValidarFechaFin();
        }

        public int CantidadDeMesesRestantes(DateTime fechaFin)
        {

            if (fechaFin <= DateTime.Now)
            {
                return 0;
            }

            int meses = ((fechaFin.Year - DateTime.Now.Year) * 12) + fechaFin.Month - DateTime.Now.Month;


            if (fechaFin.Day > DateTime.Now.Day)
            {
                meses = meses - 1;
            }


            if (meses >= 0)
            {
                return meses;
            }
            else
            {
                return 0;
            }
        }

        public override void AplicarCalculosAlPago(Pago nuevoPago)
        {
            if (TieneLimite)
            {
                int meses = CantidadDeMesesRestantes(this.FechaFin);

                if (meses <= 0)
                {

                    nuevoPago.Monto = Monto;
                    return;
                }
                if (meses >= 10)
                {
                    nuevoPago.Monto = Monto + (Monto * 0.10);
                }
                else if (meses >= 6)
                {
                    nuevoPago.Monto = Monto + (Monto * 0.05);
                }
                else
                {
                    nuevoPago.Monto = Monto + (Monto * 0.03);
                }
            }
            else
            {

                nuevoPago.Monto = Monto + (Monto * 0.03);
            }
        }
    }
}