using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SliderAction
{
    static class OtherSystem
    {
        //両辺を同じ値で計算
        static public Vector2 Vec2PulMin(Vector2 vec2, float value)
        {
            vec2 += new Vector2(value, value);
            return vec2;
        }
        static public Vector2 Vec2Mul(Vector2 vec2, float value)
        {
            vec2 *= new Vector2(value, value);
            return vec2;
        }
        static public Vector2 Vec2SidesDiv(Vector2 vec2, float value)
        {
            vec2 /= new Vector2(value, value);
            return vec2;
        }

        //待機処理
        static async void WaitAction(Action[] actions, int milli)
        {
            await Task.Delay(milli);
            foreach (Action a in actions) a();
        }
        static async void WaitActions(Action[] actions, int milli)
        {
            foreach (Action a in actions)
            {
                await Task.Delay(milli);
                a();
            }
            //for (int i = 0; i < actions.Length; i++)
            //{
            //    await Task.Delay(milli);
            //    actions[i]();
            //}
        }
        static async void WaitActions(Action[] actions, int[] milli)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                await Task.Delay(milli[i]);
                actions[i]();
            }
        }

        //フラグ切り替え
        static public bool BoolChenge(bool flag)
        {
            if (flag) flag = false;
            else flag = true;

            return flag;
        }

        //配列すべてに 同じ値を入れる
        static public bool[] AllIn(bool[] @base, bool chenge)
        {
            for (int i = 0; i < @base.Length; i++)
                @base[i] = chenge;
            return @base;
        }
    }
}
