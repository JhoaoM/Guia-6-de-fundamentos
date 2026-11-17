using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int opcion;
        do
        {
            MostrarMenu();

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Escribe solo números.");
                opcion = -1;
                continue;
            }

            if (opcion == 1)
            {
                OpcionRegistrar();
            }
            else if (opcion == 2)
            {
                OpcionPrestar();
            }
            else if (opcion == 3)
            {
                OpcionDevolver();
            }
            else if (opcion == 4)
            {
                OpcionListar();
            }
            else if (opcion == 5)
            {
                OpcionContarPorCategoria();
            }
            else if (opcion != 0)
            {
                Console.WriteLine("Opción no válida.");
            }
        } while (opcion != 0);

        Console.WriteLine("Programa terminado.");
    }

    // Muestra las opciones del menú principal
    static void MostrarMenu()
    {
        Console.WriteLine("\nPRÉSTAMO DE EQUIPOS");
        Console.WriteLine("1. Registrar equipo");
        Console.WriteLine("2. Prestar equipo");
        Console.WriteLine("3. Devolver equipo");
        Console.WriteLine("4. Listar disponibilidad");
        Console.WriteLine("5. Disponibles por categoría");
        Console.WriteLine("0. Salir");
        Console.Write("Elige una opción: ");
    }

    static void OpcionRegistrar()
    {
        Console.Write("Código: ");
        string codigo = Console.ReadLine();
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Categoría: ");
        string categoria = Console.ReadLine();

        Console.WriteLine(Inventario.RegistrarEquipo(codigo, nombre, categoria));
    }

    static void OpcionPrestar()
    {
        Console.Write("Código: ");
        string codigo = Console.ReadLine();
        Console.Write("Estudiante: ");
        string estudiante = Console.ReadLine();
        Console.Write("Fecha (ejemplo 13/11/2026): ");
        string fecha = Console.ReadLine();

        Console.WriteLine(Inventario.PrestarEquipo(codigo, estudiante, fecha));
    }

    static void OpcionDevolver()
    {
        Console.Write("Código: ");
        string codigo = Console.ReadLine();

        Console.WriteLine(Inventario.DevolverEquipo(codigo));
    }

    static void OpcionListar()
    {
        List<string> lineas = Inventario.ListarDisponibilidad();
        if (lineas.Count == 0)
        {
            Console.WriteLine("No hay equipos registrados.");
        }
        foreach (string linea in lineas)
        {
            Console.WriteLine(linea);
        }
    }

    static void OpcionContarPorCategoria()
    {
        Console.Write("Categoría: ");
        string categoria = Console.ReadLine();
        int cantidad = Inventario.ContarDisponiblesPorCategoria(categoria);
        Console.WriteLine("Disponibles en " + categoria + ": " + cantidad);
    }
}
