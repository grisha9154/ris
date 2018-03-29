using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask2
{
    public static class Worker
    {
        public static void DoWork(object payload)
        {
            switch (payload)
            {
                case "SayHi": 
                    {
                        Console.WriteLine("Hi");
                        break;
                    }
            }
        }
    }
}
