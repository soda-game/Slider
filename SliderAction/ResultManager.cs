﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace SliderAction
{
    class ResultManager : IManager
    {
        ResultUI resultUI;

        public ResultManager(ImageVo ivo)
        {
            resultUI = new ResultUI(ivo);
        }

        public int Main()
        {
            if (Input.DownKey(Keys.Space))
                return (int)OtherValue.MainTyep.NEXT;
            return (int)OtherValue.MainTyep.NONE;
        }

        public void Draw(SpriteBatch sb, Vector2 localDif)
        {
            resultUI.Draw(sb, localDif);
        }
    }
}
