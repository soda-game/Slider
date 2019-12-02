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
    interface IManager
    {
        void Load(ContentManager c);
        void Init();

        bool Main();
        void Draw(SpriteBatch sb, Vector2 localDif);
    }
}
