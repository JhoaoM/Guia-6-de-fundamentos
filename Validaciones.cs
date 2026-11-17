using System.Collections.Generic;

public static class Validaciones
{
    public static bool TextoValido(string texto)
    {
        if (texto == "") return false;
        return true;
    }

    public static int BuscarPosicion(List<string> codigos, string codigo)
    {
        for (int i = 0; i < codigos.Count; i++)
        {
            if (codigos[i] == codigo) return i;
        }
        return -1;
    }
}
