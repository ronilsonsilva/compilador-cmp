using System.Collections.Generic;

namespace CmpCompiler.Core.Models
{
    public static class Constantes
    {
        public static List<string> PalavrasReservadas 
        { 
            get
            {
                var lista = new List<string>();
                lista.Add("inicio");
                lista.Add("fim");
                lista.Add("var");
                lista.Add("\"");
                lista.Add("leia");
                lista.Add("escreva");
                lista.Add("se");
                lista.Add("senao");
                lista.Add("(");
                lista.Add(")");
                lista.Add("=");
                lista.Add(";");
                return lista;
            }
        }

        public static bool EhPalavraReservada(this string valor)
        {
            return Constantes.PalavrasReservadas.Contains(valor);
        }
    }
}
