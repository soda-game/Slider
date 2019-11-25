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
        static public readonly string[] mapPaths = new string[] { "CSV/map.csv" };
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
        //Rot
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
                    if (mapCsv[i][j] == 0 || mapCsv[i][j] >= 100) continue;

                    int mapE = mapCsv[i][j] - FIX_ROW;

                    Texture2D spr = sprs[StatusCsv[mapE][(int)ColumnNum.SPR]];
                    float rot = rots[StatusCsv[mapE][(int)ColumnNum.ROT]];
                    Color cr = crs[StatusCsv[mapE][(int)ColumnNum.CR]];
                    Vector2 gap = new Vector2(StatusCsv[mapE][(int)ColumnNum.GAPX], StatusCsv[mapE][(int)ColumnNum.GAPY]);
                    bool bend = Convert.ToBoolean(StatusCsv[mapE][(int)ColumnNum.BEND]);
                    Vector2 pos = PosAsk(j, i, 64, gap);
                    Vector2[] dp = DamagePosAsk(pos, 32);
                    List<Vector2[]> recoP = RecoverPos(j, i, dp, mapCsv, 30); //SIZE

                    WallVO wvo = new WallVO(spr, pos, dp, recoP, rot, cr, gap, bend);
                    Wall w = new Wall(wvo, sprs[StatusCsv[mapE][(int)ColumnNum.SPR]]);
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

        static List<Vector2[]> RecoverPos(int j, int i, Vector2[] dp, List<int[]> mapCsv, int RecoSize)
        {
            int[,] afIndexs = { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } };
            List<Vector2[]> recoPos = new List<Vector2[]>();

            for (int n = 0; n < rots.Length; n++)
            {
                //隣が床か
                int jAfIndex, iAfIndex; //配列内か

                if (j + afIndexs[n, 0] < mapCsv[0].Length) jAfIndex = j + afIndexs[n, 0];
                else jAfIndex = 0;
                if (i + afIndexs[n, 1] < mapCsv.Count) iAfIndex = i + afIndexs[n, 1];
                else iAfIndex = 0;

                int afE = mapCsv[iAfIndex][jAfIndex];
                if (afE < 100) continue;

                //床なら方向ごとにRecoPを格納
                Vector2 ul; Vector2 dr;
                Vector2[] sqr;//***
                switch (n)
                {
                    case (int)RotTyep.UP:
                        ul = new Vector2(dp[(int)Square.UP_LEFT].X, dp[(int)Square.UP_LEFT].Y - RecoSize);
                        dr = new Vector2(dp[(int)Square.DOWN_RIGHT].X, dp[(int)Square.UP_LEFT].Y);
                        sqr = new Vector2[] { ul, dr };
                        recoPos.Add(sqr);
                        break;
                    case (int)RotTyep.RIGHT:
                        ul = new Vector2(dp[(int)Square.DOWN_RIGHT].X, dp[(int)Square.UP_LEFT].Y);
                        dr = new Vector2(dp[(int)Square.DOWN_RIGHT].X + RecoSize, dp[(int)Square.DOWN_RIGHT].Y);
                        sqr = new Vector2[] { ul, dr };
                        recoPos.Add(sqr);
                        break;
                    case (int)RotTyep.DOWN:
                        ul = new Vector2(dp[(int)Square.UP_LEFT].X, dp[(int)Square.DOWN_RIGHT].Y);
                        dr = new Vector2(dp[(int)Square.DOWN_RIGHT].X, dp[(int)Square.DOWN_RIGHT].Y + RecoSize);
                        sqr = new Vector2[] { ul, dr };
                        recoPos.Add(sqr);
                        break;
                    case (int)RotTyep.LEFT:
                        ul = new Vector2(dp[(int)Square.UP_LEFT].X - RecoSize, dp[(int)Square.UP_LEFT].Y);
                        dr = new Vector2(dp[(int)Square.UP_LEFT].X, dp[(int)Square.DOWN_RIGHT].Y);
                        sqr = new Vector2[] { ul, dr };
                        recoPos.Add(sqr);
                        break;
                }
            }

            return recoPos;
        }
    }
}

