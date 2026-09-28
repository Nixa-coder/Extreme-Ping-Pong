using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ping_Pong
{

    
    public class Collisions
    {
        
        public void Collision(Reckets r, Ball b, Recket2 r2, AIReket ai, bool isbot)
        {
            
            r.r = new Rectangle(r.x, r.y, r.Reket.Width, r.Reket.Height);
            float halfball = b.ball.Width / 2f;
            b.center = new System.Numerics.Vector2(b.x + halfball, b.y + halfball);

            bool CollReck = Raylib.CheckCollisionCircleRec(b.center, b.radius, r.r);
            if (r.y <= 0)
            {
                r.y = 0;
            }
            if (r.y + r.Reket.Height >= 450)
            {
                r.y = 450 - r.Reket.Height;
            }
            if (CollReck && b.speedX > 0)
            {
                b.speedX = -b.speedX;
                b.x = r.x + r.Reket.Width + 1;
                b.speedX += 10;

                float centerp1 = r.y + (r.Reket.Height / 2);
                float offset = (b.y + (b.ball.Height / 2)) - centerp1;

                float hit = offset / (r.Reket.Height / 2);

                b.speedY = -hit * b.speed;
                

                
            }




            if (isbot)
            {
                ai.HitPoint = new Rectangle(ai.x, ai.y, ai.reket.Width, ai.reket.Height);
                bool CollReckAI = Raylib.CheckCollisionCircleRec(b.center, b.radius, ai.HitPoint);

                if (ai.y <= 0)
                {
                    ai.y = 0;
                }
                if (ai.y + ai.reket.Height >= 450)
                {
                    ai.y = 450 - ai.reket.Height;
                }

                if (CollReckAI && b.speedX < 0)
                {
                    ai.hit += 1;
                    b.speedX -= 10f;

                    if (b.speedY >= 0)
                    {
                        b.speedY += 10f;
                    }
                    else
                    {
                        b.speedY -= 10f;
                    }

                    b.speedX = -b.speedX;
                    b.x = ai.x - b.ball.Width - 1;

                    if (ai.hit >= 3)
                    {
                        ai.timer = 3.0f;
                        ai.hit = 0;
                    }
                }

            }
            else
            {
                r2.r = new Rectangle(r2.x, r2.y, r2.Reket.Width, r2.Reket.Height);
                bool CollReckR = Raylib.CheckCollisionCircleRec(b.center, b.radius, r2.r);

                if (r2.y <= 0)
                {
                    r2.y = 0;
                }
                if (r2.y + r2.Reket.Height >= 450)
                {
                    r2.y = 450 - r2.Reket.Height;
                }
                if (CollReckR && b.speedX < 0)
                {
                    b.speedX = -b.speedX;
                    b.x = r2.x - b.ball.Width - 1;
                    b.speedX += 10;

                    float centerp2 = r2.y + (r2.Reket.Height / 2);
                    float offset = (b.y + (b.ball.Height / 2)) - centerp2;

                    float hit = offset / (r2.Reket.Height / 2);

                    b.speedY = hit * b.speed;
                }
            }
        }
    }
}
