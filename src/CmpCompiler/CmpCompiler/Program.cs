using System;

namespace CmpCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o path do aquivo, com extensão .cmp");

            var path = Console.ReadLine();

            new CmpCompiler.Core.Compilador().Run(path);

            Console.WriteLine("Processamento finalizado!!!!!");
            Console.ReadLine();
        }
    }
}
