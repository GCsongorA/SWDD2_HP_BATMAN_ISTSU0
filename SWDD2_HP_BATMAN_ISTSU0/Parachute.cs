using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTSU0_SwDD2_HP_Batman
{
    internal class Parachute : HandTool
    {
        int cost = 1000;
        int utilityValue = 2;

        public int Cost { get { return cost; } }
        public int UtilityValue { get { return utilityValue; } }
    }
}
