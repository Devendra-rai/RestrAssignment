using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restro.Event
{
    public delegate string SendMessage(string String,int bill );
    public class MessageEvent 
    {
       public  event SendMessage MessageSend;

        public MessageEvent()
        {
            this.MessageSend += new SendMessage(this.SendMessageAction);
        }
        public string SendMessageAction(string username,int bill)
        {
            return $"You Bill is Generated {username} And Sended to your number .  \n You Bill is " + bill;
        }
       
    }
}
