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

        public Wall()
        { }
        public void Init()
        {
            nowDraw = true;
            Pos = new Vector2((Pos.X * SIZE) + SIZE / HALF, (Pos.Y * SIZE) + SIZE / HALF);
        }

        public void DrawChenge() //***最初はfalse 移ったものだけtrue
        {
        }

        public void Draw(SpriteBatch sb)
        {
            if (!nowDraw) return;
            sb.Draw(Spl, Pos, null, Cr, Rot, new Vector2(SIZE / HALF, SIZE / HALF), Vector2.One, SpriteEffects.None, 0);
        }
    }
}
