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
        TitleUI titleUI;

        public TitleManager(ImageVo ivo)
        {
            titleUI = new TitleUI(ivo);
        }

        public int Main()
        {
            if (Input.DownKey(Keys.Space))
                return (int)OtherValue.MainTyep.NEXT;
            return (int)OtherValue.MainTyep.NONE;
        }

        public void Draw(SpriteBatch sb, Vector2 localDif)
        {
            titleUI.Draw(sb, localDif);
        }

    }
}
