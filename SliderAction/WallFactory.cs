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
        //ステージごとにCSVを分ける
        static readonly string[] csvPaths = new string[] { "CSV/wall.txt" };
        enum ColumnNum
        { NUM, SIZE, PX, PY, CR, ROT }

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
            HENG, VERTICAL
        }
        static readonly float[] rots = new float[] { 0, MathHelper.ToRadians(90) };
        //Cr
        enum CrTyep
        {
            BLUE, RED, ORANGE, YELLOW, GREEN
        }
        static readonly Color[] crs = new Color[] { Color.Blue, Color.Red, Color.Orange, Color.Yellow, Color.Green };


        static public void Load(ContentManager c)
        {
            splites = new Texture2D[] {
                c.Load<Texture2D>("SmallShort"), c.Load<Texture2D>("SmallMiddle"), c.Load<Texture2D>("SmallLong"),
                c.Load<Texture2D>("BigShort"), c.Load<Texture2D>("BigMiddle"), c.Load<Texture2D>("BigLong")
            };
        }

        static public Wall[] WallsCreate(int sn)
        {
            List<int[]> csvList = ReadCSV.WallCsv(csvPaths[sn]); //csv読み込み結果を受け取り
            Wall[] walls = new Wall[csvList.Count]; //壁の個数

            for (int i = 0; i < walls.Length; i++) //ここで量産
            {
                walls[i] = new Wall();
                walls[i].Num = csvList[i][(int)ColumnNum.NUM];
                walls[i].Cr = crs[csvList[i][(int)ColumnNum.CR]];
                walls[i].Pos = new Vector2(csvList[i][(int)ColumnNum.PX], csvList[i][(int)ColumnNum.PY]);
                walls[i].Size = sizes[csvList[i][(int)ColumnNum.SIZE]];
                walls[i].Sprite = splites[csvList[i][(int)ColumnNum.SIZE]];
                walls[i].Rot = rots[csvList[i][(int)ColumnNum.ROT]];

            }

            return walls;
        }
    }
}
