using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SliderAction
{
    class SlideGame
    {
        //ステージ
        int stageNum;
        bool initF;
        //壁
        List<Wall> walls;

        public SlideGame() { stageNum = 0; initF = false; }
        public void Loads(ContentManager content)
        {
            WallFactory.Load(content);
        }

        public void Init()
        {
            walls = WallFactory.WallsCreate(stageNum);
            foreach (var w in walls) w.Init();
            initF = true;
        }
        public void Main()
        {
            if (!initF) Init();
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (var w in walls) w.Draw(sb);
        }
    }
}
