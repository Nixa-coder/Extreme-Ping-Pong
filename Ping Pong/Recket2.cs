using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Ping_Pong
{
    public class Recket2 : IPowers
    {
        public float speed = 350f;
        public float x;
        public float y;
        public float cooldownFirep2;
        public float cooldownFreezep2;
        public float cooldownBarrierp2;
        public float timerFirep2;
        public float timerFreezep2;
        public float timerBarrierp2;


        public Texture2D Reket;
        public Rectangle r;


        public Recket2()
        {
            x = 800;
            y = 225;
            cooldownBarrierp2 = 0;
            cooldownFirep2 = 0;
            cooldownFreezep2 = 0;

            Reket = Raylib.LoadTexture("Reket.png");
            r = new Rectangle(x, y, Reket.Width, Reket.Height);

        }


        public void Draw()
        {
            Raylib.DrawTexture(Reket, (int)x, (int)y, Color.White);
        }

        public void Move(float deltaTime)
        {


            if (Raylib.IsKeyDown(KeyboardKey.Up))
            {
                y -= speed * deltaTime;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.Down))
            {
                y += speed * deltaTime;
            }

            r.X = x;
            r.Y = y;

        }
        public void FireBall(Ball b, float deltaTime)
        {
            if (cooldownFirep2 > 0)
            {
                cooldownFirep2 -= deltaTime;
            }

            if (timerFirep2 > 0)
            {
                timerFirep2 -= deltaTime;

                if (timerFirep2 <= 0)
                {
                    b.speedX /= 2;
                    b.speedY /= 2;


                    b.color = Color.Yellow;
                }
            }


            if (Raylib.IsKeyPressed(KeyboardKey.Left) && timerFirep2 <= 0 && cooldownFirep2 <= 0 && timerFreezep2 <= 0)
            {
                b.speedX *= 2;
                b.color = Color.Red;
                timerFirep2 = 2.0f;
                cooldownFreezep2 = 5;
            }
        }
        public void FreezeBall(Ball b, float deltaTime)
        {
            if (cooldownFreezep2 > 0)
            {
                cooldownFreezep2 -= deltaTime;
            }

            if (timerFreezep2 > 0)
            {
                timerFreezep2 -= deltaTime;
                if (timerFreezep2 <= 0)
                {
                    b.speedX = b.oldSpeedX;
                    b.speedY = b.oldSpeedY;
                    b.color = Color.Yellow;
                }

            }

            if (Raylib.IsKeyPressed(KeyboardKey.Right) && timerFreezep2 <= 0 && cooldownFreezep2 <= 0 && timerFirep2 <= 0)
            {
                b.oldSpeedX = b.speedX;
                b.oldSpeedY = b.speedY;

                b.speedX = 0;
                b.speedY = 0;

                timerFreezep2 = 2.0f;
                cooldownFreezep2 = 5;

                b.color = Color.Blue;
            }
        }

        public void Barrier(Ball b, float deltaTime)
        {
            if (cooldownBarrierp2 > 0)
            {
                cooldownBarrierp2 -= deltaTime;
            }

            if (timerBarrierp2 > 0)
            {
                timerBarrierp2 -= deltaTime;

                Rectangle barrier = new Rectangle(860, 0, 20, 450);
                bool Shield = Raylib.CheckCollisionCircleRec(b.center, b.radius, barrier);

                if (Shield)
                {
                    b.speedX = -b.speedX;
                }
            }


            if (Raylib.IsKeyPressed(KeyboardKey.RightShift) && timerBarrierp2 <= 0 && cooldownBarrierp2 <= 0)
            {
                timerBarrierp2 = 3.0f;
                cooldownBarrierp2 = 10.0f;
            }
        }

        public void DrawBarrier()
        {
            if (timerBarrierp2 > 0)
            {
                Raylib.DrawRectangle(860, 0, 20, 450, Color.Violet);
            }

        }
    }
}


