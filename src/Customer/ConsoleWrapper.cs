using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerLib
{
    public interface IConsoleWrapper
    {
        string ReadLine();
        void WriteLine(string str);
        void Write(string str);
    }

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
