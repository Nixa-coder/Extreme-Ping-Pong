using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace Ping_Pong
{
    public class Reckets : IPowers
    {

        public float speed = 350f;
        public float x;
        public float y;
        public float timer;
        public float timerFreeze;
        public float timerBarrier;
        public float cooldown;
        public float cooldownFreeze;
        public float cooldownBarrier;

        public Texture2D Reket;
        public Rectangle r;


        public Reckets()
        {
            x = 100;
            y = 225;
            timerFreeze = 0;
            cooldown = 0;
            cooldownFreeze = 0;


            Reket = Raylib.LoadTexture("Reket.png");
            r = new Rectangle(x, y, Reket.Width, Reket.Height);

        }


        public void Draw()
        {
            Raylib.DrawTexture(Reket, (int)x, (int)y, Color.White);
        }

        public void Move(float deltaTime)
        {


            if (Raylib.IsKeyDown(KeyboardKey.W))
            {
                y -= speed * deltaTime;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.S))
            {
                y += speed * deltaTime;
            }

            r.X = x;
            r.Y = y;

        }

        public void FireBall(Ball b, float deltaTime, Recket2 re, Reckets r)
        {
            if (cooldown > 0)
            {
                cooldown -= deltaTime;
            }

            if (timer > 0)
            {
                timer -= deltaTime;

                if (timer <= 0)
                {
                    b.speedX /= 2;
                    b.speedY /= 2;


                    b.color = Color.Yellow;
                }
            }


            if (Raylib.IsKeyPressed(KeyboardKey.E) && timer <= 0 && cooldown <= 0 && timerFreeze <= 0 && re.timerFreezep2 <= 0 && re.timerFirep2 <= 0)
            {
                b.speedX *= 2;
                b.color = Color.Red;
                timer = 2.0f;
                cooldown = 5;
            }
        }

        public void FreezeBall(Ball b, float deltaTime, Recket2 re, Reckets r)
        {
            if (cooldownFreeze > 0)
            {
                cooldownFreeze -= deltaTime;
            }

            if (timerFreeze > 0)
            {
                timerFreeze -= deltaTime;
                if (timerFreeze <= 0)
                {
                    b.speedX = b.oldSpeedX;
                    b.speedY = b.oldSpeedY;
                    b.color = Color.Yellow;
                }

            }

            if (Raylib.IsKeyPressed(KeyboardKey.Q) && timerFreeze <= 0 && cooldownFreeze <= 0 && timer <= 0 && re.timerFirep2 <= 0 && re.timerFreezep2 <= 0)
            {
                b.oldSpeedX = b.speedX;
                b.oldSpeedY = b.speedY;

                b.speedX = 0;
                b.speedY = 0;

                timerFreeze = 2.0f;
                cooldownFreeze = 5;

                b.color = Color.Blue;
            }
        }

        public void Barrier(Ball b, float deltaTime)
        {
            if (cooldownBarrier > 0)
            {
                cooldownBarrier -= deltaTime;
            }

            if (timerBarrier > 0)
            {
                timerBarrier -= deltaTime;

                Rectangle barrier = new Rectangle(20, 0, 20, 450);
                bool Shield = Raylib.CheckCollisionCircleRec(b.center, b.radius, barrier);

                if (Shield)
                {
                    b.speedX = -b.speedX;
                }
            }


            if (Raylib.IsKeyPressed(KeyboardKey.R) && timerBarrier <= 0 && cooldownBarrier <= 0)
            {
                timerBarrier = 3.0f;
                cooldownBarrier = 10.0f;
            }
        }

        public void DrawBarrier()
        {
            if (timerBarrier > 0)
            {
                Raylib.DrawRectangle(20, 0, 20, 450, Color.White);
            }

        }

    }
}

