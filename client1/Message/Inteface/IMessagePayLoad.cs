using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message
{
    public interface IMessagePayLoad
    {
        string Value { get; }
        void SetNormalizeValue(object o);
    }
}
