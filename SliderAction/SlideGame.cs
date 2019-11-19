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
//using InputManager.Input; //***

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
        Input input;
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
            input = new Input();

            foreach (var w in walls) w.Init();
            player.Init();
            initF = true;
        }
        public void Main()
        {
            if (!initF) Init();

            if (input.DownKey(Keys.Space)) player.Checkout();

            player.Move();
            camera.Move(player.Pos);

            foreach (var w in walls) Collition.StayColl(w.DamagePos, player.ColliPos);
            foreach (var b in bendPos) if (Collition.StayColl(b.pos, player.ColliPos)) Debug.WriteLine(b.rot);
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (var w in walls) w.Draw(sb);
            foreach (var f in floors) f.Draw(sb);
            player.Draw(sb);
        }
    }
}
