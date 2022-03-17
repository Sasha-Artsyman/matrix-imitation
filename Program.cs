using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace MatrixEffect
{
    // Alt+Enter, please
    static class Program
    {
        private const int delay = 40;

        static void Main(string[] args)
        {
            SetConsoleParams();

            var consoleMatrix = new ConsoleMatrix(Console.WindowWidth, Console.WindowHeight);
            var cycle = 1;
            do
            {
                consoleMatrix.ShowMatrix();
                Thread.Sleep(delay);
                consoleMatrix.ShiftMatrixElements(cycle);
                cycle = ((cycle + 1) % 1000);
            } while (!Console.KeyAvailable);
        }

        private static void SetConsoleParams()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorVisible = false;
        }
    }
}