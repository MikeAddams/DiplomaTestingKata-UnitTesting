using System;

namespace Diploma
{
    public interface IConsoleWrapper
    {
        string ReadLine();
        void Write(string message);
        void WriteLine(string message);
        ConsoleKeyInfo ReadKey();
    }
}