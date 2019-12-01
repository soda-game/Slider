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
        public Texture2D texture;
        public Vector2 localPos;
        public bool drawF;

        public UIVO(Texture2D texture, Vector2 localPos)
        {
            this.texture = texture;
            this.localPos = localPos;
            drawF = true;
        }
    }

    abstract class IUI
    {
        abstract protected Texture2D Texture { get; }
        abstract protected Vector2 LocalPos { get; }
        abstract protected bool DrawF { get; }

        abstract public void Init();
        abstract public void Load(ContentManager c);

        virtual public void Draw(SpriteBatch sb, Vector2 localDif)
        {
            if (DrawF)
                sb.Draw(Texture, LocalPos + localDif, Color.White);
        }
    }
}
