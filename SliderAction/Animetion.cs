using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Threading;

namespace SliderAction
{
    class Animetion
    {
        Texture2D nowT;
        Texture2D[] t;
        Vector2 pos;
        bool drawF;
        int a = 0;
        public /*abstract*/ void Load(ContentManager c)
        {
            t = new Texture2D[] { c.Load<Texture2D>("ready"), c.Load<Texture2D>("go") };
        }

        public async void SplitWaitDelay(int time)
        {
            if (a == 0)
            {
                drawF = true;
                nowT = t[0];
                this.pos = new Vector2(-100, -100);
                await Task.Delay(time);
                a = 1;
            }
            else if (a == 1)
            {
                nowT = t[1];
                await Task.Delay(time);
                drawF = false;
                SlideGame.initF = true;
                a = 0;
            }
        }

        public async void SplitWaitDelay2(Action d, int time)
        {
            drawF = true;
            nowT = t[1];
            await Task.Delay(time);
            drawF = false;
            d();
        }

        public void Draw(SpriteBatch sb, Vector2 pPos)
        {
            if (drawF)
                sb.Draw(nowT, pos + pPos, Color.White);
        }
    }
}
