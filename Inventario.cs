using System.Collections.Generic;

public static class Inventario
{
    public static List<string> codigos = new List<string>();
    public static List<string> nombres = new List<string>();
    public static List<string> categorias = new List<string>();
    public static List<string> estados = new List<string>();
    public static List<string> prestamos = new List<string>();

    public static string RegistrarEquipo(string codigo, string nombre, string categoria)
    {
        if (!Validaciones.TextoValido(codigo) || !Validaciones.TextoValido(nombre)
            || !Validaciones.TextoValido(categoria))
        {
            return "Error: hay datos vacíos.";
        }
        if (Validaciones.BuscarPosicion(codigos, codigo) != -1)
        {
            return "Error: ya existe un equipo con ese código.";
        }
        codigos.Add(codigo);
        nombres.Add(nombre);
        categorias.Add(categoria);
        estados.Add("Disponible");
        return "Equipo registrado correctamente.";
    }

    public static string PrestarEquipo(string codigo, string estudiante, string fecha)
    {
        if (!Validaciones.TextoValido(codigo) || !Validaciones.TextoValido(estudiante)
            || !Validaciones.TextoValido(fecha))
        {
            return "Error: hay datos vacíos.";
        }
        int posicion = Validaciones.BuscarPosicion(codigos, codigo);
        if (posicion == -1)
        {
            return "Error: el código de equipo no existe.";
        }
        if (estados[posicion] != "Disponible")
        {
            return "Error: el equipo no está disponible.";
        }
        estados[posicion] = "Prestado";
        prestamos.Add(codigo + " - " + estudiante + " - " + fecha);
        return "Préstamo registrado correctamente.";
    }

    public static string DevolverEquipo(string codigo)
    {
        if (!Validaciones.TextoValido(codigo))
        {
            return "Error: hay datos vacíos.";
        }
        int posicion = Validaciones.BuscarPosicion(codigos, codigo);
        if (posicion == -1)
        {
            return "Error: el código de equipo no existe.";
        }
        if (estados[posicion] == "Disponible")
        {
            return "Error: el equipo ya estaba disponible.";
        }
        estados[posicion] = "Disponible";
        return "Devolución registrada correctamente.";
    }

    public static List<string> ListarDisponibilidad()
    {
        List<string> lineas = new List<string>();
        for (int i = 0; i < codigos.Count; i++)
        {
            lineas.Add(codigos[i] + " | " + nombres[i] + " | " + categorias[i] + " | " + estados[i]);
        }
        return lineas;
    }

    public static int ContarDisponiblesPorCategoria(string categoria)
    {
        int cantidad = 0;
        for (int i = 0; i < categorias.Count; i++)
        {
            if (categorias[i] == categoria && estados[i] == "Disponible")
            {
                cantidad++;
            }
        }
        return cantidad;
    }
}
