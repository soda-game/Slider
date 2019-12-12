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
        HpBar hpBar;
        SoundEffect reco;
        ReadyUI readyUI;

        public SlideGame(Camera c, ImageVo ivo, SoundEffect reco,int winSize)
        {
            stageNum = 0;
            camera = c;
            walls = WallFactory.WallsCreate(stageNum, ivo);
            floors = FloorFactory.CriateFloor(stageNum, ivo);
            player = PlayerFactory.PlayerCreate(stageNum, ivo);
            bends = FloorFactory.BendPosAsk(floors);

            hpBar = new HpBar(ivo);
            readyUI = new ReadyUI(ivo,winSize);
            this.reco = reco;

            camera.Move(player.Pos);
        }

        public bool ReadyAnime(int typeNum)
        {
            if (readyUI.Anime(typeNum)) return true;
            return false;
        }

        public int Main()
        {
            if (player.Pos.Y < 0) return (int)MainGameType.CLEAR;
            else if (hpBar.DeadCheck())
            {
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
            reco.Play();
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
                    reco.Play();
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

        public void MainDraw(SpriteBatch sb, Vector2 localDif)
        {
            foreach (var f in floors) f.Draw(sb);
            foreach (var w in walls) w.Draw(sb);
            player.Draw(sb);

            foreach (var f in bends)
                sb.Draw(walls[0].recT, new Rectangle((int)f.pos[0].X, (int)f.pos[0].Y, (int)(f.pos[1].X - f.pos[0].X), (int)(f.pos[1].Y - f.pos[0].Y)), Color.White * 0.7f);
            hpBar.Draw(sb, localDif);
        }

        public void ReadyDraw(SpriteBatch sb, Vector2 localDif)
        {
            readyUI.Draw(sb, localDif);
        }
    }
}
