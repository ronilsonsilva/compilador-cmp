using System.Collections.Generic;
using System.Linq;

namespace CmpCompiler.Core.Models
{
    public class ArvoreAlgoritmo
    {
        public ArvoreAlgoritmo()
        {
            this.Erros = new List<string>();
        }
        public List<LinhasTokens> Linhas { get; private set; }
        public List<string> Erros { get; private set; }
        public List<long> Identificadores { get; set; } = new List<long>();
        //public List<long> Identificadores
        //{
        //    get
        //    {
        //        var ids = new List<long>();
        //        //ids.Add(0);
        //        foreach (var linha in this.Linhas)
        //        {
        //            foreach (var token in linha.Tokens)
        //            {
        //                if (token.Tipo == TipoToken.ID)
        //                    ids.Add(token.Identificador);
        //            }
        //        }
        //        return ids;
        //    }
        //}

        public void ProcessarLinha(string valorLinha)
        {
            if (this.Linhas == null)
                this.Linhas = new List<LinhasTokens>();

            if (string.IsNullOrWhiteSpace(valorLinha))
                return;

            var linha = new LinhasTokens(this.Linhas.Count + 1);
            if (valorLinha.Contains("\""))
            {
                var splitFrase = valorLinha.Split("\"");
                for (int i = 0; i < splitFrase.Length; i++)
                {
                    if(i != 0 && (i %2) != 0)//frase
                    {
                        linha.Tokens.Add(new Token(splitFrase[i], TipoToken.FR));
                    }
                    else
                    {
                        var linhaSplit = splitFrase[i].Split(" ");
                        foreach (var item in linhaSplit)
                        {
                            this.AdicionarToken(linha, item);
                        }
                    }
                }
            }
            else
            {
                var linhaSplit = valorLinha.Split(" ");
                foreach (var item in linhaSplit)
                {
                    this.AdicionarToken(linha, item);
                }
            }
            

            if (linha.Tokens.Count > 0)
                this.Linhas.Add(linha);
        }

        private void AdicionarToken(LinhasTokens linha, string valor)
        {
            if (valor.EhPalavraReservada())
                linha.Tokens.Add(new Token(valor, TipoToken.PALAVRA_RESERVADA));
            else if (valor.EhCondicionalLogica())
                linha.Tokens.Add(new Token(this.Identificadores.Max() + 1, valor, TipoToken.CL));
            else if (valor.EhOperadorMatematico())
                linha.Tokens.Add(new Token(this.Identificadores.Max() + 1, valor, TipoToken.OM));
            else if (valor.EhOperadorLogico())
                linha.Tokens.Add(new Token(this.Identificadores.Max() + 1, valor, TipoToken.OL));
            //else if (valor.EhCaracteres())
            //    linha.Tokens.Add(new Token(this.Identificadores.Max() + 1, valor, TipoToken.FR));
            else if (int.TryParse(valor, out _))
                linha.Tokens.Add(new Token(this.Identificadores.Max() + 1, valor, TipoToken.NU));
            else
            {
                if (string.IsNullOrWhiteSpace(valor)) return;

                if (!valor.PossuiCaracteresInvalido())
                {
                    this.Erros.Add($"Lexema inválido {valor}, linha {linha.Linha}.");
                    return;
                }
                
                //Rever

                var primeiroCaracter = valor.First();
                bool isNumber = decimal.TryParse(primeiroCaracter.ToString(), out _);
                if (isNumber)
                {
                    this.Erros.Add($"Lexema inválido {valor}, linha {linha.Linha}.");
                    return;
                }
                if (primeiroCaracter.ToString().EhPalavraReservada()
                    || primeiroCaracter.ToString().EhCaracteres()
                    || primeiroCaracter.ToString().EhOperadorLogico()
                    || primeiroCaracter.ToString().EhOperadorMatematico()
                    || primeiroCaracter.ToString().EhCondicionalLogica())
                {
                    this.Erros.Add($"Lexema inválido {valor}, linha {linha.Linha}.");
                    return;
                }

                foreach (var item in this.Linhas)
                {
                    var existente = item.Tokens.Where(x => x.Valor.Equals(valor)).FirstOrDefault();
                    if (existente != null)
                    {
                        linha.Tokens.Add(existente);
                        return;
                    }
                }
                var identificadorToken = this.Identificadores.Count + 1;
                linha.Tokens.Add(new Token(identificadorToken, valor, TipoToken.ID));
                this.Identificadores.Add(identificadorToken);
            }
        }

        public List<string> TokensToString()
        {
            List<string> saida = new List<string>();
            foreach (var linha in this.Linhas)
            {
                saida.Add(linha.ToString());
            }

            return saida;
        }

    }
}
