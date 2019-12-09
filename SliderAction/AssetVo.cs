using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SliderAction
{
    struct AssetVo //***
    {
        public Texture2D Title { get; }
        public Texture2D HpBar { get; }
        public Texture2D Tutorial { get; }
        public Texture2D Result { get; }

        public AssetVo(ContentManager c)
        {
            Title = c.Load<Texture2D>("Title");
            HpBar = c.Load<Texture2D>("HpBar");
            Tutorial = c.Load<Texture2D>("tuto");
            Result = c.Load<Texture2D>("Result");
        }
    }
}
