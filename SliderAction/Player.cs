using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SliderAction
{
    class Player : IPlayer
    {
        public const int hp = 20; //hp***

        PlayerVO pvo;
        public bool deadF;

        int charaNum;
        protected override int CharaNum => charaNum;
        protected override Texture2D[] Spr => pvo.Sprs;
        Vector2 pos;
        public override Vector2 Pos => pos;
        float speed;
        protected override float Speed => speed;
        int rotNum;
        public override int RotNum => rotNum;
        Vector2[] colliPos;
        public override Vector2[] ColliPos => colliPos;

        enum RotTyep //別クラス***
        {
            UP, UP_LEFT, UP_RIGHT,
            RIGHT, RIGHT_LEFT, RIGHT_RIGHT,
            DOWN, DOWN_LEFT, DOWN_RIGHT,
            LEFT, LEFT_LEFT, LEFT_RIGHT
        }
        //readonly float[] rots = new float[] {
        //     0,MathHelper.ToRadians(330), MathHelper.ToRadians(30),
        //     MathHelper.ToRadians(90), MathHelper.ToRadians(60), MathHelper.ToRadians(120),
        //     MathHelper.ToRadians(180), MathHelper.ToRadians(150), MathHelper.ToRadians(210),
        //     MathHelper.ToRadians(270), MathHelper.ToRadians(240), MathHelper.ToRadians(300)
        //};
        readonly float[] rots = new float[] {
             0,0,0,
             MathHelper.ToRadians(90), MathHelper.ToRadians(90), MathHelper.ToRadians(90),
             MathHelper.ToRadians(180), MathHelper.ToRadians(180), MathHelper.ToRadians(180),
             MathHelper.ToRadians(270), MathHelper.ToRadians(270), MathHelper.ToRadians(270)
        };
        Vector2[] MovesAsk = new Vector2[] {
              new Vector2(0, -1),new Vector2(-1, -1), new Vector2(1, -1),
              new Vector2(1, 0), new Vector2(1, -1), new Vector2(1, 1),
              new Vector2(0, 1), new Vector2(1, 1), new Vector2(-1, 1),
              new Vector2(-1, 0), new Vector2(-1, 1), new Vector2(-1, -1)
              };
        int count;
        public Player(PlayerVO pvo)
        {
            this.pvo = pvo;
        }
        public void Init()
        {
            deadF = false;
            charaNum = pvo.InitCharaNum;
            pos = pvo.InitPos;
            speed = pvo.InitSpeed;
            rotNum = pvo.InitRotNum;
            colliPos = pvo.ColliPos;
            count = 0;
        }

        public void Move()
        {
            Vector2 move = Vector2.Normalize(MovesAsk[rotNum])*speed;
            pos += move;
            for (int i = 0; i < colliPos.Length; i++) colliPos[i] += move;
        }
        public void RotChenge(int rot)
        {
            this.rotNum = rot;
        }

        public void Count() { count--; }
        public bool CountCheck()
        {
            if (count < 0) return true;
            return false;
        }
        public void CountCheckStart()
        {
            count = 10;
        }


        public void Checkout()
        {
            switch (rotNum)
            {
                case (int)RotTyep.UP:
                case (int)RotTyep.RIGHT:
                case (int)RotTyep.DOWN:
                case (int)RotTyep.LEFT:
                    //自分がその道の真ん中よりどっちか***
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
