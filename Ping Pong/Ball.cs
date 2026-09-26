using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Ping_Pong
{
    public class Ball
    {
        public float x;
        public float y;
        public float speedX;
        public float speedY;

        public Texture2D ball;
        public float radius;

        public Vector2 center;
        public Ball()
        {
            x = 450;
            y = 225;
            speedX = 200f;
            speedY = 200f;
            ball = Raylib.LoadTexture("Ball.png");
            radius = ball.Width / 2f;

        }
        public void Draw()
        {
            Raylib.DrawTexture(ball, (int)x, (int)y, Color.Yellow);
        }


        public void Moving(float deltaTime)
        {
            x -= speedX * deltaTime;
            y -= speedY * deltaTime;


            radius = ball.Width / 2f;
            center = new Vector2(x + radius, y + radius);

            if (y <= 0)
            {
                y = 0;
                speedY = -speedY;
            }

            if (y + ball.Height >= 450)
            {
                y = 450 - ball.Height;
                speedY = -speedY;
            }
            


        }

        
    }
}
