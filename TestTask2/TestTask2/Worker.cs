using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TestTask2
{
    public static class Worker
    {
        static readonly long Ticks = DateTime.Now.Ticks;
        static readonly DateTime Date = GlobalTimeWorker.CurrentTime;
        public static void DoWork(object param)
        {
            ThreadParam payload = new ThreadParam();
            if(param is ThreadParam)
            {
                payload = param as ThreadParam;
            }else
            {
                return;
            }
            var command = payload.Message.Split('|');
            switch (command[0])
            {
                case "SAYHI": 
                    {
                        using(var sender = new UdpClient())
                        {
                            var data = Encoding.UTF8.GetBytes("Hi man!!!");
                            sender.Send(data, data.Length, payload.Ip);
                        }
                        break;
                    }
                case "SINC":
                    {
                        using (var sender = new UdpClient())
                        {
                            var correctValue = DateTime.Now.Ticks - Ticks - Int64.Parse(command[1]);
                            var data = Encoding.UTF8.GetBytes("SINC|"+(correctValue));
                            sender.Send(data, data.Length, payload.Ip);
                            Console.WriteLine("{0}: {1}",payload.Ip.Address,correctValue);
                        }
                        break;
                    }
                case "SINCDATE": {
                        using (var sender = new UdpClient())
                        {
                            var correctValue = GlobalTimeWorker.CurrentTime - DateTime.Parse(command[1]);
                            var data = Encoding.UTF8.GetBytes("SINC|" + (correctValue));
                            sender.Send(data, data.Length, payload.Ip);
                            Console.WriteLine("{0}: {1}", payload.Ip.Address, correctValue);
                        }
                        break;
                    }
            }
        }
    }
}
