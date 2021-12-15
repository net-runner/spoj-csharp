using System;
using System.IO;
using System.Numerics;

namespace CURSERECURSION
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
            // Console.SetOut(_writer);
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
            _writer.Close();
            _writeStream.Close();
            _readStream.Close();
        }
    }

    class Program
    {
        static BigInteger bizzargo = 1;

        static BigInteger wynique = 0;
        static void fun_test(BigInteger n, InputOutput ioc)
        {
            if (n > 0)

            {

                fun_test(n - 1, ioc);
                ioc.WriteLine($"{bizzargo}: {n}");
                bizzargo++;
                fun_test(n - 1, ioc);

            }
        }

        static void getIntegrum(BigInteger n, BigInteger szukan)
        {
            if (n > 0 && bizzargo <= szukan && wynique == 0)

            {
                getIntegrum(n - 1, szukan);
                if (bizzargo == szukan && wynique == 0)
                {
                    wynique = n;
                    return;
                }
                bizzargo++;

                getIntegrum(n - 1, szukan);
            }
        }
        static void Main(string[] args)
        {
            InputOutput ioc = new InputOutput();

            int cases = ioc.ReadInt();
            BigInteger n = 0;
            BigInteger k = 0;

            while (cases-- > 0)
            {
                wynique = 0;
                bizzargo = 1;
                n = ioc.ReadInt();
                k = ioc.ReadInt();
                // ioc.WriteLine($"Test {cases}: -----");
                // ioc.WriteLine("");


                // fun_test(n, ioc);
                // bizzargo = 1;
                getIntegrum(n, k);
                ioc.WriteLine(wynique.ToString());
                // ioc.WriteLine($"Szukan: {k}");
                // ioc.WriteLine($"Wynique: {wynique}");
                // wynique = 0;
                // bizzargo = 1;

            }
            ioc.Dispose();
        }
    }
}