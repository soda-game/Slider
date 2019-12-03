using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SliderAction
{
    class HpBar : IUI
    {
        readonly Vector2 size = new Vector2(300, 40);

        const float maxHp = 200f;
        float nowHp;
        float percent; //hp最大値と画像サイズの割合 サイズや最大値が変わっても対応できる

        public override void Load(ContentManager c)
        {
            uiVo = new UIVO(new Texture2D[] { c.Load<Texture2D>("HpBar") },
                                new Vector2[] { new Vector2(100, 100) });
        }

        public override void Init()
        {
            nowHp = maxHp;
            percent = size.X / maxHp;
            base.Init();
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

        public override void Draw(SpriteBatch sb, Vector2 localDif)
        {
            sb.Draw(uiVo.textures[0], localPos[0] + localDif, Color.Red);
            sb.Draw(uiVo.textures[0], localPos[0] + localDif, new Rectangle(0, 0, (int)(nowHp * percent), (int)size.Y), Color.White);
        }

    }
}
