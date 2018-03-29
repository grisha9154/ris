using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TestTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(new ThreadStart(GlobalTimeWorker.GetDate)).Start();

            using (var server = new UdpClient(8888))
            {
                while (true)
                {
                    IPEndPoint ip = null;
                    byte[] data = server.Receive(ref ip);
                    string message = Encoding.UTF8.GetString(data);
                    var param = new ThreadParam { Message = message, Ip = ip };
                    new Thread(new ParameterizedThreadStart(Worker.DoWork)).Start(param);
                }
            }
        }
    }
}
