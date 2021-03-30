namespace CmpCompiler.Core.Models
{
    public class Token
    {
        public Token(string valor, TipoToken tipo)
        {
            Valor = valor;
            Tipo = tipo;
        }

        public Token(long identificador, string valor, TipoToken tipo)
        {
            Identificador = identificador;
            Valor = valor;
            Tipo = tipo;
        }

        public long Identificador { get; set; }
        public string Valor { get; set; }
        public TipoToken Tipo { get; set; }

        public override string ToString()
        {
            if (this.Tipo == TipoToken.PALAVRA_RESERVADA)
                return $"[{this.Valor},]";
            return $"[id,{this.Identificador}]";
        }
    }
}
