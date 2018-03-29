using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient sender = new UdpClient("127.0.0.1", 8888);
            HiMessage hiMessage = new HiMessage();
            IFormatter formatter = new BinaryFormatter();

            sender.Close();
        }
    }
}
