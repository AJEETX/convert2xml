using System;
using System.IO;
using Converter.Config;
using Converter.Domain;

namespace Converter
{
    class Program
    {
        const string Filepath = @"./data.csv";
        static void Main(string[] args)
        {
            var xml = File.Exists(Filepath) ? UnityConfig.GetConverter().Convert(Filepath) : "Err";
            Console.Write($" {xml} saved in the bin folder");
            Console.ReadLine();
        }
    }
}
