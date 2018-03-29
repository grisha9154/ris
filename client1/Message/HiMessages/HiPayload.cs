using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.HiMessages
{
    public class HiPayload : IMessagePayLoad
    {
        private string message;
        public string Value {
            get {
                return message;
            }
        }

        public void SetNormalizeValue(object message)
        {
            if(message is string)
            {
                this.message = (string)message;
            }
        }
    }
}
