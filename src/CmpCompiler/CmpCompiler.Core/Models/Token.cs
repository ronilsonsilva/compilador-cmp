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
            else if(this.Tipo == TipoToken.CL)
                return $"[CL,{this.Valor}]";
            else if (this.Tipo == TipoToken.FR)
                return $"[FR,{this.Valor}]";
            else if (this.Tipo == TipoToken.ID)
                return $"[ID,{this.Valor}]";
            else if (this.Tipo == TipoToken.NU)
                return $"[NU,{this.Valor}]";
            else if (this.Tipo == TipoToken.OL)
                return $"[OL,{this.Valor}]";
            else if (this.Tipo == TipoToken.OM)
                return $"[OM,{this.Valor}]";
            else return $"[ID,{this.Identificador}]";
        }
    }
}
