using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTask2
{
    public static class GlobalTimeWorker
    {
       public static DateTime CurrentTime { get; set; }
       public static void GetDate()
        {
            try
            {
                while (true)
                {
                    var client = new Yort.Ntp.NtpClient("0.europe.pool.ntp.org");
                    CurrentTime = client.RequestTimeAsync().Result;
                    Console.WriteLine(CurrentTime);
                    Thread.Sleep(1000);
                }
            }
            catch (Exception)
            {
                GetDate();
            }
        }
    }
}
