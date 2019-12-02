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
    class TitleManager : IManager
    {
        TitleUI title;
        bool initF;

        public TitleManager()
        {
            title = new TitleUI();
            initF = false;
        }
        public void Load(ContentManager c)
        {
            title.Load(c);
        }
        public void Init()
        {
            title.Init();
            initF = true;
        }

        public bool Main()
        {
            if (!initF) Init();

            if (Input.DownKey(Keys.Space))
                return true;
            return false;
        }

        public void Draw(SpriteBatch sb, Vector2 localDif)
        {
            title.Draw(sb, localDif);
        }

    }
}
