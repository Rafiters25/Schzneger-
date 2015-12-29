using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickassSeries.Ultilities.Drawings
{
    public static class Initialize
    {
        public static void Init()
        {
            Drawings.AntiJuke.Init();
            Drawings.SpellTracker.Init();
            Drawings.WardTracker.Init();
        }
    }
}
