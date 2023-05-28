using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTSU0_SwDD2_HP_Batman
{
    internal class Batarang : HandTool,Item
    {
        int cost = 100;
        int utilityValue = 1;


        public override int Cost { get { return cost; } }
        public override int UtilityValue { get { return utilityValue; } }
    }
}
