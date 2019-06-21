using System;
using System.Runtime.InteropServices;

namespace AtendimentoManager
{
    public class TcpClientQt : IDisposable
    {
        private readonly IntPtr pTcpClient;

        [DllImport(@"D:\Fontes\QT\Teste\lib\build-NovaLib-Desktop_Qt_5_12_2_MSVC2017_64bit-Release\release\NovaLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static private extern IntPtr CreateTcpClient(int porta, string servidor);
        
        [DllImport(@"D:\Fontes\QT\Teste\lib\build-NovaLib-Desktop_Qt_5_12_2_MSVC2017_64bit-Release\release\NovaLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static private extern void InitClientExt(int porta, string servidor);

        [DllImport(@"D:\Fontes\QT\Teste\lib\build-NovaLib-Desktop_Qt_5_12_2_MSVC2017_64bit-Release\release\NovaLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static private extern void SetPacote(int len, string p);

        public TcpClientQt()
        {
            //pTcpClient = CreateTcpClient(porta, servidor);
        }

        public void InitClient(int porta, string servidor)
        {
            InitClientExt(porta, servidor);
        }

        public void SetPacoteExt(int len, string p)
        {
            SetPacote(len, p);
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
