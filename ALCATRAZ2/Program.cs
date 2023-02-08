using System;
using System.IO;

namespace ALCATRAZ2
{
    public class InputOutput : System.IDisposable
    {
        private Stream _readStream = System.Console.OpenStandardInput(), _writeStream = System.Console.OpenStandardOutput();
        private StreamWriter _writer;
        private int _readIdx = 0, _bytesRead = 0, _writeIdx = 0, _inBuffSize, _outBuffSize;
        private readonly byte[] _inBuff, _outBuff;
        private readonly bool _bThrowErrorOnEof;

        public InputOutput(bool throwEndOfInputsError = false)
        {
            _writer = new StreamWriter(_writeStream);
            _inBuffSize = _outBuffSize = 1 << 22;
            _inBuff = new byte[_inBuffSize];
            _outBuff = new byte[_outBuffSize];
            _bThrowErrorOnEof = throwEndOfInputsError;
        }

        public int ReadInt()
        {
            byte readByte;
            while ((readByte = GetByte()) < '-') ;
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
                if (readByte < '0') break;
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
                if (_bytesRead >= 1) return _inBuff[_readIdx++];
                if (_bThrowErrorOnEof) throw new System.Exception();
                _inBuff[_bytesRead++] = 0;
            }
            return _inBuff[_readIdx++];
        }

        public void Flush()
        {
            _writeStream.Write(_outBuff, 0, _writeIdx);
            _writeStream.Flush();
            _writer.Flush();
            _writeIdx = 0;
        }
        public void WriteLine(string line)
        {
            _writer.WriteLine(line);
        }

        public void Dispose()
        {
            Flush();
            _writeStream.Close();
            _readStream.Close();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            InputOutput ioc = new InputOutput();

            int[] money = new int[8];

            bool[][] combinations = new bool[8][];

            for (var i = 0; i < 8; i++){
                money[i] = ioc.ReadInt();
                combinations[i] = new bool[8]{false,false,false,false,false,false,false,false};
            };

            int p = ioc.ReadInt();

            ioc.Dispose();
        }
    }
}