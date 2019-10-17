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
        WallFactory wallFactory = new WallFactory();
        Wall[] walls;

        public SlideGame() { stageNum = 0; initF = false; }
        public void Loads(ContentManager content)
        {
            wallFactory.Load(content);
        }

        public void Init()
        {
            walls = wallFactory.WallsCreate(stageNum);
            initF = true;
        }
        public void Main()
        {
            if (!initF) Init();

        }

        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < walls.Length; i++)
                sb.Draw(walls[i].Sprite, walls[i].Pos, Color.White);
        }
    }
}
