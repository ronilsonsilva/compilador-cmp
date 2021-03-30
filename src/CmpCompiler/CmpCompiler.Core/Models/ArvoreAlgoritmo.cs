using System;
using System.Collections.Generic;
using System.Linq;

namespace CmpCompiler.Core.Models
{
    public class ArvoreAlgoritmo
    {
        public List<LinhasTokens> Linhas { get; private set; }
        public List<long> Identificadores
        {
            get
            {
                var ids = new List<long>();
                ids.Add(0);
                foreach (var linha in this.Linhas)
                {
                    foreach (var token in linha.Tokens)
                    {
                        if (token.Tipo == TipoToken.VARIAVEL)
                            ids.Add(token.Identificador);
                    }
                }
                return ids;
            }
        }

        public void ProcessarLinha(string valorLinha)
        {
            if (this.Linhas == null)
                this.Linhas = new List<LinhasTokens>();

            if (string.IsNullOrWhiteSpace(valorLinha))
                return;

            var linha = new LinhasTokens(this.Linhas.Count+1);
            var linhaSplit = valorLinha.Split(" ");
            foreach (var item in linhaSplit)
            {
                this.AdicionarToken(linha, item);
            }
        }

        private void AdicionarToken(LinhasTokens linha, string valor)
        {
            if (valor.EhPalavraReservada())
                linha.Tokens.Add(new Token(valor, TipoToken.PALAVRA_RESERVADA));
            else
            {
                foreach (var item in this.Linhas)
                {
                    var existente = item.Tokens.Where(x => x.Valor.Equals(valor)).FirstOrDefault();
                    if (existente != null)
                    {
                        linha.Tokens.Add(existente);
                        return;
                    }
                }

                linha.Tokens.Add(new Token(this.Identificadores.Max() + 1, valor, TipoToken.VARIAVEL));
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
