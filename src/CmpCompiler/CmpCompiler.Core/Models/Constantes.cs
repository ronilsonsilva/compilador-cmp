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

        public static List<string> OperadorLogico
        {
            get
            {
                var lista = new List<string>();
                lista.Add("<");
                lista.Add("<=");
                lista.Add(">");
                lista.Add(">=");
                lista.Add("==");
                lista.Add("!=");
                lista.Add("!");
                return lista;
            }
        }

        public static bool EhOperadorLogico(this string valor)
        {
            return Constantes.OperadorLogico.Contains(valor);
        }
        
        public static List<string> OperadorMatematico
        {
            get
            {
                var lista = new List<string>();
                lista.Add("+");
                lista.Add("*");
                lista.Add("/");
                lista.Add("-");
                lista.Add("%");
                return lista;
            }
        }

        public static bool EhOperadorMatematico(this string valor)
        {
            return Constantes.OperadorMatematico.Contains(valor);
        }

        public static List<string> CondicionalLogica
        {
            get
            {
                var lista = new List<string>();
                lista.Add("||");
                lista.Add("&&");
                return lista;
            }
        }

        public static bool EhCondicionalLogica(this string valor)
        {
            return Constantes.CondicionalLogica.Contains(valor);
        }

        public static List<string> Caracteres
        {
            get
            {
                var lista = new List<string>();
                lista.Add("(");
                lista.Add(")");
                lista.Add(",");
                lista.Add("\"");
                return lista;
            }
        }

        public static bool EhCaracteres(this string valor)
        {
            return Constantes.Caracteres.Contains(valor) || (valor.StartsWith("\"") && valor.EndsWith("\""));
        }
    }
}
