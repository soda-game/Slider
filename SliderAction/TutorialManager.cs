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
    class TutorialManager : IManager
    {
        TutorialUI tutorialUI;

        public TutorialManager(ImageVo ivo)
        {
            tutorialUI = new TutorialUI(ivo);
        }

        public int Main()
        {
            if (Input.DownKey(Keys.Space))
                return (int)OtherValue.MainTyep.NEXT;
            return (int)OtherValue.MainTyep.NONE;
        }

        public void Draw(SpriteBatch sb, Vector2 localDif)
        {
            tutorialUI.Draw(sb,localDif);
        }
    }
}
