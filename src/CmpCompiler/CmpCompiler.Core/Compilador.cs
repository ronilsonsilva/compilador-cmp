using System.IO;

namespace CmpCompiler.Core
{
    public class Compilador
    {
        public void Run(string path)
        {
            var linhas = new ProcessadorService().FromFile(path);
            var arvore = new TokenServices().Processe(linhas);

            string pathNovoArquivo = Path.ChangeExtension(path, ".proc");
            if (File.Exists(pathNovoArquivo))
                File.Delete(pathNovoArquivo);
            File.WriteAllLines(pathNovoArquivo, arvore.TokensToString());

            string pathErro = Path.ChangeExtension(path, ".erro");
            if (File.Exists(pathErro))
                File.Delete(pathErro);
            File.WriteAllLines(pathErro, arvore.Erros);


        }
    }
}
