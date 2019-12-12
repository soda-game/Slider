using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliderAction
{
    class Animetion
    {

       static public bool SinpleAnimetion(ref int wait, ref bool drawF)
        {
            drawF = true;
            if (wait > 0)
            { wait--; return false; }

            drawF = false;
            return true;
        }
    }
}
