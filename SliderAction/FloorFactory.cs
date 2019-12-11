using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace SliderAction
{
    class FloorFactory
    {
        //CSV
        static readonly string[] statPash = { "CSV/floorS.csv" };

        enum ColumnNum
        { NUM, SPR, BEND, B_ROT }
        //Spr
        static Texture2D[] sprs;

        static public List<Floor> CriateFloor(int sn, ImageVo ivo)
        {
            sprs = new Texture2D[] { ivo.Floor };

            List<int[]> mapCsv = ReadCSV.Map(WallFactory.mapPaths[sn]);
            List<int[]> statCsv = ReadCSV.Status(statPash[sn]);
            List<Floor> floors = new List<Floor>();

            for (int i = 0; i < mapCsv.Count; i++)
            {
                for (int j = 0; j < mapCsv[0].Length; j++) //ここで量産
                {
                    if (mapCsv[i][j] <= 100) continue;
                    int mapE = mapCsv[i][j] - 101;

                    int num = statCsv[mapE][(int)ColumnNum.NUM];
                    Texture2D spr = sprs[statCsv[mapE][(int)ColumnNum.SPR]];
                    int[] index = { j, i };
                    Vector2 pos = PosAsk(j, i, 64, new Vector2(0, 0));
                    int bend = statCsv[mapE][(int)ColumnNum.BEND];
                    int bRot = statCsv[mapE][(int)ColumnNum.B_ROT];
                    Vector2[] cPos = ColliPosAsk(pos, 32);

                    FloorVO fvo = new FloorVO(num, index, spr, pos, cPos, bend, bRot);
                    Floor floor = new Floor(fvo);
                    floors.Add(floor);
                }
            }

            return floors;

        }
        static Vector2 PosAsk(int x, int y, int size, Vector2 gap)
        {
            return new Vector2((x * size) + gap.X, (y * size) + gap.Y);
        }
        static Vector2[] ColliPosAsk(Vector2 pos, int hsize) //当たり判定の矩形を配列に
        {
            Vector2[] dp = new Vector2[Enum.GetNames(typeof(OtherValue.Square)).Length];
            dp[(int)OtherValue.Square.UP_LEFT] = new Vector2(pos.X - hsize, pos.Y - hsize);
            dp[(int)OtherValue.Square.DOWN_RIGHT] = new Vector2(pos.X + hsize, pos.Y + hsize);

            return dp;
        }

        //bend //別クラス***
        enum BendType
        { NONE, START, END }
        enum IndecType { X, Y }

        public struct BendSqr
        {
            public Vector2[] pos;
            public int rot;
            public bool end;
        }
        static public List<BendSqr> BendPosAsk(List<Floor> floors)
        {
            List<BendSqr> bends = new List<BendSqr>();

            //開始位置を探し、その左上を格納
            foreach (var f in floors)
                if (f.Bend == (int)BendType.START)
                {
                    Vector2 ul = f.ColliPos[(int)OtherValue.Square.UP_LEFT];
                    int rot = f.B_Rot - 1; //0=なし

                    Vector2 dr = Vector2.Zero;

                    //隣がどこまでつながっているか
                    foreach (var fx in floors)
                        if (fx.Index[(int)IndecType.X] >= f.Index[(int)IndecType.X] && fx.Index[(int)IndecType.Y] == f.Index[(int)IndecType.Y])
                        {
                            if (fx.Bend == (int)BendType.END)
                            {
                                dr.X = fx.ColliPos[(int)OtherValue.Square.DOWN_RIGHT].X;
                                break;
                            }
                        }
                    //下がどこまでつながってるか
                    foreach (var fy in floors)
                        if (fy.Index[(int)IndecType.X] == f.Index[(int)IndecType.X] && fy.Index[(int)IndecType.Y] >= f.Index[(int)IndecType.Y])
                        {
                            if (fy.Bend == (int)BendType.END)
                            {
                                dr.Y = fy.ColliPos[(int)OtherValue.Square.DOWN_RIGHT].Y;
                                break;
                            }
                        }

                    //合わせる
                    Vector2[] spuare = { ul, dr };
                    BendSqr bs = new BendSqr { pos = spuare, rot = rot, end = false };
                    bends.Add(bs);
                }

            return bends;
        }

        static public BendSqr BendChenge(BendSqr bend)
        {
            bend.end = true;
            return bend;
        }
    }
}
