using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading.Tasks;

namespace SliderAction
{
    class ReadyUI : UIBase
    {
        public enum Type
        {
            READY, GO, GOAL, OUT
        }

        int[] wait;
        Vector2 centerPos;
        public ReadyUI(ImageVo ivo,int winSize) : base(ivo)
        {
            uvo = new UIVO(new Texture2D[] { ivo.Ready, ivo.Go, ivo.Goal, ivo.Out },
                            new Vector2[] { new Vector2(504, 105), new Vector2(232, 94), new Vector2(480, 105), new Vector2(394, 105) });
            wait = new int[] { 100, 100, 100, 100 };
            centerPos = new Vector2(winSize/OtherValue.HALF, 500); //***
            uvo.drawF = OtherSystem.AllIn(uvo.drawF, false); //***
        }

        public bool Anime(int typeNum)
        {
            if (Animetion.SinpleAnimetion(ref wait[typeNum], ref uvo.drawF[typeNum]))
                return true;
            return false;
        }

        public override void Draw(SpriteBatch sb, Vector2 localDif)
        {
            for(int i = 0; i < uvo.drawF.Length; i++) 
            {
                if (!uvo.drawF[i]) continue;
                sb.Draw(uvo.textures[i], centerPos+localDif, null, Color.White, 0, uvo.localPos[i]/OtherValue.HALF,Vector2.One, SpriteEffects.None, 0);
            }
        }
    }
}