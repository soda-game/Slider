using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace SliderAction
{
    class Collition
    {
        static public void EnterColl()
        {

        }

        static public bool StayColl(Vector2[] wDp, Vector2[] pDp)
        {
            int ul = (int)OtherValue.Square.UP_LEFT;
            int dr = (int)OtherValue.Square.DOWN_RIGHT;

            if (pDp[dr].X > wDp[ul].X && pDp[ul].X < wDp[dr].X && pDp[dr].Y > wDp[ul].Y && pDp[ul].Y < wDp[dr].Y)
            {
                return true;
            }

            return false;
        }

        static public int StayColl(List<Vector2[]> wRecoPos, Vector2[] pDp) //どれか一つにあたっていればT
        {
            int index = -1;

            for (int i = 0; i < wRecoPos.Count; i++)
                if (StayColl(wRecoPos[i], pDp))
                    index = i;

            return index;
        }
        static public int StayColl(List<FloorFactory.BendSqr> floorOb, Vector2[] pDp) //どれか一つにあたっていればT
        {
            int index = -1;

            for (int i = 0; i < floorOb.Count; i++)
                if (StayColl(floorOb[i].pos, pDp))
                    index = i;
            return index;
        }
    }
}
