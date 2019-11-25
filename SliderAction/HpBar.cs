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
    class HpBar
    {
        Texture2D bar;
        readonly Vector2 size = new Vector2(300, 40);

        readonly Vector2 posInit = new Vector2(330, 330);
        Vector2 pos;

        const float maxHp = 200f;
        float nowHp;
        float percent; //hp最大値と画像サイズの割合 サイズや最大値が変わっても対応できる

        public HpBar()
        {
            nowHp = maxHp;
            percent = size.X / maxHp;
        }
        public void Load(ContentManager c)
        {
            bar = c.Load<Texture2D>("HpBar");
        }

        public void Move(Vector2 pMove)
        {
            pos = pMove - posInit;
        }
        public void HpPlus(float value)
        {
            nowHp += value;
            if (nowHp < maxHp) return;
            nowHp = maxHp;
        }
        public bool DeadCheck()
        {
            if (nowHp <= 0) return true;
            return false;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(bar, pos, new Rectangle((int)pos.X, (int)pos.Y, (int)(nowHp * percent), (int)size.Y), Color.White);
        }
    }
}
