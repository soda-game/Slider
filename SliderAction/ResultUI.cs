using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SliderAction
{
    class ResultUI : UIBase
    {
        public ResultUI(AssetVo avo) : base(avo)
        {
            uavo = new Uavo(new Texture2D[] { avo.Result },
                            new Vector2[] { new Vector2(0, 0) });
        }

    }
}
