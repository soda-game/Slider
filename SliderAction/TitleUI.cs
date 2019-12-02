using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace SliderAction
{
    class TitleUI : IUI
    {
        public override void Load(ContentManager c)
        {
            uiVo = new UIVO(new Texture2D[] { c.Load<Texture2D>("Title") },
                            new Vector2[] { Vector2.Zero });
        }
    }
}
