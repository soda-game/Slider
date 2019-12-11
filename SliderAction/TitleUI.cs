using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace SliderAction
{
    class TitleUI : UIBase
    {
        public TitleUI(ImageVo ivo) : base(ivo)
        {
            uvo = new UIVO(new Texture2D[] { ivo.Title },
                            new Vector2[] { Vector2.Zero });
        }

    }
}
