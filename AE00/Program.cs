using System;
using System.IO;

namespace AE00
{
    #region Input Output Helper 
    public class InputOutput : System.IDisposable
    {
        private System.IO.Stream _readStream, _writeStream;
        private int _readIdx, _bytesRead, _writeIdx, _inBuffSize, _outBuffSize;
        private readonly byte[] _inBuff, _outBuff;
        private readonly bool _bThrowErrorOnEof;

        public InputOutput(bool throwEndOfInputsError = false)
        {
            _readStream = System.Console.OpenStandardInput();
            _writeStream = System.Console.OpenStandardOutput();
            _readIdx = _bytesRead = _writeIdx = 0;
            _inBuffSize = _outBuffSize = 1 << 22;
            _inBuff = new byte[_inBuffSize];
            _outBuff = new byte[_outBuffSize];
            _bThrowErrorOnEof = throwEndOfInputsError;
        }


        public int ReadInt()
        {
            byte readByte;
            while ((readByte = GetByte()) < '-')
                ;

            var neg = false;
            if (readByte == '-')
            {
                neg = true;
                readByte = GetByte();
            }
            var m = readByte - '0';
            while (true)
            {
                readByte = GetByte();
                if (readByte < '0')
                    break;
                m = m * 10 + (readByte - '0');
            }
            return neg ? -m : m;
        }


        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        private byte GetByte()
        {
            if (_readIdx >= _bytesRead)
            {
                _readIdx = 0;
                _bytesRead = _readStream.Read(_inBuff, 0, _inBuffSize);
                if (_bytesRead >= 1)
                    return _inBuff[_readIdx++];

                if (_bThrowErrorOnEof)
                    throw new System.Exception("End Of Input");
                _inBuff[_bytesRead++] = 0;
            }
            return _inBuff[_readIdx++];
        }

        private void Flush()
        {
            _writeStream.Write(_outBuff, 0, _writeIdx);
            _writeStream.Flush();
            _writeIdx = 0;
        }

        public void Dispose()
        {
            Flush();
            _writeStream.Close();
            _readStream.Close();
        }
    }
    #endregion Input Output Helper 
    class Program
    {
        static void Main(string[] args)
        {
            InputOutput reader = new InputOutput();
            StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

            int starting_squares = reader.ReadInt();

            int ergo_sum = starting_squares;
            double squares_root = Math.Sqrt(starting_squares);

            for (var i = 2; i <= squares_root; i++)

                for (int j = 2; j <= (starting_squares / 2); j++)
                {
                    if (i * j % i == 0 && i * j <= starting_squares && j >= i) ergo_sum++;
                }

            output.WriteLine(ergo_sum);
            output.Dispose();
        }
    }
}
