using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace SliderAction
{
    class Title : IUI
    {
        UIVO uiVo;

        protected override Texture2D Texture => uiVo.texture;
        protected override Vector2 LocalPos => uiVo.localPos;
        bool drawF;
        protected override bool DrawF => drawF;

        public override void Load(ContentManager c)
        { uiVo = new UIVO(c.Load<Texture2D>("Title"), Vector2.Zero); }
        public override void Init()
        {
            drawF = uiVo.drawF;
        }


    }
}
