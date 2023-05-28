using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTSU0_SwDD2_HP_Batman
{
    internal class HandTool : Item
    {
        public virtual int Cost { get; protected set; }
        public virtual int UtilityValue { get; protected set; }
    }
}
