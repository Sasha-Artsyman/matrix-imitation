namespace MatrixEffect
{
    public class ConsoleMatrix
    {
        // symbols
        private static readonly char[] _symbols = " 01".ToCharArray();
        private readonly int _symbolsLen = _symbols.Length;

        private char[][] _matrix;
        private readonly int _width;
        private readonly int _height;

        private readonly Random _rand = new Random();
        private const int period = 6;
        public ConsoleMatrix(int width, int height)
        {
            _width = width;
            _height = height;
            CreateMatrix();
        }
        private void CreateMatrix()
        {
            _matrix = new char[_height][];
            for (var h = 0; h < _height; h++)
            {
                _matrix[h] =
                   Enumerable.Range(0, _width)
                        .Select(position => (position + 1) % 2 == 0
                                ? ' '
                                : _symbols[_rand.Next(0, _symbolsLen)])
                        .ToArray();
            }
        }
        public void ShowMatrix()
        {
            Console.SetCursorPosition(0, 0);
            for (var h = 0; h < _height; h++)
            {
                var s = new string(_matrix[h]);
                if (h < _height - 1) Console.WriteLine(s);
                else Console.Write(s);
            }
        }
        public void ShiftMatrixElements(int cycle)
        {
            for (var w = 0; w < _width; w += 2)
            {
                if (w % period > cycle % period) continue;
                for (var h = _height - 1; h >= 0; h--)
                {
                    if (h == 0)
                    {
                        _matrix[h][w] = _symbols[_rand.Next(0, _symbolsLen)];
                        continue;
                    }
                    _matrix[h][w] = _matrix[h - 1][w];
                }
            }
        }
    }
}