using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int Tc = 1000;
            long Cc = 0;
            DateTime localTime = new DateTime();
            using ( UdpClient sender = new UdpClient(8878))
            {
                while (true)
                {
                    Console.WriteLine("Введите команду");
                    Console.WriteLine("0-Exit");
                    Console.WriteLine("1-sayHi");
                    Console.WriteLine("2-SINC");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            {
                                var message = "SAYHI";
                                byte[] data = Encoding.UTF8.GetBytes(message);
                                sender.Send(data, data.Length, "127.0.0.1", 8888);
                                IPEndPoint ip = null;
                                data = sender.Receive(ref ip);
                                Console.WriteLine(Encoding.UTF8.GetString(data));
                            } break;
                        case "2":
                            {
                                var message = "SINC|"+Cc.ToString();
                                byte[] data = Encoding.UTF8.GetBytes(message);
                                sender.Send(data, data.Length, "127.0.0.1", 8888);
                                IPEndPoint ip = null;
                                data = sender.Receive(ref ip);
                                var command = Encoding.UTF8.GetString(data).Split('|');

                                Cc += Int64.Parse(command[1]);
                                Console.WriteLine(command[1]);
                                Thread.Sleep(Tc); 
                            }
                            break;
                        case "3":
                            {
                                var message = "SINCDATE|" + localTime;
                                byte[] data = Encoding.UTF8.GetBytes(message);
                                sender.Send(data, data.Length, "127.0.0.1", 8888);
                                IPEndPoint ip = null;
                                data = sender.Receive(ref ip);
                                var command = Encoding.UTF8.GetString(data).Split('|');

                                localTime += TimeSpan.Parse(command[1]);
                                Console.WriteLine(command[1]);
                                Thread.Sleep(Tc);
                            }
                            break;
                    }

                    

                }
            }
        }
    }
}
