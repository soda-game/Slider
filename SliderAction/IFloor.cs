using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SliderAction
{
    struct FloorVO
    {
        public int Num { get; }
        public int[] Index { get; }
        public Texture2D Spr { get; }
        public Vector2 Pos { get; }
        public Vector2[] ColliPos { get; }
        public int Bend { get; }
        public int B_Rot { get; }


        public FloorVO(int num,int[] index,Texture2D spr,Vector2 pos,Vector2[] cPos,int bend,int bRot)
        {
            Num = num;
            Index = index;
            Spr = spr;
            Pos = pos;
            ColliPos = cPos;
            Bend = bend;
            B_Rot = bRot;
        }
    }

   abstract class IFloor
    {
        public const int HALF = 2;
        public const int SIZE = 64;
        public const int H_SIZE = SIZE / HALF;

        public abstract int Num { get; }
        public abstract int[] Index{ get; }
        protected abstract Texture2D Spr { get; }
        protected abstract Vector2 Pos { get; }
        public abstract Vector2[] ColliPos{ get; }
        public abstract int Bend { get; }
        public abstract int B_Rot { get; }
    }
}
