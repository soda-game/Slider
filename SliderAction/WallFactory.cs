using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Diagnostics;

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
        { WAY, END, CROSS }
        static Texture2D[] sprs;
        static public void Load(ContentManager c)
        {
            sprs = new Texture2D[] { c.Load<Texture2D>("wall") /*,c.Load<Texture2D>("SmallMiddle")*/ };//***
        }
        //Rot C_ROT
        enum RotTyep
        { UP, RIGHT, DOWN, LEFT }
        static readonly float[] rots = new float[] { 0, MathHelper.ToRadians(90), MathHelper.ToRadians(180), MathHelper.ToRadians(270) };
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

                    int mapE = mapCsv[i][j] - FIX_ROW;

                    Texture2D spr = sprs[StatusCsv[mapE][(int)ColumnNum.SPR]];
                    float rot = rots[StatusCsv[mapE][(int)ColumnNum.ROT]];
                    Color cr = crs[StatusCsv[mapE][(int)ColumnNum.CR]];
                    Vector2 gap = new Vector2(StatusCsv[mapE][(int)ColumnNum.GAPX], StatusCsv[mapE][(int)ColumnNum.GAPY]);
                    bool bend = Convert.ToBoolean(StatusCsv[mapE][(int)ColumnNum.BEND]);
                    Vector2 pos = PosAsk(j, i, 64, gap);
                    Vector2[] dp = DamagePosAsk(pos, 32);

                    if (j == 9 && i == 16)
                    { Debug.WriteLine("p:" + pos + " D:" + dp); }

                    WallVO wvo = new WallVO(spr, pos, dp, rot, cr, gap, bend);
                    Wall w = new Wall(wvo);
                    walls.Add(w);
                }
            }
            return walls;
        }

        public enum Square
        { UP_LEFT, DOWN_RIGHT }
        static Vector2 PosAsk(int x, int y, int size, Vector2 gap)
        {
            return new Vector2((x * size) + gap.X, (y * size) + gap.Y);
        }

        static Vector2[] DamagePosAsk(Vector2 pos, int hsize) //当たり判定の矩形を配列に
        {
            Vector2[] dp = new Vector2[2];
            dp[(int)Square.UP_LEFT] = new Vector2(pos.X - hsize, pos.Y - hsize);
            dp[(int)Square.DOWN_RIGHT] = new Vector2(pos.X + hsize, pos.Y + hsize);

            return dp;
        }
        //void RecoverPos(Vector2 bPos, Vector2 oPos,List<int[]> mapCsv)
        //{
        //    bool[] setWall = new bool[4];//Up Right Down Left

        //   if(mapCsv[((int)bPos.X)-1][((int)bPos.Y) - 1] != 0)
        //    {
        //        setWall [0] = true;
        //    }

        //    int tCount = setWall.Count(n => n == true);
        //    Vector2[][] rPos = new Vector2[tCount][];

        //    int rpIndex = 0;
        //    for (int i = 0; i < setWall.Length; i++)
        //    {
        //        if (!setWall[i]) continue;

        //        rPos[rpIndex][0] = new Vector2(3, 3);
        //        rPos[rpIndex][1] = new Vector2(3, 3);

        //        rpIndex++;
        //    }

 
    }
}

