﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SliderAction
{
    class PlayerFactory
    {
        //ステータス
        enum ColumnNum
        { Chara, POSX, POSY, SPEED, ROT, POS_FIX }

        //Sprite
        enum SpriteType
        {
            Player01
        }
        static Texture2D[] spr;
        static public void Load(ContentManager c)
        {
            spr = new Texture2D[] { c.Load<Texture2D>("Player") };
        }

        //InitRot
        enum RotTyep
        { UP, RIGHT, DOWN, LEFT }
        static readonly float[] rots = new float[] { 0, MathHelper.ToRadians(90), MathHelper.ToRadians(180), MathHelper.ToRadians(270) };

        static public Player PlayerCreate(int sn)
        {
            int[] stat = ReadCSV.Status("CSV/playerS.csv", sn + 1);

            int cNum = stat[(int)ColumnNum.Chara];
            Vector2 basePos = new Vector2(stat[(int)ColumnNum.POSX], stat[(int)ColumnNum.POSY]);
            Vector2 iPos = PosAsk(basePos, Convert.ToBoolean(stat[(int)ColumnNum.POS_FIX]),new Vector2(64,100), 32);//SIZE***
            float speed = stat[(int)ColumnNum.SPEED] / 10;
            float rot = rots[stat[(int)ColumnNum.ROT]];

            PlayerVO pvo = new PlayerVO(cNum, spr, iPos, speed, rot);

            Player player = new Player(pvo);
            return player;
        }

        static Vector2 PosAsk(Vector2 bPos, bool pFix, Vector2 size, int sizeH)
        {
            Vector2 pos;

             pos = new Vector2(bPos.X * size.X, bPos.Y * size.Y);
            if(pFix)
                pos = new Vector2(bPos.X + sizeH, bPos.Y + sizeH);

            return pos;

        }
    }
}
