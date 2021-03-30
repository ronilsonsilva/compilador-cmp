using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CmpCompiler.Core
{
    public class ProcessadorService
    {
        #region [Constructors]

        public ProcessadorService() { }

        #endregion

        #region [Methods]

        public List<string> FromFile(string path)
        {
            try
            {
                var lines = File.ReadAllLines(path);
                //Com expressão regular
                string allLines = string.Join("\n", lines);
                string lineSemComentarios = string.Empty;
                if (allLines.Contains("//", StringComparison.CurrentCulture))
                {
                    var lineSplit = allLines.Split("//");
                    for (int i = 0; i < lineSplit.Length; i++)
                    {
                        if (this.NumeroPar(i))
                        {
                            lineSemComentarios += lineSplit[i];
                        }
                    }
                }
                var splitLineSemComentarios = lineSemComentarios.Split("\n").Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
                List<string> newLines = new List<string>();
                foreach (var line in splitLineSemComentarios)
                {
                    var newLine = Regex.Replace(line, @"\s+", " ");
                    if (newLine.StartsWith(" "))
                        newLine = newLine.Substring(1, newLine.Length - 1);
                    if (newLine.EndsWith(" "))
                        newLine = newLine.Substring(0, newLine.Length - 2);
                    newLines.Add(newLine);
                }

                return newLines;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string RemoverEspacos(string _lineAux)
        {
            var _lineAuxSplit = _lineAux.Split(" ");
            _lineAuxSplit = _lineAuxSplit.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            string newLine = String.Join(" ", _lineAuxSplit);
            return newLine;
        }

        private static string RemoveComentarios(string line)
        {
            string _lineAux = string.Empty;
            //Remover comentários
            if (line.Contains("//", StringComparison.CurrentCulture))
            {
                var lineSplit = line.Split("//");
                _lineAux = lineSplit[0];
            }
            else _lineAux = line;
            return _lineAux;
        }

        private bool NumeroPar(int number)
        {
            if (number == 0) return true;
            return (number % 2) == 0;
        }

        #endregion
    }
}
