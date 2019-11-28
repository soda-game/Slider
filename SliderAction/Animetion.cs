using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading.Tasks;

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
            t = new Texture2D[] { c.Load<Texture2D>("goal"), c.Load<Texture2D>("out"), c.Load<Texture2D>("ready"), c.Load<Texture2D>("go") };
        }

        public async void SplitWaitDelay(int time)
        {
            if (a == 0)
            {
                drawF = true;
                nowT = t[2];
                this.pos = new Vector2(-200, 100);
                await Task.Delay(time);
                a = 1;
            }
            else if (a == 1)
            {
                this.pos = new Vector2(-100, 100);
                nowT = t[3];
                await Task.Delay(time);
                drawF = false;
                SlideGame.initF = true;
                a = 0;
            }
        }

        public async void SplitWaitDelay2(Action<int> d,int num, int time)
        {
            drawF = true;
            nowT = t[num];
            this.pos = new Vector2(-210, 100);
            await Task.Delay(time);
            drawF = false;
            d(num);
        }

        public void Draw(SpriteBatch sb, Vector2 pPos)
        {
            if (drawF)
                sb.Draw(nowT, pos + pPos, Color.White);
        }
    }
}
