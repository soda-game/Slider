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
                int bi = Collition.StayColl(bendPos, player.ColliPos);
                if (bi != -1)
                { player.RotChenge(bendPos[bi].rot); } //曲がり角だったら曲がる

                else//直線だったら斜め
                {
                    foreach (var w in walls)
                    {
                        int ri = Collition.StayColl(w.RecoverPos, player.ColliPos);
                        if (ri == -1) break;
                        //回復ゾーンだったら回復
                    }
                    player.Checkout();
                }
            }
            else
                ; //壁に当たったら死ぬ

            player.Move();
            camera.Move(player.Pos);
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (var f in floors) f.Draw(sb);
            foreach (var w in walls) w.Draw(sb);
            player.Draw(sb);
        }
    }
}
