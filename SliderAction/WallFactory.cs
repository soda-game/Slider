using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace SliderAction
{
    class WallFactory
    {
        //Size
        enum SizeTyep
        {
            SMALL_SHORT, SMALL_MIDDLE, SMALL_LONG,
            BIG_SHORT, BIG_MIDDLE, BIG_LONG,
        }
        static readonly Vector2[] sizes = new Vector2[] { new Vector2(100, 32), new Vector2(200, 32), new Vector2(300, 32), new Vector2(100, 60), new Vector2(200, 60), new Vector2(300, 60) };
        //Splite
        static Texture2D[] splites;
        //Rot
        enum RotTyep
        {
            VERTICAL,HENG
        }
        static readonly float[] rots = new float[] { MathHelper.ToRadians(90), 0 };
        //Cr
        enum CrTyep
        {
           BLUE, RED,ORANGE, YELLOW,GREEN
        }
        static readonly Color[] crs = new Color[] { Color.Blue, Color.Red, Color.Orange, Color.Yellow, Color.Green };


        //StageList
        static readonly SizeTyep[] stList = new SizeTyep[] { SizeTyep.SMALL_SHORT, SizeTyep.SMALL_MIDDLE, SizeTyep.SMALL_SHORT }; //ステージ01の画像
        static readonly Vector2[] posList = new Vector2[] { new Vector2(350, 200), new Vector2(350, 350), new Vector2(350, 500) }; //ステージ01の壁の座標
        static readonly RotTyep[] rotList = new RotTyep[] {RotTyep.VERTICAL, RotTyep.VERTICAL,RotTyep.VERTICAL}; //ステージ01の縦横
        static readonly CrTyep[] crList = new CrTyep[] { CrTyep.BLUE, CrTyep.BLUE, CrTyep.BLUE }; //色
        static readonly SizeTyep[] stList01 = new SizeTyep[] { SizeTyep.SMALL_SHORT }; //ステージ02の画像
        static readonly Vector2[] posList01 = new Vector2[] { new Vector2(50, 10) }; //ステージ02の壁の座標
        static readonly RotTyep[] rotList01 = new RotTyep[] { RotTyep.VERTICAL, RotTyep.VERTICAL, RotTyep.VERTICAL }; //ステージ02の縦横
        static readonly CrTyep[] crList01 = new CrTyep[] { CrTyep.BLUE, CrTyep.BLUE, CrTyep.BLUE }; //色


        public enum Stage
        {
            STAGE00,
            STAGE01,
        }
        static readonly Dictionary<int, (SizeTyep[], Vector2[],RotTyep[],CrTyep[])> mapTable = new Dictionary<int, (SizeTyep[], Vector2[],RotTyep[],CrTyep[])>() //壁のステータスすべて
        {
            { (int)Stage.STAGE00,( stList,posList,rotList,crList)  },
            { (int)Stage.STAGE01,( stList01,posList01,rotList01,crList01)  }
        };

        static public void Load(ContentManager c)
        {
            splites = new Texture2D[] { c.Load<Texture2D>("SmallShort"), c.Load<Texture2D>("SmallMiddle") };
        }


        static public Wall[] WallsCreate(int sn)
        {
            Wall[] walls = new Wall[mapTable[sn].Item1.Length]; //壁の個数
            for (int i = 0; i < walls.Length; i++) //ここで量産
            {
                walls[i] = new Wall();
                walls[i].Sprite = splites[(int)mapTable[sn].Item1[i]];
                walls[i].Size = sizes[(int)mapTable[sn].Item1[i]];
                walls[i].Pos = mapTable[sn].Item2[i];
                walls[i].Rot = rots[(int)mapTable[sn].Item3[i]];
                walls[i].Cr = crs[(int)mapTable[sn].Item4[i]];
            }

            return walls;
        }
    }
}
