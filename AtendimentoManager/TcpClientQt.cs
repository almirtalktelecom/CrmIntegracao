using System;
using System.Runtime.InteropServices;

namespace AtendimentoManager
{
    public class TcpClientQt : IDisposable
    {
        private readonly IntPtr pTcpClient;

        private readonly IntPtr pMyThread;

        [DllImport(@"D:\Fontes\QT\Teste\lib\build-NovaLib-Desktop_Qt_5_12_2_MSVC2017_64bit-Release\release\NovaLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static private extern IntPtr CreateTcpClient();
        
        [DllImport(@"D:\Fontes\QT\Teste\lib\build-NovaLib-Desktop_Qt_5_12_2_MSVC2017_64bit-Release\release\NovaLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static private extern IntPtr CreateMyThread();

        [DllImport(@"D:\Fontes\QT\Teste\lib\build-NovaLib-Desktop_Qt_5_12_2_MSVC2017_64bit-Release\release\NovaLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static private extern void InitClient(IntPtr pMyThreadObj, int porta, string servidor);

        [DllImport(@"D:\Fontes\QT\Teste\lib\build-NovaLib-Desktop_Qt_5_12_2_MSVC2017_64bit-Release\release\NovaLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static private extern void InitClientExt(IntPtr pClassName, int porta, string servidor);

        [DllImport(@"D:\Fontes\QT\Teste\lib\build-NovaLib-Desktop_Qt_5_12_2_MSVC2017_64bit-Release\release\NovaLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static private extern void SendExt(IntPtr pMyThreadObj, int len, string p);

        [DllImport(@"D:\Fontes\QT\Teste\lib\build-NovaLib-Desktop_Qt_5_12_2_MSVC2017_64bit-Release\release\NovaLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static private extern void Send(IntPtr pClassName, int len, string p);

        [DllImport(@"D:\Fontes\QT\Teste\lib\build-NovaLib-Desktop_Qt_5_12_2_MSVC2017_64bit-Release\release\NovaLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static private extern void SetPacote(IntPtr pClassName, int len, string p);

        public TcpClientQt()
        {
            pTcpClient = CreateTcpClient();
            pMyThread = CreateMyThread();
        }

        public void Send(int len, string p)
        {
            Send(pTcpClient, len, p);
        }

        public void SetPacote(int len, string p)
        {
            SetPacote(pTcpClient, len, p);
        }

        public void SendExt(int len, string p)
        {
            SendExt(pMyThread, len, p);
        }

        public void InitClientExt(int porta, string servidor)
        {
            InitClientExt(pTcpClient, porta, servidor);
        }

        public void InitClient(int porta, string servidor)
        {
            InitClient(pMyThread, porta, servidor);
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
