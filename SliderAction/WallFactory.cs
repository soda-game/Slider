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
        enum SizeTyep //画像サイズの種類
        {
            SMALL_SHORT, SMALL_MIDDLE, SMALL_LONG,
            BIG_SHORT, BIG_MIDDLE, BIG_LONG,
        }
        static readonly Texture2D[] sizeTyepSr = new Texture2D[sizeof(SizeTyep)]; //画像
        Dictionary<SizeTyep, Func<Wall>> wallTable = new Dictionary<SizeTyep, Func<Wall>>()  //サイズとインスタンス化
        {
            { SizeTyep.SMALL_SHORT, () => new Wall() {Size= new Vector2(100,32)} },
            { SizeTyep.SMALL_MIDDLE, () => new Wall() {Size= new Vector2(200,32)} }
        };

        static readonly SizeTyep[] stList = new SizeTyep[] { SizeTyep.SMALL_SHORT, SizeTyep.SMALL_MIDDLE, SizeTyep.SMALL_SHORT }; //ステージ01の画像
        static readonly Vector2[] posList = new Vector2[] { new Vector2(10, 10), new Vector2(200, 50), new Vector2(350, 150) }; //ステージ01の壁の座標
        static readonly SizeTyep[] stList01 = new SizeTyep[] { SizeTyep.SMALL_SHORT }; //ステージ02の画像
        static readonly Vector2[] posList01 = new Vector2[] { new Vector2(50, 10) }; //ステージ02の壁の座標

        public enum Stage
        {
            STAGE00,
            STAGE01,
        }
        Dictionary<int, (SizeTyep[], Vector2[])> mapTable = new Dictionary<int, (SizeTyep[], Vector2[])>() //壁のステータスすべて
        {
            { (int)Stage.STAGE00,( stList,posList)  },
            { (int)Stage.STAGE01,( stList01,posList01)  }
        };

        public void Load(ContentManager c)
        {
            sizeTyepSr[(int)SizeTyep.SMALL_SHORT] = c.Load<Texture2D>("SmallShort");
            sizeTyepSr[(int)SizeTyep.SMALL_MIDDLE] = c.Load<Texture2D>("SmallMiddle");

        }


        public Wall[] WallsCreate(int sn)
        {
            Wall[] walls = new Wall[mapTable[sn].Item1.Length]; //壁の個数
            for (int i = 0; i < walls.Length; i++) //ここで量産
            {
                walls[i] = wallTable[mapTable[sn].Item1[i]]();
                walls[i].Pos = mapTable[sn].Item2[i];
                walls[i].Sprite = sizeTyepSr[(int)mapTable[sn].Item1[i]];
            }

            return walls;
        }
    }
}
