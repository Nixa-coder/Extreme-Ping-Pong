using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Ping_Pong
{
    public class ShowCD
    {
        //  TEXTURE FOR PLAYERS
        //----------------------------------------------------------------------
        public Vector2 firepicpos = new Vector2(20, 400);
        public Texture2D fire = Raylib.LoadTexture("Fire.png");
       
        public Vector2 freezepicpos = new Vector2(85, 395);
        public Texture2D freeze = Raylib.LoadTexture("Freeze.png");

        public Vector2 barrierpicpos = new Vector2(157, 395);
        public Texture2D barrier = Raylib.LoadTexture("Barrier.png");

        public Vector2 turnaroundpicpos = new Vector2(225, 400);
        public Texture2D turnaround = Raylib.LoadTexture("TurnAround.png");
        //---------------------------------------------------------------------

        
        public void ShowCDP1(Reckets p1)
        {
            Raylib.SetTextureFilter(fire, TextureFilter.Point);
            Raylib.SetTextureFilter(freeze, TextureFilter.Point);
            Raylib.SetTextureFilter(barrier, TextureFilter.Point);
            Raylib.SetTextureFilter(turnaround, TextureFilter.Point);


            if (p1.cooldown <= 0)
            {
                Raylib.DrawTextureEx(fire, firepicpos, 0, 3f, Color.White);
            }
            else
            {
                Raylib.DrawTextureEx(fire, firepicpos, 0, 3f, Color.Gray);
                Raylib.DrawText($"{p1.cooldown:F1}", (int)firepicpos.X + 7, (int)firepicpos.Y + 9, 25, Color.White);
            }
            if (p1.cooldownFreeze <= 0)
            {
                Raylib.DrawTextureEx(freeze, freezepicpos, 0, 2.1f, Color.White);
            }
            else
            {
                Raylib.DrawTextureEx(freeze, freezepicpos, 0, 2.1f, Color.Gray);
                Raylib.DrawText($"{p1.cooldownFreeze:F1}", (int)freezepicpos.X + 8, (int)freezepicpos.Y + 13, 25, Color.White);
            }
            if (p1.cooldownBarrier <= 0)
            {
                Raylib.DrawTextureEx(barrier, barrierpicpos, 0, 2.1f, Color.White);
            }
            else
            {
                Raylib.DrawTextureEx(barrier, barrierpicpos, 0, 2.1f, Color.Gray);
                Raylib.DrawText($"{p1.cooldownBarrier:F1}", (int)barrierpicpos.X + 5, (int)barrierpicpos.Y + 11, 25, Color.White);
            }
            if (p1.cooldownTurn <= 0)
            {
                Raylib.DrawTextureEx(turnaround, turnaroundpicpos, 0, 2.1f, Color.White);
            }
            else
            {
                Raylib.DrawTextureEx(turnaround, turnaroundpicpos, 0, 2.1f, Color.Gray);
                Raylib.DrawText($"{p1.cooldownTurn:F1}", (int)turnaroundpicpos.X + 2, (int)turnaroundpicpos.Y + 6, 25, Color.White);
            }
        }

        public void ShowCDP2(Recket2 p2)
        {

        }
    }
}
