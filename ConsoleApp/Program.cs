using AtendimentoManager;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new TcpClientQt();

            // connet to server
            obj.Open("172.16.5.239", 44900);

            Console.WriteLine("Esc para quit!");
            for (; ; )
            {
                var c = Console.ReadKey();
                switch (c.Key)
                {
                    case ConsoleKey.Escape:
                        System.Environment.Exit(0);
                        break;

                    // Send data to server!
                    case ConsoleKey.Insert:
                        obj.ReadData();
                        break;

                    default:
                        if (c.Key >= ConsoleKey.A && c.Key <= ConsoleKey.Z)
                        {
                            var s = c.KeyChar.ToString() + Console.ReadLine();
                            obj.Send(s.Length, s);
                        }
                        break;
                }
            }
        }
    }
}
