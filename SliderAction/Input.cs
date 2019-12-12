using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace SliderAction
{
    class Input
    {
        enum InputStat
        {
            NONE,
            FARST,
            CONT
        }
        static InputStat statNum = InputStat.NONE;

        static public bool DownKey(Keys key)
        {
            //そもそもキーが押されていない
            if (!Keyboard.GetState().IsKeyDown(key))
            {
                statNum = InputStat.NONE;
                return false;
            }

            bool test = false;
            //キーが押されている
            switch (statNum)
            {
                case InputStat.NONE:
                    statNum = InputStat.FARST;
                    test = true;
                    break;
                case InputStat.FARST:
                    statNum = InputStat.CONT;
                    break;
            }

            return test;

        }
    }
}
