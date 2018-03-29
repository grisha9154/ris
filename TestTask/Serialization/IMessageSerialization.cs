using Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public interface IMessageSerialization
    {
        byte[] Serialize(IWorkMessage o);
    }
}
