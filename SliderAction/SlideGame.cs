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
        Camera camera;

        //ステージ1
        int stageNum;
        bool initF;
        //壁
        List<Wall> walls;
        Player player;

        public SlideGame(Camera c) {
            stageNum = 0;
            initF = false;
            camera = c;
        }
        public void Loads(ContentManager content)
        {
            WallFactory.Load(content);
            PlayerFactory.Load(content);
        }

        public void Init()
        {
            walls = WallFactory.WallsCreate(stageNum);
            player = PlayerFactory.PlayerCreate(stageNum);

            foreach (var w in walls) w.Init();
            player.Init();
            initF = true;
        }
        public void Main()
        {
            if (!initF) Init();
        }

        public void Draw(SpriteBatch sb)
        {
            player.Draw(sb);
            foreach (var w in walls) w.Draw(sb);
        }
    }
}
