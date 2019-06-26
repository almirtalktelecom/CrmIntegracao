#define VERSAO_80

using AtendimentoManager;
using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Esc para quit!");
            InitClientExt();
        }

        #region TcpClient

        static void InitClientExt()
        {
            var obj = new TcpClientQt();

            obj.OnConectado += Obj_OnConectado;

            var task = Task.Run(() => WorkExt(obj));
            obj.InitClientExt(44900, "172.16.5.239");
        }

        private static void Obj_OnConectado(object sender, EventArgs e)
        {
            Console.WriteLine("Obj_OnConectado!");
        }

        static int WorkExt(TcpClientQt obj)
        {
            for (; ; )
            {
                var c = Console.ReadKey();
                switch (c.Key)
                {
                    case ConsoleKey.Escape:
                        obj.FinalizaClientExt();
                        return 0;

                    default:
                        var s = c.KeyChar.ToString() + Console.ReadLine();
                        s += "\r\n";
                        obj.EnviaPacoteExt(s.Length, s);
                        break;
                }
            }
        }

        #endregion TcpClient
    }
}
