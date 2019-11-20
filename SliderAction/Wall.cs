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
        bool nowDraw;
        public bool NowDraw => nowDraw;

        WallVO wallVo;
        public override Texture2D Spr => wallVo.Spr;
        public override Vector2 Pos => wallVo.Pos;
        public override Vector2[] DamagePos => wallVo.DamagePos;
        public override float Rot => wallVo.Rot;
        public override Color Cr => wallVo.Cr;
        public override Vector2 Gap => wallVo.Gap;
        public override bool Bend => wallVo.Bend;

        //テスト
        Texture2D recT;

        public Wall(WallVO wvo, Texture2D rect)
        {
            wallVo = wvo;
            recT = rect;
        }
        public void Init()
        {
            nowDraw = true;
        }

        public void DrawChenge() //***最初はfalse 移ったものだけtrue
        {
        }

        public void Draw(SpriteBatch sb)
        {
            if (!nowDraw) return;
            sb.Draw(recT, new Rectangle((int)DamagePos[1].X, (int)DamagePos[0].Y,30, (int)(DamagePos[1].Y - DamagePos[0].Y)), Color.Wheat);
            sb.Draw(Spr, Pos, null, Cr, Rot, new Vector2(HALF_SIZE, HALF_SIZE), Vector2.One, SpriteEffects.None, 0);
        }
    }
}
