using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SliderAction
{
    struct PlayerVO
    {
        public int InitCharaNum { get; }
        public Vector2 InitPos { get; }
        public float InitSpeed { get; }
        public int InitRotNum { get; }
        public Texture2D[] Sprs { get; }
        public Vector2[] ColliPos { get; }

        public PlayerVO(int cNum, Texture2D[] spr, Vector2 iPos, float speed, int IRot, Vector2[] cp)
        {
            InitCharaNum = cNum;
            Sprs = spr;
            InitPos = iPos;
            InitSpeed = speed;
            InitRotNum = IRot;
            ColliPos = cp;
        }
    }

    abstract class IPlayer
    {

        const int HALF = 2;
        static protected readonly Vector2 SIZE = new Vector2(32, 32);
        protected readonly Vector2 H_SIZE = new Vector2(SIZE.X / HALF, SIZE.Y / HALF);
        const float HP_MIN = 10;

        protected abstract int CharaNum { get; }
        public abstract Vector2 Pos { get; }
        protected abstract float Speed { get; }
        public abstract int RotNum { get; }
        protected abstract Texture2D[] Spr { get; }
        public abstract Vector2[] ColliPos { get; }
    }
}
