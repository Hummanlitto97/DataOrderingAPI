using DataOrdering.Infrastructure.Common.Interfaces;
using System;
using System.IO;

namespace DataOrdering.Infrastructure
{
    public class TextFile : IDatabase
    {
        public string Path { get; private set; }
        public TextFile()
        {
            Path = "";
        }
        public TextFile(string path)
        {
            Path = path;
        }
        public string Save_Data(string data)
        {
            File.CreateText(data).Write(data);
            return data;
        }
        public string Load_Data()
        {
            return File.Exists(Path) ? File.ReadAllText(Path) : "";
        }
    }
}
