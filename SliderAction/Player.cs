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
        public override Vector2 Pos => pos;
        float speed;
        protected override float Speed => speed;
        int rotNum;
        protected override int RotNum => rotNum;

        enum RotTyep
        {
            UP, UP_LEFT, UP_RIGHT,
            RIGHT, RIGHT_LEFT, RIGHT_RIGHT,
            DOWN, DOWN_LEFT, DOWN_RIGHT,
            LEFT, LEFT_LEFT, LEFT_RIGHT
        }
        readonly float[] rots = new float[] {
             0,MathHelper.ToRadians(330), MathHelper.ToRadians(30),
             MathHelper.ToRadians(90), MathHelper.ToRadians(60), MathHelper.ToRadians(120),
             MathHelper.ToRadians(180), MathHelper.ToRadians(150), MathHelper.ToRadians(210),
             MathHelper.ToRadians(270), MathHelper.ToRadians(240), MathHelper.ToRadians(300)
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
            rotNum = pvo.InitRotNum;

            speed = 5;
        }

        public void Move()
        {
            Vector2[] moves = new Vector2[] { //***ref
              new Vector2(0, -speed),new Vector2(-speed, -speed), new Vector2(speed, -speed),
              new Vector2(speed, 0), new Vector2(speed, -speed), new Vector2(speed, speed),
              new Vector2(0, speed), new Vector2(speed, speed), new Vector2(-speed, speed),
              new Vector2(-speed, 0), new Vector2(-speed, speed), new Vector2(-speed, -speed)
              };

            pos += moves[rotNum];
        }
        public void Checkout()
        {
            switch (rotNum)
            {
                case (int)RotTyep.UP:
                case (int)RotTyep.RIGHT:
                case (int)RotTyep.DOWN:
                case (int)RotTyep.LEFT:
                    //自分がその道の真ん中よりどっちか
                    rotNum++;
                    break;
                case (int)RotTyep.UP_LEFT:
                case (int)RotTyep.RIGHT_LEFT:
                case (int)RotTyep.DOWN_LEFT:
                case (int)RotTyep.LEFT_LEFT:
                    rotNum++;
                    break;
                case (int)RotTyep.UP_RIGHT:
                case (int)RotTyep.RIGHT_RIGHT:
                case (int)RotTyep.DOWN_RIGHT:
                case (int)RotTyep.LEFT_RIGHT:
                    rotNum--;
                    break;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Spr[charaNum], pos, null, Color.White, rots[rotNum], new Vector2(H_SIZE.X, H_SIZE.Y), Vector2.One, SpriteEffects.None, 0);
        }
    }
}
