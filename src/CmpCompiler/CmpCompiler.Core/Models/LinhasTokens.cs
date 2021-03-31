using System.Collections.Generic;

namespace CmpCompiler.Core.Models
{
    public class LinhasTokens
    {
        public LinhasTokens(long linha)
        {
            Linha = linha;
            this.Tokens = new List<Token>();
        }

        public long Linha { get; set; }
        public List<Token> Tokens { get; private set; }

        public override string ToString()
        {
            List<string> strTokens = new List<string>();
            foreach (var token in this.Tokens)
                strTokens.Add(token.ToString());

            return string.Join(" ", strTokens);
        }
    }
}
