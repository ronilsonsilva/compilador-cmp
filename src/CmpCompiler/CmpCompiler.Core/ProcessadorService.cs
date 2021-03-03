using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CmpCompiler.Core
{
    public class ProcessadorService
    {
        #region [Constructors]

        public ProcessadorService() { }

        #endregion

        #region [Methods]

        public void FromFile(string path)
        {
            try
            {
                var lines = File.ReadAllLines(path);
                List<string> sb = new List<string>();
                foreach (var line in lines)
                {
                    string _lineAux = RemoveComentarios(line);

                    //Remover espaços em brancos
                    string newLine = RemoverEspacos(_lineAux);
                    if (!string.IsNullOrEmpty(newLine))
                        sb.Add(newLine);
                }
                string pathNovoArquivo = Path.ChangeExtension(path, ".proc");
                if (File.Exists(pathNovoArquivo))
                    File.Delete(pathNovoArquivo);
                File.WriteAllLines(pathNovoArquivo, sb);
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
            if (line.Contains("\\\\", StringComparison.CurrentCulture))
            {
                var lineSplit = line.Split("\\\\");
                _lineAux = lineSplit[0];
            }
            else _lineAux = line;
            return _lineAux;
        }

        #endregion
    }
}
