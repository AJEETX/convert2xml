using Converter.Config;
using System.IO;

namespace Converter.Domain
{
    static class Init
    {
        static string filepath = @"./data.csv";
        internal static string Generate()
        {
            return File.Exists(filepath)? UnityConfig.GetConverter().Convert(filepath):"Err";
        }
    }
}
