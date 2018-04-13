using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary
{
    public class UserNotified
    {
        public void MsgProcessed(string msg)
        {
            
            Console.WriteLine($"--|{msg}|--");
        }
    }
}
