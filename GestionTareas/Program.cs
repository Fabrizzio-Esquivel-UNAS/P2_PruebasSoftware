using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace ListaDeHabitaciones
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Habitacion> habitaciones = new List<Habitacion>();
            while (true)
            {
                Console.WriteLine("Sistema de Gestion de habitaciones");
                Console.WriteLine("1. Agregar habitacion");
                Console.WriteLine("2. Eliminar habitación");
                Console.WriteLine("3. Listar habitaciones");
                Console.WriteLine("4. Alquilar habitación");
                Console.WriteLine("5. Desocupar habitación");
                Console.WriteLine("6. Salir");

                string? entrada = Console.ReadLine();
                RedirigirEntrada(entrada, habitaciones);
            }
        }

        static void AgregarHabitacion(List<Habitacion> habitaciones)
        {
            Console.WriteLine("Ingrese la descripción de la habitación:");
            string? descripcion = Console.ReadLine();
            AgregarHabitacion(habitaciones, descripcion);            
        }

        static void EliminarHabitacion(List<Habitacion> habitaciones)
        {
            Console.WriteLine("Ingrese el número de la habitación a eliminar:");
            EliminarHabitacion(habitaciones, Console.ReadLine());
        }

        static void ListarHabitaciones(List<Habitacion> habitaciones)
        {
            if (habitaciones.Count == 0)
            {
                Console.WriteLine("No hay habitaciones.");
                return;
            }

            for (int i = 0; i < habitaciones.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {habitaciones[i].Descripcion} - {(habitaciones[i].Ocupada ? "Ocupada" : "Disponible")}");
            }
        }

        static void MarcarHabitacionOcupada(List<Habitacion> habitaciones)
        {
            Console.WriteLine("Ingrese el número de la habitación para alquilar:");
            MarcarHabitacionOcupada(habitaciones, Console.ReadLine());
        }

        static void MarcarHabitacionDesocupada(List<Habitacion> habitaciones)
        {
            Console.WriteLine("Ingrese el número de la habitación para desocupar:");
            MarcarHabitacionDesocupada(habitaciones, Console.ReadLine());
        }


        //Metodos publicos
        public static void AgregarHabitacion(List<Habitacion> habitaciones, string? descripcion)
        {
            if (descripcion == null)
            {
                throw new ArgumentNullException(nameof(descripcion), "La descripción de la habitacion no puede ser nula.");
            }
            habitaciones.Add(new Habitacion { Descripcion = descripcion, Ocupada = false });
            Console.WriteLine("Habitacion agregada.");
        }

        public static void EliminarHabitacion(List<Habitacion> habitaciones, string? entrada)
        {
            if (entrada == null)
            {
                throw new ArgumentNullException(nameof(entrada), "La entrada no es valida.");
            }

            int indice = int.Parse(entrada);

            if (indice > 0 && indice <= habitaciones.Count)
            {
                if (habitaciones[indice - 1].Ocupada)
                {
                    throw new ArgumentNullException(nameof(indice), "No se puede eliminar una Habitación Ocupada.");
                }
                habitaciones.RemoveAt(indice - 1);
                Console.WriteLine("Habitacion eliminada.");
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(indice), "Índice no válido.");
            }
        }

        public static void MarcarHabitacionOcupada(List<Habitacion> habitaciones, string? entrada)
        {
            if (entrada == null)
            {
                throw new ArgumentNullException(nameof(entrada), "La entrada no es valida.");
            }

            int indice = int.Parse(entrada);

            if (indice > 0 && indice <= habitaciones.Count)
            {
                if (habitaciones[(int)indice - 1].Ocupada)
                {
                    throw new ArgumentNullException(nameof(entrada), "La habitación se encuentra Ocupada.");
                }
                habitaciones[(int)indice - 1].Ocupada = true;
                Console.WriteLine("Habitacion marcada como Ocupada.");
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(indice), "Índice no válido.");
            }
        }

        public static void MarcarHabitacionDesocupada(List<Habitacion> habitaciones, string? entrada)
        {
            if (entrada == null)
            {
                throw new ArgumentNullException(nameof(entrada), "La entrada no es valida.");
            }

            int indice = int.Parse(entrada);

            if (indice > 0 && indice <= habitaciones.Count)
            {
                habitaciones[(int)indice - 1].Ocupada = false;
                Console.WriteLine("Habitacion marcada como Desocupada.");
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(indice), "Índice no válido.");
            }
        }

        public static bool RedirigirEntrada(string? entrada, List<Habitacion> habitaciones, bool prueba = false)
        {
            if (entrada == null)
            {
                throw new ArgumentNullException(nameof(entrada), "La entrada es invalida.");
            }

            int opcion = int.Parse(entrada);
            if (prueba)
            {
                switch (opcion)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        return true;
                    case 6:
                        return true;
                    default:
                        throw new ArgumentNullException(nameof(entrada), "La entrada no es valida.");
                }
                return true;
            }
            switch (opcion)
            {
                case 1:
                    AgregarHabitacion(habitaciones);
                    break;
                case 2:
                    EliminarHabitacion(habitaciones);
                    break;
                case 3:
                    ListarHabitaciones(habitaciones);
                    break;
                case 4:
                    MarcarHabitacionOcupada(habitaciones);
                    break;
                case 5:
                    MarcarHabitacionDesocupada(habitaciones);
                    return true;
                case 6:
                    return true;
                default:
                    throw new ArgumentNullException(nameof(entrada), "La entrada no es valida.");
            }
            return true;
        }
    }

    public class Habitacion
    {
        public required string Descripcion { get; set; }
        public bool Ocupada { get; set; }
    }
}
