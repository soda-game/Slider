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
        public Texture2D[] textures;
        public Vector2[] localPos;
        public bool[] drawF;

        public UIVO(Texture2D[] texture, Vector2[] localPos)
        {
            this.textures = texture;
            this.localPos = localPos;

            drawF = new bool[texture.Length];
            drawF = OtherSystem.AllIn(drawF, true);
        }
    }

    abstract class IUI
    {
        protected UIVO uiVo;
        protected Vector2[] localPos;
        protected bool[] drawF;

        abstract public void Load(ContentManager c);
        virtual public void Init()
        {
            localPos = uiVo.localPos;
            drawF = uiVo.drawF;
        }

        virtual public void Draw(SpriteBatch sb, Vector2 localDif)
        {
            for (int i = 0; i < drawF.Length; i++)
            {
                if (drawF[i])
                    sb.Draw(uiVo.textures[i], localPos[i] + localDif, Color.White);
            }
        }
    }
}
