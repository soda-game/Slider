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
    class Camera
    {
        const int HALF = 2;
        int w, h, wh, hh;

        Rectangle viewArea;
        float rot;
        Vector2 zoom;
        Vector2 origin;


        public Camera(int w, int h)
        {
            this.w = w;
            this.h = h;
            this.wh = w / HALF;
            this.hh = h / HALF;

            viewArea = new Rectangle(0, 0, w, h);
            rot = 0.0f;
            zoom = Vector2.One;
            origin = new Vector2(w / HALF, h / HALF);
        }

        public void Move(Vector2 pPos)
        {
            viewArea.X = (int)pPos.X - wh;
            viewArea.Y = (int)pPos.Y - hh;
        }

        public Matrix GetMatrix()
        {
            Vector3 viewPosV3 = new Vector3(viewArea.X, viewArea.Y, 0);
            Vector3 originV3 = new Vector3(origin, 0.0f);

            return Matrix.CreateTranslation(-viewPosV3) *
                   Matrix.CreateScale(zoom.X, zoom.Y, 1.0f) *
                   Matrix.CreateRotationZ(rot) *
                   Matrix.CreateTranslation(originV3);
        }

    }
}
