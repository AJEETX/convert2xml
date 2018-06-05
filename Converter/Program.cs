using System;
using System.IO;
using Converter.Config;
using Converter.Domain;

namespace Converter
{
    class Program
    {
        const string strFilepath = @"./data.csv";
        static void Main(string[] args)
        {
            var xml = File.Exists(strFilepath) ? UnityConfig.GetConverter().Convert(strFilepath) : "Err";
            Console.Write($" {xml} saved in the bin folder");
            Console.ReadLine();
        }
    }
}
