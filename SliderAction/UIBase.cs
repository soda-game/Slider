using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SliderAction
{
    struct UIVO
    {
        public Texture2D[] textures { get; }
        public Vector2[] localPos { get; }
        public bool[] drawF { get; }

        public UIVO(Texture2D[] texture, Vector2[] localPos)
        {
            this.textures = texture;
            this.localPos = localPos;

            drawF = new bool[texture.Length];
            drawF = OtherSystem.AllIn(drawF, true);
        }
    }

    abstract class UIBase
    {
        protected UIVO uvo;

        public UIBase(ImageVo ivo)
        { }

        virtual public void Draw(SpriteBatch sb, Vector2 localDif)
        {
            for (int i = 0; i < uvo.drawF.Length; i++)
            {
                if (uvo.drawF[i])
                    sb.Draw(uvo.textures[i], uvo.localPos[i] + localDif, Color.White);
            }
        }
    }
}
