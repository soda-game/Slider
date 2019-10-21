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
        public Wall()
        { }
        public void Init()
        {
            nowDraw = false;
        }

        public void DrawChenge()
        {
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Sprite, Pos, Color.White);
        }
    }
}
