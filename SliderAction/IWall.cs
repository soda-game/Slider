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
    abstract class IWall
    {
        public Texture2D Sprite { get; set; }
        public Vector2 Pos { get; set; }
        public Vector2 Size { get; set; }
        public float Rot { get; set; }
        public Color Cr { get; set; }
        protected bool bend; //曲がり角かどうか
        protected bool nowDraw;

        //public IWall()
        //{ }
        //public void Init()
        //{ }
        //public void DrawChenge()
        //{ }
        //public void Draw(SpriteBatch sb)
        //{ }
        //internal class Init
        //{ }
    }
}
