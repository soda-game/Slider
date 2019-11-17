using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SliderAction
{
    class Player : IPlayer
    {

        PlayerVO pvo;

        int charaNum;
        protected override int CharaNum => charaNum;
        protected override Texture2D[] Spr => pvo.Sprs;
        Vector2 pos;
        public override Vector2 Pos =>pos;
        float speed;
        protected override float Speed => speed;
        float rot;
        protected override float Rot => rot;

        public enum RotTyep //***
        { UP, RIGHT, DOWN, LEFT }
        static readonly float[] rots = new float[] { 0, MathHelper.ToRadians(90), MathHelper.ToRadians(180), MathHelper.ToRadians(270) };
        enum DiaRotTyep
        { UP_LEFT, UP_RIGHT, RIGHT_LEFT, RIGHT_RIGHT, DOWNT_LEFT, DOWN_RIGHT, LEFT_LEFT, LEFT_RIGHT }
        readonly float[] diaRots = new float[] {
            MathHelper.ToRadians(330), MathHelper.ToRadians(30),
            MathHelper.ToRadians(60), MathHelper.ToRadians(120),
            MathHelper.ToRadians(150), MathHelper.ToRadians(210),
            MathHelper.ToRadians(240), MathHelper.ToRadians(300),
        };

        public Player(PlayerVO pvo)
        {
            this.pvo = pvo;
        }
        public void Init()
        {
            charaNum = pvo.InitCharaNum;
            pos = pvo.InitPos;
            speed = pvo.InitSpeed;
            rot = pvo.InitRot;
        }
        public void Move()
        {

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Spr[charaNum], pos, null, Color.White, rot, new Vector2(H_SIZE.X, H_SIZE.Y), Vector2.One, SpriteEffects.None, 0);
        }
    }
}
