using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
namespace SliderAction
{
    class Title
    {
        Texture2D title;
        readonly Vector2 pos = Vector2.Zero;

        public void Load(ContentManager c)
        { title = c.Load<Texture2D>("Title"); }
        public Title()
        { }

        //public bool Main() ***
        //{ }
        public bool PushKey()
        {
            if (Input.DownKey(Keys.Space))
                return true;
            return false;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(title, pos, Color.White);
        }
    }
}
