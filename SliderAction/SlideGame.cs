using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SliderAction
{
    class SlideGame : IManager
    {
        //ステージ1
        int stageNum;
        public static bool initF;
        public enum MainGameType
        { NOW, CLEAR, OVER }
        Camera camera;

        //壁
        List<Wall> walls;
        List<Floor> floors;
        List<FloorFactory.BendSqr> bends;
        //プレイヤー
        Player player;

        //UI
        HpBar hpBar = new HpBar();

        //SoundEffect se;
        //あにめ
        //Animetion anime = new Animetion();

        public SlideGame(Camera c)
        {
            stageNum = 0;
            camera = c;
            initF = true;
        }
        public void Load(ContentManager c)
        {
            WallFactory.Load(c);
            PlayerFactory.Load(c);
            FloorFactory.Load(c);
            hpBar.Load(c);
            //anime.Load(c);
            //se = c.Load<SoundEffect>("recover");
        }
        public void Init()
        {
            walls = WallFactory.WallsCreate(stageNum);
            floors = FloorFactory.CriateFloor(stageNum);
            bends = FloorFactory.BendPosAsk(floors);
            player = PlayerFactory.PlayerCreate(stageNum);

            hpBar.Init();
            initF = false;
        }

        public int Main()
        {
            if (initF) Init();
            if (player.Pos.Y < 0) return (int)MainGameType.CLEAR;
            else if (hpBar.DeadCheck())
            {
                //anime.SplitWaitDelay2(Dad, 1, 2000);
                player.DeadF = true;
                return (int)MainGameType.OVER;
            }

            if (Input.DownKey(Keys.Space))
            {
                if (player.CountCheck())
                {
                    if (!BendHit()) Oblique();
                    player.CountCheckStart();
                }
            }
            else
            {
                WallHit();
            }
            hpBar.HpPlus(-0.45f);

            player.Move();
            camera.Move(player.Pos);
            return (int)MainGameType.NOW;
        }

        bool BendHit()//曲がり角だったら曲がる
        {
            int bi = Collition.StayColl(bends, player.ColliPos);
            if (bi == -1 || bends[bi].end == true) return false; //2度めは判定しない

            player.RotChenge(bends[bi].rot);
            bends[bi] = FloorFactory.BendChenge(bends[bi]);
            hpBar.HpPlus(50f);
            //se.Play();
            return true;
        }

        void Oblique()//斜め
        {
            foreach (var w in walls)
            {
                int ri = Collition.StayColl(w.RecoverPos, player.ColliPos);
                if (ri != -1)
                {
                    hpBar.HpPlus(30f); //回復ゾーンだったら回復
                    //se.Play();
                    break;
                }
            }
            player.Checkout();
        }

        void WallHit()//壁に当たったら死ぬ
        {
            foreach (var w in walls)
                if (Collition.StayColl(w.DamagePos, player.ColliPos)) hpBar.HpPlus(-100f);
        }

        public void Draw(SpriteBatch sb, Vector2 localDif)
        {
            foreach (var f in floors) f.Draw(sb);
            foreach (var w in walls) w.Draw(sb);
            foreach (var f in bends)
                sb.Draw(walls[0].recT, new Rectangle((int)f.pos[0].X, (int)f.pos[0].Y, (int)(f.pos[1].X - f.pos[0].X), (int)(f.pos[1].Y - f.pos[0].Y)), Color.White * 0.7f);
            player.Draw(sb);
            //anime.Draw(sb, player.Pos);
            hpBar.Draw(sb, localDif);
        }


    }
}
