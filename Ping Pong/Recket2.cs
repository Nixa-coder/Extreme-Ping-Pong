using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ping_Pong
{
    public class Recket2
    {
        public float speed = 350f;
        public float x;
        public float y;


        public Texture2D Reket;
        public Rectangle r;


        public Recket2()
        {
            x = 800;
            y = 225;


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
    }
}


