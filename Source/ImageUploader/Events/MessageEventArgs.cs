using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageUploader.Events
{
    public class MessageEventArgs : EventArgs
    {
        public string Message{ get; set; }

        public MessageEventArgs(string message)
        {
            this.Message = message;
        }
    }
}
