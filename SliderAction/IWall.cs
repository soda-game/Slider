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
    struct WallVO
    {


        public Texture2D Spr { get; }
        public Vector2 Pos { get; }
        public float Rot { get; }
        public Color Cr { get; }
        public Vector2 Gap { get; }
        public bool Bend { get; } //曲がり角かどうか

        public Vector2[] DamagePos { get; }
        public List<Vector2[]> RecoverPos { get; }

        public WallVO(Texture2D spr, Vector2 pos, Vector2[] dp, List<Vector2[]> rp, float rot, Color cr, Vector2 gap, bool bend)
        {
            Spr = spr;
            Pos = pos;
            Rot = rot;
            Cr = cr;
            Gap = gap;
            Bend = bend;

            DamagePos = dp;
            RecoverPos = rp;
        }
    }

    abstract class IWall
    {
        public const int HALF = 2;
        public const int SIZE = 64;
        public const int HALF_SIZE = SIZE / HALF;
        public const int RECOVER_SIZE = 30;

        public abstract Texture2D Spr { get; }
        public abstract Vector2 Pos { get; }
        public abstract float Rot { get; }
        public abstract Color Cr { get; }
        public abstract Vector2 Gap { get; }
        public abstract bool Bend { get; } //曲がり角かどうか

        public abstract Vector2[] DamagePos { get; }
        public abstract List<Vector2[]> RecoverPos { get; }

    }
}
