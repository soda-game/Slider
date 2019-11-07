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
        const int WHITS_IDX = 0;
        static readonly string[] mapPaths = new string[] { "CSV/map.txt" };
        static readonly string[] statPaths = new string[] { "CSV/wall.txt" };
        enum ColumnNum
        { NUM, SPR, CR, ROT, BEND, GAPX, GAPY }

        //Splite
        const int HALF = 2;
        enum SizeTyep
        { WAY, END }
        static Texture2D[] splites;
        //Rot
        enum RotTyep
        { HENG, VERTICAL }
        static readonly float[] rots = new float[] { 0, MathHelper.ToRadians(90) };
        //Cr
        enum CrTyep
        { BLUE, RED, ORANGE, YELLOW, GREEN }
        static readonly Color[] crs = new Color[] { Color.Blue, Color.Red, Color.Orange, Color.Yellow, Color.Green };


        static public void Load(ContentManager c)
        {
            splites = new Texture2D[] { c.Load<Texture2D>("wall") /*,c.Load<Texture2D>("SmallMiddle")*/ };//***
        }

        static public Wall[] WallsCreate(int sn)
        {
            List<int> mapCsv = ReadCSV.ReadList(mapPaths[sn]);
            List<int[]> StatusCsv = ReadCSV.ReadArray(statPaths[sn]); //csv読み込み結果を受け取り
            Wall[] walls = new Wall[StatusCsv.Count]; //壁の個数

            int wight = mapCsv[WHITS_IDX]; //１要素目はwightが入っている
            mapCsv.RemoveAt(WHITS_IDX); //使ったら消す

            for (int i = 0; i < walls.Length; i++) //ここで量産
            {
                Wall w = walls[i];
                w = new Wall();
                w.Num = StatusCsv[i][(int)ColumnNum.NUM];
                w.Spl = splites[StatusCsv[i][(int)ColumnNum.SPR]];
                w.Cr = crs[StatusCsv[i][(int)ColumnNum.CR]];
                w.Grap = new Vector2(StatusCsv[i][(int)ColumnNum.GAPX], StatusCsv[i][(int)ColumnNum.GAPY]);
                w.Rot = rots[StatusCsv[i][(int)ColumnNum.ROT]];
                w.Bend = Convert.ToBoolean(StatusCsv[i][(int)ColumnNum.BEND]); //intをbool変換

                //mapCsvから自分の番号の座標を抜き出しす
                int index = mapCsv.FindIndex(n => n == w.Num),
                    wx = index % wight,
                    wy = index / wight;
                w.Pos = new Vector2((wx * w.SIZE) + w.SIZE / HALF + w.Grap.X,
                                    (wy * w.SIZE) + w.SIZE / HALF + w.Grap.Y);

                walls[i] = w;
            }

            return walls;
        }
    }
}
