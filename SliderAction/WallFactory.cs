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
        { NUM, SPR, CR, ROT, BEND, GAPX, GAPY }

        //Sprite
        enum SizeTyep
        { WAY, END }
        static Texture2D[] spr;
        static public void Load(ContentManager c)
        {
            spr = new Texture2D[] { c.Load<Texture2D>("wall") /*,c.Load<Texture2D>("SmallMiddle")*/ };//***
        }
        //Rot C_ROT
        enum RotTyep
        { UP, RIGHT, DOWN, LEFT }
        static  readonly float[] rots = new float[] { 0, MathHelper.ToRadians(90), MathHelper.ToRadians(180), MathHelper.ToRadians(270) };
        //Cr
        enum CrTyep
        { RED, BLUE, ORANGE, YELLOW, GREEN }
        static readonly Color[] crs = new Color[] { Color.Red, Color.Blue, Color.Orange, Color.Yellow, Color.Green };


        static public List<Wall> WallsCreate(int sn)
        {
            const int FIX_ROW = 1;
            List<int[]> mapCsv = ReadCSV.Map(mapPaths[sn]);
            List<int[]> StatusCsv = ReadCSV.Status(statPaths[sn]); //csv読み込み結果を受け取り
            List<Wall> walls = new List<Wall>(); //壁

            for (int i = 0; i < mapCsv.Count; i++)
            {
                for (int j = 0; j < mapCsv[0].Length; j++) //ここで量産
                {
                    if (mapCsv[i][j] == 0) continue;

                    int me = mapCsv[i][j] - FIX_ROW;
                    WallVO wvo = new WallVO(                  //Factory → VO → wall(Interface) で値を入れる
                        spr[StatusCsv[me][(int)ColumnNum.SPR]],
                           new Vector2(j, i),
                           rots[StatusCsv[me][(int)ColumnNum.ROT]],
                           crs[StatusCsv[me][(int)ColumnNum.CR]],
                           new Vector2(StatusCsv[me][(int)ColumnNum.GAPX], StatusCsv[me][(int)ColumnNum.GAPY]),
                           Convert.ToBoolean(StatusCsv[me][(int)ColumnNum.BEND])
                        );

                    Wall w = new Wall(wvo);
                    walls.Add(w);
                }
            }
            return walls;
        }
    }
}
