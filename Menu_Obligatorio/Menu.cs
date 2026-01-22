using Clases;
namespace Obligatorio
{
    internal class Menu
    {
       private static Sistema sistema = Sistema.Instancia;
        static void Main(string[] args)
        {
            sistema.PrecargaEquipos();
            sistema.PrecargaUsuarios();
            sistema.PrecargaGastos();
            sistema.PrecargaPagos();
            string seleccion = "";
            while (seleccion != "0")
            {
                MostrarMenu();
                seleccion = Console.ReadLine();
                switch (seleccion)
                {
                    case "1":
                        ListaDeUsuarios();
                        break;

                    case "2":
                        PagosDeUnUsuario();
                    break;

                    case "3":
                        RegistrarUsuario();
                        break;

                    case "4":
                       MostrarUsuariosDeEquipo();
                        break;

                    case "0":
                        Console.WriteLine("Nos vemos!");
                    break;

                    default:
                        Console.WriteLine("Ingrese una opción valida.");
                    break;
                }
            } 
            
            
            static void ListaDeUsuarios()
            {
                Console.WriteLine("Usuarios");
                foreach (Usuario usuario in sistema.Usuarios)
                {
                    Console.WriteLine(usuario.ToString());
                }
            }

            static void PagosDeUnUsuario()
            {
                Console.WriteLine("Ingrese el mail del usuario");
                string mailIngresado = Console.ReadLine();
                try
                {
                    foreach (Pago pago in sistema.Pagos)
                    {
                        if (pago.Usuario.Email == mailIngresado)
                        {
                            Console.WriteLine(pago.ToString());
                            Console.WriteLine("---------------------------");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Mail no encontrado");
                }   
            }

            static void RegistrarUsuario()
            {
                Console.WriteLine("Ingrese nombre del usuario");
                string nombreUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese apellido del usuario");
                string apellidoUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese contrasenia del usuario");
                string contrseniaUsuario = Console.ReadLine();

                foreach (Equipo equipo in sistema.Equipos)
                {
                    Console.WriteLine(equipo.ToString());
                }
                try
                {
                    int idEquipoSeleccionado = SolicitarInt("Seleccione el equipo del usuario (ingrese el numero asignado)", 0, sistema.Equipos.Count + 1);
                    Equipo equipoUsuario = sistema.ObtenerEquipoPorID(idEquipoSeleccionado);

                    DateTime fechaDelUsuario = SolicitarDateTime("Ingrese la fecha de ingreso del usuario (formato dd/mm/aaaa)", DateTime.Now.AddYears(-50), DateTime.Now);
                    Usuario nuevoUsuario = new Usuario(nombreUsuario, apellidoUsuario, contrseniaUsuario, sistema.GenerarMail(nombreUsuario, apellidoUsuario), fechaDelUsuario, equipoUsuario);
                    sistema.AltaUsuario(nuevoUsuario);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al ingresar el usuario");
                }
             }

            static void MostrarUsuariosDeEquipo()
            {
                Console.WriteLine("Ingrese un equipo");
                string equipoIngresado = Console.ReadLine();
                foreach (Usuario usuario in sistema.Usuarios)
                {
                    string usuarioActual = usuario.Equipo.Nombre.ToLower();
                    if (usuarioActual == equipoIngresado.ToLower())
                    {
                        Console.WriteLine(usuario.ToString());
                    }
                }
            }

            static int SolicitarInt(string mensaje, int min, int max)
            {
                int aRetornar = 0;
                bool esCorrecto = false;
                while (!esCorrecto)
                {
                    try
                    {
                        Console.WriteLine(mensaje);
                        string seleccionUsuario = Console.ReadLine();
                        aRetornar = int.Parse(seleccionUsuario);
                        if (aRetornar < min || aRetornar > max)
                        {
                            Console.WriteLine($"Solo se aceptan numeros entre {min} y {max}.");
                        }
                        else
                        {
                            esCorrecto = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ingrese un numero valido.");
                    }
                }

                return aRetornar;
            }

            static DateTime SolicitarDateTime(string mensaje, DateTime min, DateTime max)
                {
                    DateTime aRetornar = DateTime.Now;
                    bool esCorrecto = false;
                    while (!esCorrecto)
                    {
                        try
                        {
                            Console.WriteLine(mensaje);
                            string seleccionUsuario = Console.ReadLine();
                            aRetornar = DateTime.Parse(seleccionUsuario);
                            if (aRetornar < min || aRetornar > max)
                            {
                                Console.WriteLine($"Solo se aceptan fechas entre {min} y {max}.");
                            }
                            else
                            {
                                esCorrecto = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ingrese una fecha valida.");
                        }
                    }

                    return aRetornar;
                }
            
            static void MostrarMenu()
            {
                Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
                Console.WriteLine("1 - Ver los usuarios");
                Console.WriteLine("2 - Mostrar los pagos de un usuario");
                Console.WriteLine("3 - Registrar un usuario");
                Console.WriteLine("4 - Mostrar usuarios de un equipo");
                Console.WriteLine("0 - Salir");
            }
        }

            
    }
}
    

