using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWDD2_HP_BATMAN_ISTSU0
{
    class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException(string message) : base(message)
        {
        }
        public NotEnoughMoneyException()
        {
        }
    }
}
