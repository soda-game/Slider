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
        public float InitRot { get; }
        public Texture2D[] Sprs { get; }

        public PlayerVO(int cNum, Texture2D[] spr, Vector2 iPos, float speed, float IRot)
        {
            InitCharaNum = cNum;
            Sprs = spr;
            InitPos = iPos;
            InitSpeed = speed;
            InitRot = IRot;
        }
    }

    abstract class IPlayer
    {
        const int HALF = 2;
        static protected readonly Vector2 SIZE = new Vector2(64, 100);
        protected readonly Vector2 H_SIZE = new Vector2(SIZE.X / HALF, SIZE.Y / HALF);

        public abstract int CharaNum { get; }
        public abstract Vector2 Pos { get; }
        public abstract float Speed { get; }
        public abstract float Rot { get; }
        public abstract Texture2D[] Spr { get; }
    }
}
