using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SliderAction
{
    class ResultUI:UIBase
    {
        public ResultUI(ImageVo ivo):base(ivo)
        {
            uvo = new UIVO(new Texture2D[] { ivo.Result },
                            new Vector2[] { new Vector2(0, 0) });
        }
    }
}
