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
            bend = false;
        }

        public void DrawChenge() //***最初はfalse 移ったものだけtrue
        {
        }

        public void Draw(SpriteBatch sb)
        {
            if (!nowDraw) return;
            sb.Draw(Sprite, Pos,null, Cr,Rot,new Vector2(Size.X/HALF,Size.Y/HALF),Vector2.One,SpriteEffects.None,0);
        }
    }
}
