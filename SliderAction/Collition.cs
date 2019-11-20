using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace SliderAction
{
    class Collition
    {
        static public void EnterColl()
        {

        }

        static public bool StayColl(Vector2[] wDp, Vector2[] pDp)
        {
            int ul = (int)WallFactory.Square.UP_LEFT;
            int dr = (int)WallFactory.Square.DOWN_RIGHT;

            if (pDp[dr].X > wDp[ul].X && pDp[ul].X < wDp[dr].X && pDp[dr].Y > wDp[ul].Y && pDp[ul].Y < wDp[dr].Y)
            {
                return true;
            }

            return false;
        }

        static public int StayColl(List<FloorFactory.BendSqr> floorOb, Vector2[] pDp) //どれか一つにあたっていればT
        {
            int index = -1;

            for (int i = 0; i < floorOb.Count ; i++)
                if (StayColl(floorOb[i].pos, pDp))
                index = i;

            return index;
        }
    }
}
