using System;
using System.Diagnostics;

namespace CardTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            var trick = new Trick();
            trick.Run();

            if (Debugger.IsAttached)
                Console.ReadKey();
        }
    }
}