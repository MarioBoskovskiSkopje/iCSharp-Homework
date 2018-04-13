using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary
{
    public class PaymentEvent
    {
        public delegate void UserNotified(string msg);

        public event UserNotified userNotifiedHandler;
    }
}
