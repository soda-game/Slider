using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace SliderAction
{
    class TitleUI : UIBase
    {
        public TitleUI(AssetVo avo) : base(avo)
        {
            uavo = new UIVO(new Texture2D[] { avo.Title },
                            new Vector2[] { Vector2.Zero });
        }
    }
}
