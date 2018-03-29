using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class MessageSerialization : IMessageSerialization
    {
        public byte[] Serialize(IMessageSerialization o)
        {
            BitConverter.GetBytes(o.Serialize);
        }
    }
}
