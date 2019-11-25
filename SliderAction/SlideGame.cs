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
        public static bool initF;
        //壁
        List<Wall> walls;
        List<Floor> floors;
        List<FloorFactory.BendSqr> bendPos;
        //プレイヤー
        Player player;
        HpBar hpBar = new HpBar();
        Camera camera;

        //あにめ
        Animetion anime = new Animetion();

        public void Init(Camera c)
        {
            stageNum = 0;
            initF = false;
            camera = c;
            hpBar.Init();
        }
        public void Loads(ContentManager c)
        {
            WallFactory.Load(c);
            PlayerFactory.Load(c);
            FloorFactory.Load(c);
            hpBar.Load(c);
            anime.Load(c);
        }

        public void Init()
        {
            walls = WallFactory.WallsCreate(stageNum);
            player = PlayerFactory.PlayerCreate(stageNum);
            floors = FloorFactory.CriateFloor(stageNum);
            bendPos = FloorFactory.BendPosAsk(floors);

            foreach (var w in walls) w.Init();
            player.Init();
            camera.Move(player.Pos);
            hpBar.Move(player.Pos);
            anime.SplitWaitDelay(2000);
            game = -1;
        }

        int game = -1;
        public int Main()
        {
            if (!initF) { Init(); return -1; }
 
            if (game == 0) { return 0; }
            else if (game == 1)
            {
                return 1;
            }
            if (player.deadF) { return -1; }

            if (Input.DownKey(Keys.Space))
            {
                if (!BendHit())
                {
                    Oblique();
                }
            }
            //else if (Input.DownKey(Keys.J))
            //{
            //    //まっすぐに
            //}
            else
            {
                WallHit();
            }

            if (player.Pos.Y < 0)
            {
                anime.SplitWaitDelay2(Dad, 0, 2000);
                return -1;
            }
            else if (hpBar.DeadCheck())
            {
                anime.SplitWaitDelay2(Dad, 1, 2000);
                player.deadF = true;
                return -1;
            }

            player.Move();
            camera.Move(player.Pos);
            hpBar.Move(player.Pos);
            hpBar.HpPlus(-0.3f);

            return -1;
        }

        public void Dad(int num)
        {
            game = num;
        }

        bool BendHit()//曲がり角だったら曲がる
        {
            int bi = Collition.StayColl(bendPos, player.ColliPos);
            if (bi == -1) return false;
            if (player.RotNum == bendPos[bi].rot) return false;
            player.RotChenge(bendPos[bi].rot);
            hpBar.HpPlus(40f);
            return true;
        }
        void Oblique()//斜め
        {
            foreach (var w in walls)
            {
                int ri = Collition.StayColl(w.RecoverPos, player.ColliPos);
                if (ri != -1)
                {
                    hpBar.HpPlus(10f); //回復ゾーンだったら回復
                }
            }
            player.Checkout();
        }
        void WallHit()//壁に当たったら死ぬ
        {
            foreach (var w in walls)
                if (Collition.StayColl(w.DamagePos, player.ColliPos)) hpBar.HpPlus(-100f);
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (var f in floors) f.Draw(sb);
            foreach (var w in walls) w.Draw(sb);
            foreach (var f in bendPos)
                sb.Draw(walls[0].recT, new Rectangle((int)f.pos[0].X, (int)f.pos[0].Y, (int)(f.pos[1].X - f.pos[0].X), (int)(f.pos[1].Y - f.pos[0].Y)), Color.Red);
            player.Draw(sb);
            anime.Draw(sb, player.Pos);
            hpBar.Draw(sb);
        }
    }
}
