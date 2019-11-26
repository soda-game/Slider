using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;

namespace SliderAction
{
    class Result
    {
        public bool PushKey()
        {
            if (Input.DownKey(Keys.Space))
                return true;
            return false;
        }
    }
}
