using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SliderAction
{
    class HpBar : UIBase
    {
        readonly Vector2 size = new Vector2(300, 40);

        const float maxHp = 200f;
        float percent; //hp最大値と画像サイズの割合 サイズや最大値が変わっても対応できる
        float nowHp;
        public float NowHp => nowHp;



        public HpBar(ImageVo ivo) : base(ivo)
        {
            uvo = new UIVO(new Texture2D[] { ivo.HpBar },
                                new Vector2[] { new Vector2(100, 100) });
            nowHp = maxHp;
            percent = size.X / maxHp;
        }

        public bool DeadCheck()
        {
            if (NowHp < 0) return true;
            return false;
        }

        public void HpPlus(float value)
        {
            nowHp += value;
            if (NowHp < maxHp) return;
            nowHp = maxHp; ;
        }

        public override void Draw(SpriteBatch sb, Vector2 localDif)
        {
            sb.Draw(uvo.textures[0], uvo.localPos[0] + localDif, Color.Red);
            sb.Draw(uvo.textures[0], uvo.localPos[0] + localDif, new Rectangle(0, 0, (int)(NowHp * percent), (int)size.Y), Color.White);
        }

    }
}
