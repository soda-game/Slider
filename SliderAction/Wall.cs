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
    class Wall : IWall
    {
        const int HALF = 2;
        public const int SIZE = 64;
        public const int H_SIZE = SIZE / HALF;
        public const int C_SIZE = 64;

        Vector2 pos;
        public Vector2 Pos => pos;
        bool nowDraw;
        public bool NowDraw => nowDraw;

        public Wall()
        { }
        public void Init()
        {
            nowDraw = true;
            pos = new Vector2((PosBase.X * SIZE) + Grap.X, (PosBase.Y * SIZE) + Grap.Y);
        }

        public void DrawChenge() //***最初はfalse 移ったものだけtrue
        {
        }

        public void Draw(SpriteBatch sb)
        {
            if (!nowDraw) return;
            sb.Draw(Spr, Pos, null, Cr, Rot, new Vector2(SIZE / HALF, SIZE / HALF), Vector2.One, SpriteEffects.None, 0);
        }
    }
}
