using System;
using System.Diagnostics.CodeAnalysis;

namespace CustomerLib
{
    public interface IConsoleWrapper
    {
        string ReadLine();
        void WriteLine(string str);
        void Write(string str);
    }
    [ExcludeFromCodeCoverage]
    public class ConsoleWrapper : IConsoleWrapper
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }

        public void Write(string str)
        {
            Console.Write(str);
        }
    }
}
