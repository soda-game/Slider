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
        public int Num { get; set; } //CSV内で何個目か
        public  readonly int SIZE = 64;
        public Texture2D Spr { get; set; }
        public Vector2 Pos { get; set; }
        public float Rot { get; set; }
        public Color Cr { get; set; }
        public Vector2 Grap { get; set; }
        public bool Bend { get; set; } //曲がり角かどうか

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
