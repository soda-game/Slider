using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SliderAction
{
    struct PlayerVO
    {
        public bool deadF { get; set; }
        public Vector2 Size { get; }
        public int CharaNum { get; }
        public Vector2 Pos { get; set; }
        public float Speed { get; }
        public int RotNum { get; set; }
        public Texture2D[] Sprs { get; }
        public Vector2[] ColliPos { get; }
        public float[] Rots { get; }
        public Vector2[] MovesAsk { get; }

        public enum RotTyep
        {
            UP, UP_LEFT, UP_RIGHT,
            RIGHT, RIGHT_LEFT, RIGHT_RIGHT,
            DOWN, DOWN_LEFT, DOWN_RIGHT,
            LEFT, LEFT_LEFT, LEFT_RIGHT
        }


        public PlayerVO(int cNum, Texture2D[] spr, Vector2 Pos, float speed, int Rot, Vector2[] cp,Vector2 size)
        {
            CharaNum = cNum;
            Sprs = spr;
            this.Pos = Pos;
            Speed = speed;
            RotNum = Rot;
            ColliPos = cp;
            Size = size;
            deadF = false;

            Rots = new float[] {
             0,0,0,
             MathHelper.ToRadians(90), MathHelper.ToRadians(90), MathHelper.ToRadians(90),
             MathHelper.ToRadians(180), MathHelper.ToRadians(180), MathHelper.ToRadians(180),
             MathHelper.ToRadians(270), MathHelper.ToRadians(270), MathHelper.ToRadians(270)
              };
            MovesAsk = new Vector2[] {
              new Vector2(0, -1),new Vector2(-1, -1), new Vector2(1, -1),
              new Vector2(1, 0), new Vector2(1, -1), new Vector2(1, 1),
              new Vector2(0, 1), new Vector2(1, 1), new Vector2(-1, 1),
              new Vector2(-1, 0), new Vector2(-1, 1), new Vector2(-1, -1)
              };

        }
    }

    abstract class PlayerBase
    {
        protected PlayerVO pvo;
        public Vector2 Pos => pvo.Pos;
        public bool DeadF
        { get { return pvo.deadF; } set { if (value) pvo.deadF = true; } }
        public Vector2[] ColliPos => pvo.ColliPos;

        protected const int hp = 20; //hp***
        protected int count;
        public PlayerBase(PlayerVO pvo)
        {
            this.pvo = pvo;
            count = 0;
        }

        virtual public void Move()
        {
            Vector2 move = Vector2.Normalize(pvo.MovesAsk[pvo.RotNum]) * pvo.Speed;
            pvo.Pos += move;
            for (int i = 0; i < pvo.ColliPos.Length; i++) pvo.ColliPos[i] += move;
        }

        virtual public void RotChenge(int rot)
        {
            pvo.RotNum = rot;
        }

        virtual public bool CountCheck()
        {
            return true;
        }
        virtual public void CountCheckStart() //***
        {
            count = 10;
        }

        public void Checkout()
        {
            if (pvo.RotNum <= (int)PlayerVO.RotTyep.LEFT)
            {  //自分がその道の真ん中よりどっちか***
                pvo.RotNum++;
            }
            else if (pvo.RotNum <= (int)PlayerVO.RotTyep.LEFT_LEFT)
                pvo.RotNum++;
            else if (pvo.RotNum <= (int)PlayerVO.RotTyep.LEFT_RIGHT)
                pvo.RotNum--;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(pvo.Sprs[pvo.CharaNum], pvo.Pos, null, Color.White, pvo.Rots[pvo.RotNum], new Vector2(pvo.Size.X / OtherValue.HALF, pvo.Size.Y / OtherValue.HALF), Vector2.One, SpriteEffects.None, 0);
        }
    }

}
