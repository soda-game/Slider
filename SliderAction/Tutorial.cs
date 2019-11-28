using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SliderAction
{
    class Tutorial
    {
        Texture2D tuto;
        readonly Vector2 pos =new Vector2(0,-50);

        public void Load(ContentManager c)
        { tuto = c.Load<Texture2D>("tuto"); }

        public bool PushKey()
        {
            if (Input.DownKey(Keys.Space))
                return true;
            return false;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tuto, pos, Color.White);
        }
    }
}
