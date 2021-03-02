using System;
using System.Collections.Generic;
using System.IO;
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
                    if (line.Contains("\\\\", StringComparison.CurrentCulture))
                    {
                        var lineSplit = line.Split("\\\\");
                        if(!string.IsNullOrEmpty(lineSplit[0]))
                            sb.Add(lineSplit[0]);
                    }
                    else sb.Add(line);
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

        #endregion
    }
}
