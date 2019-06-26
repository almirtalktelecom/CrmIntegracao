using System;
using System.Runtime.InteropServices;

namespace AtendimentoManager
{
    public class TcpClientQt : IDisposable
    {
        [DllImport(@"D:\Fontes\QT\Teste\lib\build-NovaLib-Desktop_Qt_5_12_2_MSVC2017_64bit-Release\release\NovaLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static private extern void InitClient(int porta, string servidor);

        [DllImport(@"D:\Fontes\QT\Teste\lib\build-NovaLib-Desktop_Qt_5_12_2_MSVC2017_64bit-Release\release\NovaLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static private extern void FinalizaClient();
        

        [DllImport(@"D:\Fontes\QT\Teste\lib\build-NovaLib-Desktop_Qt_5_12_2_MSVC2017_64bit-Release\release\NovaLib.dll", CallingConvention = CallingConvention.Cdecl)]
        static private extern void EnviaPacote(int len, string p);

        [DllImport(@"D:\Fontes\QT\Teste\lib\build-NovaLib-Desktop_Qt_5_12_2_MSVC2017_64bit-Release\release\NovaLib.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetOnConectado(OnEvtConectado fn);

        private delegate void OnEvtConectado();
        private readonly OnEvtConectado mOnEvtConectado;

        public event EventHandler OnConectado;

        public TcpClientQt()
        {
            mOnEvtConectado = new OnEvtConectado(OnEvtConectadoInt);
            SetOnConectado(mOnEvtConectado);
        }

        private void OnEvtConectadoInt()
        {
            OnConectado?.Invoke(this, null);
        }


        public void InitClientExt(int porta, string servidor)
        {
            InitClient(porta, servidor);
        }

        public void FinalizaClientExt()
        {
            FinalizaClient();
        }

        public void EnviaPacoteExt(int len, string p)
        {
            EnviaPacote(len, p);
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
