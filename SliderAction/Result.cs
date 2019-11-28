using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SliderAction
{
    class Result
    {
        Texture2D result;
        readonly Vector2 pos = Vector2.Zero;

        public void Load(ContentManager c)
        { result = c.Load<Texture2D>("Result"); }
        public Result()
        { }

        public bool PushKey()
        {
            if (Input.DownKey(Keys.Space))
                return true;
            return false;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(result, pos, Color.White);
        }
    }
}
