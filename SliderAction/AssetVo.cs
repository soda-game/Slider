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
        public Texture2D Player { get; }
        public Texture2D CroosWall { get; }
        public Texture2D Reco { get; }
        public Texture2D Floor { get; }

        public AssetVo(ContentManager c)
        {
            Title = c.Load<Texture2D>("Title");
            HpBar = c.Load<Texture2D>("HpBar");
            Tutorial = c.Load<Texture2D>("tuto");
            Result = c.Load<Texture2D>("Result");
            Player = c.Load<Texture2D>("Player");
            CroosWall = c.Load<Texture2D>("crossWall");
            Reco = c.Load<Texture2D>("Reco");
            Floor = c.Load<Texture2D>("Floor");
        }
    }
}
