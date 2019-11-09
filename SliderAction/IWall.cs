using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SliderAction//***
{
    struct WallVO
    {
        public Texture2D Spr { get; }
        public Vector2 PosBase { get; }
        public float Rot { get; }
        public Color Cr { get; }
        public Vector2 Grap { get; }
        public bool Bend { get; } //曲がり角かどうか

        public WallVO(Texture2D spr, Vector2 pb, float rot, Color cr, Vector2 grap, bool bend)
        {
            Spr = spr;
            PosBase = pb;
            Rot = rot;
            Cr = cr;
            Grap = grap;
            Bend = bend;
        }
    }

    abstract class IWall
    {

        const int HALF = 2;
        protected const int SIZE = 64;
        protected const int H_SIZE = SIZE / HALF;
        const int C_SIZE = 64;

        public abstract Texture2D Spr { get; }
        public abstract Vector2 PosBase { get; }
        public abstract float Rot { get; }
        public abstract Color Cr { get; }
        public abstract Vector2 Grap { get; }
        public abstract bool Bend { get; } //曲がり角かどうか
    }
}
