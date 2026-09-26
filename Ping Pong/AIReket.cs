using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ping_Pong
{
    public class AIReket
    {
        public float speed;
        public float x;
        public float y;
        public float timer;
        public int hit;
        public Texture2D reket = new Texture2D();
        public Rectangle HitPoint;

        public AIReket()
        {
            x = 800;
            y = 225;
            hit = 0;
            timer = 0f;
            speed = 350f;

            reket = Raylib.LoadTexture("Reket.png");
            HitPoint = new Rectangle(x, y, reket.Width, reket.Height);

        }


        public void DrawAI()
        {
            Color color = timer > 0 ? Color.Red : Color.White;
            Raylib.DrawTexture(reket, (int)x, (int)y, color);
        }

        public void Moving(Ball b, float deltaTime)
        {
            if(timer > 0)
            {
                timer -= deltaTime;

                y += 1;

                HitPoint.X = x;
                HitPoint.Y = y;
                return;
            }

            float reketCenterY = y + (reket.Height / 2f);
            float ballCenterY = b.y + (b.ball.Height / 2);
            if(ballCenterY < reketCenterY - 10)
            {
                y -= speed * deltaTime;
            }
            else if(ballCenterY > reketCenterY + 10)
            {
                y += speed * deltaTime;
            }

            HitPoint = new Rectangle(x, y, reket.Width, reket.Height);

            

        }


    }
}
