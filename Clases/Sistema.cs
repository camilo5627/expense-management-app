using Clases.Ordenamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Sistema
    {
        private List<Pago> _pagos = new List<Pago>();
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Equipo> _equipos = new List<Equipo>();
        private List<Gasto> _gastos = new List<Gasto>();
        private static Sistema _instancia;

        public static Sistema Instancia
        {
            get
            {
                if (Sistema._instancia == null)
                {
                    _instancia = new Sistema();
                }
                return _instancia;
            }
        }

        private Sistema()
        {

            PrecargaEquipos();


            PrecargaUsuarios();
            PrecargaGastos();


            PrecargaPagos();
        }

        public List<Usuario> Usuarios
        {
            get { return new List<Usuario>(this._usuarios); }
        }
        public List<Pago> Pagos
        {
            get { return new List<Pago>(this._pagos); }
        }

        public List<Equipo> Equipos
        {
            get { return new List<Equipo>(this._equipos); }
        }
        public List<Gasto> Gastos
        {
            get { return new List<Gasto>(this._gastos); }
        }


        public void AltaUsuario(Usuario nuevoUsuario)
        {
            nuevoUsuario.Validar();
            nuevoUsuario.Email = GenerarMail(nuevoUsuario.Nombre, nuevoUsuario.Apellido);
            if (this._usuarios.Contains(nuevoUsuario))
            {
                throw new Exception("Usuario ya existente");
            }
            this._usuarios.Add(nuevoUsuario);
        }

        public void AltaEquipo(Equipo nuevoEquipo)
        {
            nuevoEquipo.AsignarId(nuevoEquipo);
            if (this._equipos.Contains(nuevoEquipo))
            {
                throw new Exception("Usuario ya existente");
            }

            this._equipos.Add(nuevoEquipo);
        }


        public void AltaGasto(Gasto nuevoGasto)
        {
            nuevoGasto.Validar();
            if (ExisteGasto(nuevoGasto))
            {
                throw new Exception("Gasto ya Existente");
            }
            _gastos.Add(nuevoGasto);
        }

        public void BajaGasto(Gasto gastoAEliminar)
        {
            if (ExisteGasto(gastoAEliminar))
            {
                if (!GastoEsUtilizado(gastoAEliminar))
                {
                    _gastos.Remove(gastoAEliminar);
                }
                else
                {
                    throw new Exception("El gasto está siendo utilizado actualmente");
                }
            }
            else
            {
                throw new Exception("No se encontró el Gasto seleccionado");
            }

        }

        public bool GastoEsUtilizado(Gasto gasto)
        {
            foreach (Pago pago in Pagos)
            {
                if (pago.TipoDeGasto.Id == gasto.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public void AltaPago(Pago nuevoPago)
        {
            if (nuevoPago != null && !_pagos.Contains(nuevoPago))
            {
                nuevoPago.Validar();
                nuevoPago.AplicarCalculosAlPago(nuevoPago);
                this._pagos.Add(nuevoPago);
            }
        }

        public void PrecargaEquipos()
        {
            AltaEquipo(new Equipo("Desarrollo"));
            AltaEquipo(new Equipo("Marketing"));
            AltaEquipo(new Equipo("Soporte"));
            AltaEquipo(new Equipo("Administración"));
        }

        public void PrecargaUsuarios()
        {
            AltaUsuario(new Usuario("Juan", "Perez", "claveSegura1", GenerarMail("Juan", "Perez"), new DateTime(2020, 5, 10), BuscarEquipoPorId(1), Rol.Empleado));
            AltaUsuario(new Usuario("Ana", "Gomez", "claveSegura2", GenerarMail("Ana", "Gomez"), new DateTime(2019, 7, 20), BuscarEquipoPorId(2), Rol.Gerente));
            AltaUsuario(new Usuario("Carlos", "Rodriguez", "claveSegura3", GenerarMail("Carlos", "Rodriguez"), new DateTime(2021, 3, 15), BuscarEquipoPorId(3), Rol.Gerente));
            AltaUsuario(new Usuario("Laura", "Fernandez", "claveSegura4", GenerarMail("Laura", "Fernandez"), new DateTime(2022, 1, 25), BuscarEquipoPorId(4), Rol.Empleado));
            AltaUsuario(new Usuario("Marta", "Suarez", "claveSegura5", GenerarMail("Marta", "Suarez"), new DateTime(2020, 8, 30), BuscarEquipoPorId(1), Rol.Empleado));
            AltaUsuario(new Usuario("Diego", "Lopez", "claveSegura6", GenerarMail("Diego", "Lopez"), new DateTime(2018, 6, 12), BuscarEquipoPorId(2), Rol.Gerente));
            AltaUsuario(new Usuario("Lucia", "Martinez", "claveSegura7", GenerarMail("Lucia", "Martinez"), new DateTime(2021, 4, 1), BuscarEquipoPorId(3), Rol.Empleado));
            AltaUsuario(new Usuario("Pedro", "Ramirez", "claveSegura8", GenerarMail("Pedro", "Ramirez"), new DateTime(2022, 11, 10), BuscarEquipoPorId(4), Rol.Empleado));
            AltaUsuario(new Usuario("Sofia", "Mendez", "claveSegura9", GenerarMail("Sofia", "Mendez"), new DateTime(2019, 9, 19), BuscarEquipoPorId(1), Rol.Empleado));
            AltaUsuario(new Usuario("Hugo", "Castro", "claveSegura10", GenerarMail("Hugo", "Castro"), new DateTime(2020, 12, 5), BuscarEquipoPorId(2), Rol.Empleado));
            AltaUsuario(new Usuario("Valentina", "Silva", "claveSegura11", GenerarMail("Valentina", "Silva"), new DateTime(2022, 2, 17), BuscarEquipoPorId(3), Rol.Empleado));
            AltaUsuario(new Usuario("Pablo", "Rios", "claveSegura12", GenerarMail("Pablo", "Rios"), new DateTime(2021, 6, 9), BuscarEquipoPorId(4), Rol.Empleado));
            AltaUsuario(new Usuario("Camila", "Morales", "claveSegura13", GenerarMail("Camila", "Morales"), new DateTime(2020, 5, 23), BuscarEquipoPorId(1), Rol.Empleado));
            AltaUsuario(new Usuario("Esteban", "Navarro", "claveSegura14", GenerarMail("Esteban", "Navarro"), new DateTime(2019, 12, 14), BuscarEquipoPorId(2), Rol.Empleado));
            AltaUsuario(new Usuario("Florencia", "Herrera", "claveSegura15", GenerarMail("Florencia", "Herrera"), new DateTime(2022, 10, 7), BuscarEquipoPorId(3), Rol.Empleado));
            AltaUsuario(new Usuario("Ignacio", "Vega", "claveSegura16", GenerarMail("Ignacio", "Vega"), new DateTime(2021, 3, 30), BuscarEquipoPorId(4), Rol.Gerente));
            AltaUsuario(new Usuario("Cecilia", "Ortega", "claveSegura17", GenerarMail("Cecilia", "Ortega"), new DateTime(2020, 1, 18), BuscarEquipoPorId(1), Rol.Empleado));
            AltaUsuario(new Usuario("Ricardo", "Santos", "claveSegura18", GenerarMail("Ricardo", "Santos"), new DateTime(2018, 7, 28), BuscarEquipoPorId(2), Rol.Gerente));
            AltaUsuario(new Usuario("Daniela", "Aguilar", "claveSegura19", GenerarMail("Daniela", "Aguilar"), new DateTime(2022, 4, 2), BuscarEquipoPorId(3), Rol.Empleado));
            AltaUsuario(new Usuario("Tomas", "Paredes", "claveSegura20", GenerarMail("Tomas", "Paredes"), new DateTime(2021, 8, 21), BuscarEquipoPorId(4), Rol.Empleado));
            AltaUsuario(new Usuario("Melina", "Blanco", "claveSegura21", GenerarMail("Melina", "Blanco"), new DateTime(2019, 3, 3), BuscarEquipoPorId(1), Rol.Gerente));
            AltaUsuario(new Usuario("Gabriel", "Torres", "claveSegura22", GenerarMail("Gabriel", "Torres"), new DateTime(2020, 9, 29), BuscarEquipoPorId(2), Rol.Empleado));
        }

        public void PrecargaGastos()
        {
            AltaGasto(new Gasto("Transporte", "Gasto mensual en transporte público"));
            AltaGasto(new Gasto("Comida", "Gasto diario en almuerzos"));
            AltaGasto(new Gasto("Internet", "Pago mensual del servicio de internet"));
            AltaGasto(new Gasto("Luz", "Factura de electricidad"));
            AltaGasto(new Gasto("Agua", "Factura de agua corriente"));
            AltaGasto(new Gasto("Teléfono", "Línea móvil personal"));
            AltaGasto(new Gasto("Software", "Suscripción de herramientas digitales"));
            AltaGasto(new Gasto("Publicidad", "Campañas digitales"));
            AltaGasto(new Gasto("Eventos", "Organización de eventos internos"));
            AltaGasto(new Gasto("Papelería", "Compra de insumos de oficina"));
        }

        public void PrecargaPagos()
        {

            AltaPago(new PagoRecurrente(new DateTime(2024, 1, 10), "Gasto de transporte", MetodoPago.DEBITO, BuscarGastoPorNombre("Transporte"), BuscarUsuarioPorMail("juaper@laEmpresa.com"), 1500, new DateTime(2025, 1, 10)));
            AltaPago(new PagoRecurrente(new DateTime(2024, 4, 10), "Gasto de transporte", MetodoPago.DEBITO, BuscarGastoPorNombre("Transporte"), BuscarUsuarioPorMail("juaper@laEmpresa.com"), 1500, new DateTime(2025, 5, 10)));
            AltaPago(new PagoRecurrente(new DateTime(2024, 5, 10), "Gasto de transporte", MetodoPago.DEBITO, BuscarGastoPorNombre("Transporte"), BuscarUsuarioPorMail("juaper@laEmpresa.com"), 1500, new DateTime(2025, 6, 10)));
            AltaPago(new PagoRecurrente(new DateTime(2024, 8, 5), "Pago de luz", MetodoPago.CREDITO, BuscarGastoPorNombre("Luz"), BuscarUsuarioPorMail("anagom@laEmpresa.com"), 200, new DateTime(2025, 8, 5)));
            AltaPago(new PagoRecurrente(new DateTime(2024, 5, 1), "Pago de agua", MetodoPago.EFECTIVO, BuscarGastoPorNombre("Agua"), BuscarUsuarioPorMail("carrod@laEmpresa.com"), 100, new DateTime(2025, 9, 1)));


            AltaPago(new PagoRecurrente(new DateTime(2024, 2, 10), "Gasto de transporte", MetodoPago.DEBITO, BuscarGastoPorNombre("Transporte"), BuscarUsuarioPorMail("juaper@laEmpresa.com"), 1500, new DateTime(2026, 12, 10)));
            AltaPago(new PagoRecurrente(new DateTime(2024, 3, 10), "Gasto de transporte", MetodoPago.DEBITO, BuscarGastoPorNombre("Transporte"), BuscarUsuarioPorMail("juaper@laEmpresa.com"), 1500, new DateTime(2026, 1, 10)));

            AltaPago(new PagoRecurrente(new DateTime(2024, 6, 5), "Pago de luz", MetodoPago.CREDITO, BuscarGastoPorNombre("Luz"), BuscarUsuarioPorMail("anagom@laEmpresa.com"), 200, new DateTime(2026, 6, 5)));
            AltaPago(new PagoRecurrente(new DateTime(2024, 7, 5), "Pago de luz", MetodoPago.CREDITO, BuscarGastoPorNombre("Luz"), BuscarUsuarioPorMail("anagom@laEmpresa.com"), 200, new DateTime()));
            AltaPago(new PagoRecurrente(new DateTime(2024, 9, 5), "Pago de luz", MetodoPago.CREDITO, BuscarGastoPorNombre("Luz"), BuscarUsuarioPorMail("anagom@laEmpresa.com"), 200, new DateTime(2026, 6, 5)));

            AltaPago(new PagoRecurrente(new DateTime(2024, 3, 1), "Pago de agua", MetodoPago.EFECTIVO, BuscarGastoPorNombre("Agua"), BuscarUsuarioPorMail("carrod@laEmpresa.com"), 100, new DateTime(2026, 3, 1)));
            AltaPago(new PagoRecurrente(new DateTime(2024, 4, 1), "Pago de agua", MetodoPago.EFECTIVO, BuscarGastoPorNombre("Agua"), BuscarUsuarioPorMail("carrod@laEmpresa.com"), 100, new DateTime(2026, 3, 1)));

            AltaPago(new PagoRecurrente(new DateTime(2024, 6, 10), "Pago de internet", MetodoPago.DEBITO, BuscarGastoPorNombre("Internet"), BuscarUsuarioPorMail("laufer@laEmpresa.com"), 80, new DateTime(2026, 6, 10)));
            AltaPago(new PagoRecurrente(new DateTime(2024, 7, 10), "Pago de internet", MetodoPago.DEBITO, BuscarGastoPorNombre("Internet"), BuscarUsuarioPorMail("laufer@laEmpresa.com"), 80, new DateTime(2026, 6, 10)));
            AltaPago(new PagoRecurrente(new DateTime(2024, 8, 10), "Pago de internet", MetodoPago.DEBITO, BuscarGastoPorNombre("Internet"), BuscarUsuarioPorMail("laufer@laEmpresa.com"), 80, new DateTime()));

            AltaPago(new PagoRecurrente(new DateTime(2024, 9, 1), "Gasto de papelería", MetodoPago.CREDITO, BuscarGastoPorNombre("Papelería"), BuscarUsuarioPorMail("marsua@laEmpresa.com"), 500, new DateTime(2026, 9, 1)));
            AltaPago(new PagoRecurrente(new DateTime(2024, 10, 1), "Gasto de papelería", MetodoPago.CREDITO, BuscarGastoPorNombre("Papelería"), BuscarUsuarioPorMail("marsua@laEmpresa.com"), 500, new DateTime(2026, 9, 1)));

            AltaPago(new PagoRecurrente(new DateTime(2024, 1, 15), "Gasto de comida", MetodoPago.EFECTIVO, BuscarGastoPorNombre("Comida"), BuscarUsuarioPorMail("dielop@laEmpresa.com"), 70, new DateTime(2026, 1, 15)));
            AltaPago(new PagoRecurrente(new DateTime(2024, 2, 15), "Gasto de comida", MetodoPago.EFECTIVO, BuscarGastoPorNombre("Comida"), BuscarUsuarioPorMail("dielop@laEmpresa.com"), 70, new DateTime(2026, 1, 15)));

            AltaPago(new PagoRecurrente(new DateTime(2024, 3, 20), "Gasto de papelería", MetodoPago.DEBITO, BuscarGastoPorNombre("Papelería"), BuscarUsuarioPorMail("lucmar@laEmpresa.com"), 120, new DateTime(2026, 3, 20)));
            AltaPago(new PagoRecurrente(new DateTime(2024, 4, 20), "Gasto de papelería", MetodoPago.DEBITO, BuscarGastoPorNombre("Papelería"), BuscarUsuarioPorMail("lucmar@laEmpresa.com"), 120, new DateTime()));
            AltaPago(new PagoRecurrente(new DateTime(2024, 5, 20), "Gasto de papelería", MetodoPago.DEBITO, BuscarGastoPorNombre("Papelería"), BuscarUsuarioPorMail("lucmar@laEmpresa.com"), 120, new DateTime(2026, 3, 20)));

            AltaPago(new PagoRecurrente(new DateTime(2024, 6, 30), "Gasto de publicidad", MetodoPago.CREDITO, BuscarGastoPorNombre("Publicidad"), BuscarUsuarioPorMail("pedram@laEmpresa.com"), 600, new DateTime(2026, 6, 30)));
            AltaPago(new PagoRecurrente(new DateTime(2024, 7, 30), "Gasto de publicidad", MetodoPago.CREDITO, BuscarGastoPorNombre("Publicidad"), BuscarUsuarioPorMail("pedram@laEmpresa.com"), 600, new DateTime()));
            AltaPago(new PagoRecurrente(new DateTime(2024, 8, 30), "Gasto de publicidad", MetodoPago.CREDITO, BuscarGastoPorNombre("Publicidad"), BuscarUsuarioPorMail("pedram@laEmpresa.com"), 600, new DateTime(2026, 6, 30)));


            AltaPago(new PagoUnico(new DateTime(2024, 2, 10), "Transporte para reunión", MetodoPago.EFECTIVO, BuscarGastoPorNombre("Transporte"), BuscarUsuarioPorMail("sofmen@laEmpresa.com"), 300, 1001));
            AltaPago(new PagoUnico(new DateTime(2024, 3, 15), "Licencia de software", MetodoPago.DEBITO, BuscarGastoPorNombre("Software"), BuscarUsuarioPorMail("hugcas@laEmpresa.com"), 400, 1002));
            AltaPago(new PagoUnico(new DateTime(2024, 4, 2), "Compra de insumos de papelería", MetodoPago.CREDITO, BuscarGastoPorNombre("Papelería"), BuscarUsuarioPorMail("valsil@laEmpresa.com"), 120, 1003));
            AltaPago(new PagoUnico(new DateTime(2024, 5, 8), "Repuesto de router", MetodoPago.DEBITO, BuscarGastoPorNombre("Internet"), BuscarUsuarioPorMail("pabrio@laEmpresa.com"), 80, 1004));
            AltaPago(new PagoUnico(new DateTime(2024, 6, 11), "Comida para evento", MetodoPago.EFECTIVO, BuscarGastoPorNombre("Comida"), BuscarUsuarioPorMail("cammor@laEmpresa.com"), 70, 1005));
            AltaPago(new PagoUnico(new DateTime(2024, 7, 9), "Publicidad extra", MetodoPago.CREDITO, BuscarGastoPorNombre("Publicidad"), BuscarUsuarioPorMail("estnav@laEmpresa.com"), 600, 1006));
            AltaPago(new PagoUnico(new DateTime(2024, 8, 1), "Pago extra de luz", MetodoPago.DEBITO, BuscarGastoPorNombre("Luz"), BuscarUsuarioPorMail("floher@laEmpresa.com"), 200, 1007));
            AltaPago(new PagoUnico(new DateTime(2024, 9, 3), "Transporte para clientes", MetodoPago.EFECTIVO, BuscarGastoPorNombre("Transporte"), BuscarUsuarioPorMail("ignveg@laEmpresa.com"), 300, 1008));
            AltaPago(new PagoUnico(new DateTime(2024, 9, 18), "Licencia Photoshop", MetodoPago.DEBITO, BuscarGastoPorNombre("Software"), BuscarUsuarioPorMail("cecort@laEmpresa.com"), 400, 1009));
            AltaPago(new PagoUnico(new DateTime(2024, 10, 5), "Compra de cafetera", MetodoPago.CREDITO, BuscarGastoPorNombre("Comida"), BuscarUsuarioPorMail("ricsan@laEmpresa.com"), 70, 1010));
            AltaPago(new PagoUnico(new DateTime(2024, 11, 2), "Mantenimiento de papelería", MetodoPago.DEBITO, BuscarGastoPorNombre("Papelería"), BuscarUsuarioPorMail("danagu@laEmpresa.com"), 500, 1011));
            AltaPago(new PagoUnico(new DateTime(2024, 11, 20), "Transporte fin de año", MetodoPago.EFECTIVO, BuscarGastoPorNombre("Transporte"), BuscarUsuarioPorMail("tompar@laEmpresa.com"), 300, 1012));
            AltaPago(new PagoUnico(new DateTime(2024, 12, 10), "Pago de hosting anual", MetodoPago.DEBITO, BuscarGastoPorNombre("Internet"), BuscarUsuarioPorMail("melbla@laEmpresa.com"), 80, 1013));
            AltaPago(new PagoUnico(new DateTime(2024, 12, 20), "Licencia de software extra", MetodoPago.CREDITO, BuscarGastoPorNombre("Software"), BuscarUsuarioPorMail("gabtor@laEmpresa.com"), 400, 1014));
            AltaPago(new PagoUnico(new DateTime(2024, 6, 25), "Reparación de luz", MetodoPago.EFECTIVO, BuscarGastoPorNombre("Luz"), BuscarUsuarioPorMail("anagom@laEmpresa.com"), 200, 1015));
            AltaPago(new PagoUnico(new DateTime(2024, 5, 22), "Transporte para evento", MetodoPago.EFECTIVO, BuscarGastoPorNombre("Transporte"), BuscarUsuarioPorMail("juaper@laEmpresa.com"), 300, 1016));
            AltaPago(new PagoUnico(new DateTime(2024, 3, 11), "Compra de tóner", MetodoPago.CREDITO, BuscarGastoPorNombre("Papelería"), BuscarUsuarioPorMail("laufer@laEmpresa.com"), 120, 1017));
        }

        public double CalcularGastoMesActual(Usuario usuario)
        {
            double total = 0;
            DateTime fechaActual = DateTime.Now;

            foreach (Pago pago in _pagos)
            {

                bool MismoUsuario = pago.Usuario.Email == usuario.Email;


                bool MesActual = pago.FechaCompra.Month == fechaActual.Month &&
                                   pago.FechaCompra.Year == fechaActual.Year;


                if (MismoUsuario && MesActual)
                {
                    total += pago.Monto;
                }
            }

            return total;
        }

        public void OrdenarUsuariosXMail()
        {
            this._usuarios.Sort(new OrdenarUsuariosXMail());
        }

        public Gasto BuscarGastoPorID(int id)
        {
            foreach (Gasto gasto in _gastos)
            {
                if (gasto.Id == id)
                {
                    return gasto;
                }
            }
            throw new Exception("No se encontró el gasto");
        }
        public Usuario BuscarUsuarioPorID(int id)
        {
            foreach (Usuario usuario in _usuarios)
            {
                if (usuario.Id == id)
                {
                    return usuario;
                }
            }
            throw new Exception("No se encontró el usuario");
        }
        public Equipo BuscarEquipoPorId(int id)
        {
            foreach (Equipo equipo in _equipos)
            {
                if (equipo.IdEquipo == id)
                {
                    return equipo;
                }
            }
            throw new Exception("No se encontró el equipo");
        }

        public Gasto BuscarGastoPorNombre(string nombre)
        {
            foreach (Gasto gasto in _gastos)
            {
                if (gasto.Nombre.ToUpper() == nombre.ToUpper())
                {
                    return gasto;
                }
            }
            throw new Exception("No se encontró el gasto");
        }

        public Usuario BuscarUsuarioPorMail(string mail)
        {
            foreach (Usuario usuario in _usuarios)
            {
                if (usuario.Email == mail)
                {
                    return usuario;
                }
            }
            throw new Exception("No se encontró el usuario");
        }

        public string GenerarMail(string nombre, string apellido)
        {
            string parteNombre;
            if (nombre.Length > 3)
            {
                parteNombre = nombre.Substring(0, 3).ToLower();
            }
            else
            {
                parteNombre = nombre.ToLower();
            }

            string parteApellido;
            if (apellido.Length > 3)
            {
                parteApellido = apellido.Substring(0, 3).ToLower();
            }
            else
            {
                parteApellido = apellido.ToLower();
            }

            string baseMail = parteNombre + parteApellido + "@laEmpresa.com";
            string emailFinal = baseMail;

            int contador = 1;
            while (ExisteMail(emailFinal))
            {
                emailFinal = parteNombre + parteApellido + contador + "@laEmpresa.com";
                contador++;
            }
            return emailFinal;
        }

        public bool ExisteMail(string mail)
        {
            foreach (Usuario usuario in _usuarios)
            {
                if (usuario.Email == mail)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ExisteGasto(Gasto gasto)
        {
            if (this._gastos.Contains(gasto))
            {
                return true;
            }
            return false;
        }

        public bool ExisteUsuario(Usuario usuario)
        {
            if (this._usuarios.Contains(usuario))
            {
                return true;
            }
            return false;
        }

        public void OrdenarXMontoTotalDescendente()
        {
            this._pagos.Sort(new OrdenarXMontoTotalDescendente());
        }

        public List<Pago> FiltrarPagosPorGerenteYFecha(Usuario gerente, int mes, int anio)
        {
            List<Pago> resultado = new List<Pago>();
            DateTime inicioMesBuscado = new DateTime(anio, mes, 1);
            DateTime inicioMesSiguiente = inicioMesBuscado.AddMonths(1);
            Equipo equipoGerente = gerente.Equipo;
            int idEquipoGerente = equipoGerente.IdEquipo;
            foreach (Pago pago in _pagos)
            {
                Usuario usuarioPago = pago.Usuario;
                Equipo equipoPago = usuarioPago.Equipo;
                if (equipoPago.IdEquipo == idEquipoGerente)
                {
                    bool incluir = false;
                    if (pago is PagoUnico)
                    {
                        if (pago.FechaCompra.Month == mes && pago.FechaCompra.Year == anio)
                        {
                            incluir = true;
                        }
                    }
                    else if (pago is PagoRecurrente)
                    {
                        PagoRecurrente recurrente = (PagoRecurrente)pago;
                        bool pagoEmpezado = recurrente.FechaCompra < inicioMesSiguiente;
                        bool pagoNoTerminado = true;

                        if (recurrente.TieneLimite)
                        {
                            if (recurrente.FechaFin < inicioMesBuscado)
                            {
                                pagoNoTerminado = false;
                            }
                        }
                        if (pagoEmpezado && pagoNoTerminado)
                        {
                            incluir = true;
                        }
                    }
                    if (incluir)
                    {
                        resultado.Add(pago);
                    }
                }
            }
            resultado.Sort(new OrdenarXMontoTotalDescendente());
            return resultado;
        }
    }
}