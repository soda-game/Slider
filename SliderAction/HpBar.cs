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
        public float NowHp
        {
            get { return NowHp; }
            set
            {
                NowHp += value;
                if (NowHp < maxHp) return;
                NowHp = maxHp; ;
            }
        }

        public HpBar(AssetVo avo) : base(avo)
        {
            uavo = new Uavo(new Texture2D[] { avo.HpBar },
                                new Vector2[] { new Vector2(100, 100) });
            NowHp = maxHp;
            percent = size.X / maxHp;
        }

        public override void Draw(SpriteBatch sb, Vector2 localDif)
        {
            sb.Draw(uavo.textures[0], uavo.localPos[0] + localDif, Color.Red);
            sb.Draw(uavo.textures[0], uavo.localPos[0] + localDif, new Rectangle(0, 0, (int)(NowHp * percent), (int)size.Y), Color.White);
        }

    }
}
