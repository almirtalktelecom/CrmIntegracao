#define VERSAO_29

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
            obj.InitClientExt(44900, "172.16.5.239");
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
                        obj.SetPacote(s.Length, s);
                        break;
                }
            }
        }

        #endregion TcpClient

        #region MyThread

        static void InitClient()
        {
            var obj = new TcpClientQt();
            var task = Task.Run(() => Work(obj));
            obj.InitClient(44900, "172.16.5.239");
        }

        static int Work(TcpClientQt obj)
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
                        obj.SendExt(s.Length, s);
                        break;
                }
            }
        }

        #endregion // MyThread

    }
}
