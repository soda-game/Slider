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

namespace SliderAction
{
    class SlideGame
    {

        //ステージ1
        int stageNum;
        bool initF;
        //壁
        List<Wall> walls;
        List<Floor> floors;
        List<FloorFactory.BendSqr> bendPos;
        //プレイヤー
        Player player;
        Camera camera;


        public SlideGame(Camera c)
        {
            stageNum = 0;
            initF = false;
            camera = c;
        }
        public void Loads(ContentManager c)
        {
            WallFactory.Load(c);
            PlayerFactory.Load(c);
            FloorFactory.Load(c);
        }

        public void Init()
        {
            walls = WallFactory.WallsCreate(stageNum);
            player = PlayerFactory.PlayerCreate(stageNum);
            floors = FloorFactory.CriateFloor(stageNum);
            bendPos = FloorFactory.BendPosAsk(floors);

            foreach (var w in walls) w.Init();
            player.Init();
            initF = true;
        }

        public void Main()
        {
            if (!initF) Init();

            if (Input.DownKey(Keys.Space))
            {
                int i = Collition.StayColl(bendPos, player.ColliPos);

                if (i != -1)
                    player.RotChenge(bendPos[i].rot);
                else
                    player.Checkout();
            }

            player.Move();
            camera.Move(player.Pos);
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (var w in walls) w.Draw(sb);
            foreach (var f in floors) f.Draw(sb);
            player.Draw(sb);
        }
    }
}
