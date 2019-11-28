using Microsoft.Xna.Framework.Input;

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
            bool down = false;

            //そもそもキーが押されていない
            if (!Keyboard.GetState().IsKeyDown(key))
            {
                statNum = InputStat.NONE;
                return down;
            }

            //キーが押されている
            switch (statNum)
            {
                case InputStat.NONE:
                    statNum = InputStat.FARST;
                    down = true;
                    break;
                case InputStat.FARST:
                    statNum = InputStat.CONT;
                    break;
            }
            return down;

        }
    }
}
