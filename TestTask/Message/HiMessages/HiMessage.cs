using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message
{
    [Serializable]
    public class HiMessage : IWorkMessage
    {
        public string Command { get; set; }
        public IMessagePayLoad Payload { get; set; }
        public string GetNormalizeMessage
        {
            get
            {
                return Command + ":" + Payload.Value;
            }
            set
            {
                GetNormalizeMessage = value;
            }
        }
    }
}
