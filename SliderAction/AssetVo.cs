using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace SliderAction
{
    struct ImageVo
    {
        public Texture2D Title { get; }
        public Texture2D HpBar { get; }
        public Texture2D Tutorial { get; }
        public Texture2D Result { get; }
        public Texture2D Player { get; }
        public Texture2D CroosWall { get; }
        public Texture2D Reco { get; }
        public Texture2D Floor { get; }
        public Texture2D Goal { get; }
        public Texture2D Out { get; }
        public Texture2D Ready { get; }
        public Texture2D Go { get; }

        public ImageVo(ContentManager c)//***一枚にする
        {
            Title = c.Load<Texture2D>("Title");
            HpBar = c.Load<Texture2D>("HpBar");
            Tutorial = c.Load<Texture2D>("tuto");
            Result = c.Load<Texture2D>("Result");
            Player = c.Load<Texture2D>("Player");
            CroosWall = c.Load<Texture2D>("crossWall");
            Reco = c.Load<Texture2D>("Reco");
            Floor = c.Load<Texture2D>("Floor");
            Goal = c.Load<Texture2D>("goal");
            Out = c.Load<Texture2D>("out");
            Ready = c.Load<Texture2D>("ready");
           Go = c.Load<Texture2D>("go");
        }
    }

    struct SoundVo
    {
        public Song Bgm { get; }
        public SoundEffect Reco { get; }

        public SoundVo(ContentManager c)
        {
            Bgm = c.Load<Song>("BGM");
            Reco = c.Load<SoundEffect>("recover");
        }
    }
}
