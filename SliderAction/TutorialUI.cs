using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SliderAction
{
    class TutorialUI : UIBase
    {
        public TutorialUI(AssetVo avo) : base(avo)
        {
            uavo = new Uavo(new Texture2D[] { avo.Tutorial }, new Vector2[] { new Vector2(0, -50) });
        }

        public bool PushKey()
        {
            if (Input.DownKey(Keys.Space))
                return true;
            return false;
        }
    }
}
