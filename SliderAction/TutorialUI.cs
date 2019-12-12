using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SliderAction
{
    class TutorialUI : UIBase
    {
        public TutorialUI(ImageVo ivo) : base(ivo)
        {
            uvo = new UIVO(new Texture2D[] { ivo.Tutorial }, new Vector2[] { new Vector2(0, -50) });
        }

        public bool PushKey()
        {
            if (Input.DownKey(Keys.Space))
                return true;
            return false;
        }
    }
}
