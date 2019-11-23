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
        HpBar hpBar;
        Camera camera;


        public SlideGame(Camera c, HpBar h)
        {
            stageNum = 0;
            initF = false;
            camera = c;
            hpBar = h;
        }
        public void Loads(ContentManager c)
        {
            WallFactory.Load(c);
            PlayerFactory.Load(c);
            FloorFactory.Load(c);
            hpBar.Load(c);
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

        public void Main()//***もっと細かくメソッド分ける***
        {
            if (!initF) Init();

            hpBar.HpPlus(-0.3f);

            if (Input.DownKey(Keys.Space))
            {
                int bi = Collition.StayColl(bendPos, player.ColliPos);
                if (bi != -1)
                {
                    player.RotChenge(bendPos[bi].rot); //曲がり角だったら曲がる
                    hpBar.HpPlus(40f);
                }
                else
                {
                    //直線
                    foreach (var w in walls)
                    {
                        int ri = Collition.StayColl(w.RecoverPos, player.ColliPos);
                        if (ri != -1)
                        {
                            hpBar.HpPlus(10f); //回復ゾーンだったら回復
                        }
                    }
                    player.Checkout(); //斜め
                }
            }
            //else if (Input.DownKey(Keys.J))
            //{
            //    //まっすぐに
            //}
            else
            {
                foreach (var w in walls)
                    if (Collition.StayColl(w.DamagePos, player.ColliPos)) hpBar.HpPlus(-100f); //壁に当たったら死ぬ
            }

            if (hpBar.DeadCheck()) Debug.WriteLine("し！");

            player.Move();
            camera.Move(player.Pos);
            hpBar.Move(player.Pos);
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (var f in floors) f.Draw(sb);
            foreach (var w in walls) w.Draw(sb);
            player.Draw(sb);
            hpBar.Draw(sb);
        }
    }
}
