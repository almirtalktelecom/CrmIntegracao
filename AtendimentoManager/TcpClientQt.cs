using System;
using System.Runtime.InteropServices;

namespace AtendimentoManager
{
    public class TcpClientQt : IDisposable
    {
        private readonly IntPtr pClassName;

        [DllImport(@"NovaLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static private extern IntPtr CreateTcpClient();

        [DllImport(@"NovaLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static private extern void Open(IntPtr pAtendimentoObject,string servidor, int porta);

        [DllImport(@"NovaLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static private extern void Send(IntPtr pAtendimentoObject, int len, string p);

        [DllImport(@"NovaLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static private extern IntPtr ReadData(IntPtr pAtendimentoObject);

        public TcpClientQt()
        {
            pClassName = CreateTcpClient();
        }

        public void Open(string servidor, int porta)
        {
            Open(pClassName, servidor, porta);
        }

        public void Send(int len, string p)
        {
            Send(pClassName, len, p);
        }

        public void ReadData()
        {
            ReadData(pClassName);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
