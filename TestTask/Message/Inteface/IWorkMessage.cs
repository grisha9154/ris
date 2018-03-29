using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message
{
    public interface IWorkMessage
    {
        string Command { get; set; }
        IMessagePayLoad Payload { get; set; }

        string GetNormalizeMessage { get; set; }
    }
}
