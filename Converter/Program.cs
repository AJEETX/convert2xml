using System;
using System.IO;
using Converter.Domain;

namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            var xml = Init.Generate();
            Console.Write($" {xml} saved in the bin folder");
            Console.ReadLine();
        }
    }
}
