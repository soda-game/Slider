using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SliderAction
{
    class Floor : IFloor
    {
        FloorVO fvo;
        public override int Num => fvo.Num;
        protected override Texture2D Spr => fvo.Spr;
        protected override Vector2 Pos => fvo.Pos;
        public override int Bend => fvo.Bend;
        public override int B_Rot => fvo.B_Rot;
        public override Vector2[] ColliPos =>fvo.ColliPos;
        public override int[] Index => fvo.Index;

        public Floor(FloorVO fvo)
        {
            this.fvo = fvo;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Spr, Pos, null, Color.White, 0, new Vector2(H_SIZE, H_SIZE), Vector2.One, SpriteEffects.None, 0);
        }
    }
}
