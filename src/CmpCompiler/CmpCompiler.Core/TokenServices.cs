using CmpCompiler.Core.Models;
using System.Collections.Generic;

namespace CmpCompiler.Core
{
    public class TokenServices
    {
        public List<string> Processe(List<string> lines)
        {
            var avore = new ArvoreAlgoritmo();
            foreach (var line in lines)
            {
                avore.ProcessarLinha(line);
            }
            return avore.TokensToString();
        }
    }
}
