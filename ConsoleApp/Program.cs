#define VERSAO_36

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
            Console.ReadKey();
        }

        #region TcpClient

        static void InitClientExt()
        {
            var obj = new TcpClientQt();
            var task = Task.Run(() => WorkExt(obj));
            obj.InitClient(44900, "172.16.5.239");
        }

        static int WorkExt(TcpClientQt obj)
        {
            for (; ; )
            {
                var c = Console.ReadKey();
                switch (c.Key)
                {
                    case ConsoleKey.Escape:
                        System.Environment.Exit(0);
                        break;

                    default:
                        var s = c.KeyChar.ToString() + Console.ReadLine();
                        s += "\r\n";
                        obj.SetPacoteExt(s.Length, s);
                        break;
                }
            }
        }

        #endregion TcpClient
    }
}
