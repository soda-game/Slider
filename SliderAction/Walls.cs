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
    abstract class Walls
    {
        public Texture2D Sprite { get; set; }
        public Vector2 Pos { get; set; }
        public Vector2 Size { get; set; }
        bool nowDraw;

        public Walls()
        {  }
        public void Init()
        {
            //Pos = p;
            //Size = s;
            nowDraw = false;
        }

        public void DrawChenge()
        {

        }

        public void Draw()
        {

        }
    }
}
