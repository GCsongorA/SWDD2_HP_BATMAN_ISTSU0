using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTSU0_SwDD2_HP_Batman
{
    internal class Batmobil : GroundVehicle, Item
    {
        int cost = 100000;
        int utilityValue = 6;

        public override int Cost { get { return cost; } }
        public override int UtilityValue { get { return utilityValue; } }
    }
}
