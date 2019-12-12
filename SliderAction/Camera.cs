using Microsoft.Xna.Framework;

namespace SliderAction
{
    class Camera
    {
        const int HALF = 2;
        int w, h, wh, hh;

        Rectangle viewArea;
        public Vector2 localDiff => new Vector2(viewArea.X,viewArea.Y); 
        Vector3 viewOrigin;

       public Vector2 posOrigin; //***
        float rot;
        Vector2 zoom;


        public Camera(int w, int h)
        {
            this.w = w;
            this.h = h;
            this.wh = w / HALF;
            this.hh = h / HALF;

            viewArea = new Rectangle(0, 0, w, h); //オブジェクトが写っているかを確認するため
            viewOrigin = new Vector3(wh, hh, 0.0f);

            posOrigin = new Vector2(wh, hh);
            rot = 0.0f;
            zoom = Vector2.One;
        }

        public void Move(Vector2 pPos)
        {
            posOrigin = new Vector2(pPos.X, pPos.Y);
            viewArea.X = (int)posOrigin.X -wh;
            viewArea.Y = (int)posOrigin.Y - hh;
        }

        public Matrix GetMatrix()
        {
            Vector3 posV3 = new Vector3(posOrigin, 0.0f);

            return Matrix.CreateTranslation(-posV3) *
                   Matrix.CreateScale(zoom.X, zoom.Y, 1.0f) *
                   Matrix.CreateRotationZ(rot) *
                   Matrix.CreateTranslation(viewOrigin);
        }

    }
}
