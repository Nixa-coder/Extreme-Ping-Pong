using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace Ping_Pong
{
    public class Points
    {
        public int Width;
        public int Height;

        public bool WentThrough = false;

        public int point1;
        public int point2;

        public Points()
        {
            point1 = 0;
            point2 = 0;

            Width = 900;
            Height = 450;
        }

        public void Point(Ball b, Reckets r, Recket2 r2, AIReket ai)
        {

            if (b.x < 0 && !WentThrough)
            {
                point2 += 1;
                WentThrough = true;
                Reset(b, r, r2, ai, 200f);
            }
            if (b.x > 900 && !WentThrough)
            {
                point1 += 1;
                WentThrough = true;
                Reset(b, r, r2, ai, -200f);
            }
            

        }


        public void DrawPoints()
        {
            Raylib.DrawText($"{point1} : {point2}", Width / 2 - 30, 0, 20, Color.White);
        }


        public void Reset(Ball b, Reckets r, Recket2 r2, AIReket ai, float newSpeed)
        {
            if (WentThrough)
            {
                b.x = 450;
                b.y = 225;

                r.x = 100;
                r.y = 225;

                r2.x = 800;
                r2.y = 225;

                ai.x = 800;
                ai.y = 225;

                b.speedX = -newSpeed;
                b.speedY = 200f;
                

                
                Raylib.WaitTime(0.5);

                WentThrough = false;
            }
        }
    }
}
