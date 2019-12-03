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

        public enum GameType
        {
            NONE,
            NEXT
        }

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

        public int Main()
        {
            if (!initF) Init();

            if (Input.DownKey(Keys.Space))
                return (int)GameType.NEXT;
            return (int)GameType.NONE;
        }

        public void Draw(SpriteBatch sb, Vector2 localDif)
        {
            title.Draw(sb, localDif);
        }

    }
}
