using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTSU0_SwDD2_HP_Batman
{
    internal class Batmobil : GroundVehicle
    {
        int cost = 100000;
        int utilityValue = 6;
        int topSpeed = 250;

        public int Cost { get { return cost; } }
        public int UtilityValue { get { return utilityValue; } }
        public int TopSpeed { get { return topSpeed; } }
    }
}
