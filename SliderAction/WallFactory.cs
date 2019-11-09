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
        static readonly string[] mapPaths = new string[] { "CSV/map.csv" };
        static readonly string[] statPaths = new string[] { "CSV/status.csv" };
        enum ColumnNum
        { NUM, SPR, CR, ROT, C_ROT, BEND, GAPX, GAPY }

        //Sprite
        enum SizeTyep
        { WAY, END }
        static Texture2D[] spr;
        //Rot C_ROT
        enum RotTyep
        { UP, RIGHT, DOWN, LEFT }
        static readonly float[] rots = new float[] { 0, MathHelper.ToRadians(90), MathHelper.ToRadians(180), MathHelper.ToRadians(270) };
        //Cr
        enum CrTyep
        { RED, BLUE, ORANGE, YELLOW, GREEN }
        static readonly Color[] crs = new Color[] { Color.Red, Color.Blue, Color.Orange, Color.Yellow, Color.Green };


        static public void Load(ContentManager c)
        {
            spr = new Texture2D[] { c.Load<Texture2D>("wall") /*,c.Load<Texture2D>("SmallMiddle")*/ };//***
        }

        static public List<Wall> WallsCreate(int sn)
        {
            List<int> mapCsv = ReadCSV.Map(mapPaths[sn]);
            List<int[]> StatusCsv = ReadCSV.Status(statPaths[sn]); //csv読み込み結果を受け取り
            List<Wall> walls = new List<Wall>(); //壁

            int wight = mapCsv[WHITS_IDX]; //１要素目はwightが入っている
            mapCsv.RemoveAt(WHITS_IDX); //使ったら消す

            for (int i = 0; i < mapCsv.Count; i++) //ここで量産
            {
                if (mapCsv[i] == 0) continue;

                Wall w = new Wall();
                int me = mapCsv[i] - 1; //***
                w.Spr = spr[StatusCsv[me][(int)ColumnNum.SPR]];
                w.Cr = crs[StatusCsv[me][(int)ColumnNum.CR]];
                w.Grap = new Vector2(StatusCsv[me][(int)ColumnNum.GAPX], StatusCsv[me][(int)ColumnNum.GAPY]);
                w.Rot = rots[StatusCsv[me][(int)ColumnNum.ROT]];
                w.C_Rot = StatusCsv[me][(int)ColumnNum.C_ROT];
                w.Bend = Convert.ToBoolean(StatusCsv[me][(int)ColumnNum.BEND]); //intをbool変換

                //mapCsvから自分の番号の座標を抜き出しす
                int wx = i % wight,
                    wy = i / wight;
                w.PosBase = new Vector2(wx, wy);

                walls.Add(w);
            }

            return walls;
        }
    }
}
