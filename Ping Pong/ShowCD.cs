using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Ping_Pong
{
    public class ShowCD
    {
        //  VECTOR FOR P1 ABILITIES
        //----------------------------------------------------------------------
        public Vector2 firepicpos = new Vector2(20, 400);
        public Vector2 freezepicpos = new Vector2(85, 395);
        public Vector2 barrierpicpos = new Vector2(157, 395);
        public Vector2 turnaroundpicpos = new Vector2(225, 400);
        //---------------------------------------------------------------------

        // VECTOR FOR P2 ABILITIES
        //-----------------------------------------------------------------------
        public Vector2 firepicpos2 = new Vector2(835, 400);
        public Vector2 freezepicpos2 = new Vector2(770, 395);
        public Vector2 barrierpicpos2 = new Vector2(703, 395);
        public Vector2 turnaroundpicpos2 = new Vector2(640, 400);
        //----------------------------------------------------------------------

        public Texture2D fire;
        public Texture2D freeze;
        public Texture2D barrier;
        public Texture2D turnaround;

        public ShowCD()
        {
            fire = Raylib.LoadTexture("Fire.png");
            freeze = Raylib.LoadTexture("Freeze.png");
            barrier = Raylib.LoadTexture("Barrier.png");
            turnaround = Raylib.LoadTexture("TurnAround.png");

            Raylib.SetTextureFilter(fire, TextureFilter.Point);
            Raylib.SetTextureFilter(freeze, TextureFilter.Point);
            Raylib.SetTextureFilter(barrier, TextureFilter.Point);
            Raylib.SetTextureFilter(turnaround, TextureFilter.Point);
        }

        
        public void ShowCDP1(Reckets p1)
        {
            Raylib.DrawText("E", (int)firepicpos.X - 5, (int)firepicpos.Y - 9, 15, Color.White);
            Raylib.DrawText("Q", (int)freezepicpos.X - 5, (int)freezepicpos.Y - 7, 15, Color.White);
            Raylib.DrawText("R", (int)barrierpicpos.X - 10, (int)barrierpicpos.Y - 7, 15, Color.White);
            Raylib.DrawText("F", (int)turnaroundpicpos.X - 5, (int)turnaroundpicpos.Y - 10, 15,  Color.White);
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
            Raylib.DrawText("<", (int)firepicpos2.X - 5, (int)firepicpos2.Y - 11, 20, Color.White);
            Raylib.DrawText(">", (int)freezepicpos2.X - 5, (int)freezepicpos2.Y - 7, 20, Color.White);
            Raylib.DrawText("Shift", (int)barrierpicpos2.X - 32, (int)barrierpicpos2.Y - 7, 15, Color.White);
            Raylib.DrawText("Enter", (int)turnaroundpicpos2.X - 32, (int)turnaroundpicpos2.Y - 10, 15, Color.White);
            if (p2.cooldownFirep2 <= 0)
            {
                Raylib.DrawTextureEx(fire, firepicpos2, 0, 3f, Color.White);
            }
            else
            {
                Raylib.DrawTextureEx(fire, firepicpos2, 0, 3f, Color.Gray);
                Raylib.DrawText($"{p2.cooldownFirep2:F1}", (int)firepicpos2.X + 7, (int)firepicpos2.Y + 9, 25, Color.White);
            }
            if (p2.cooldownFreezep2 <= 0)
            {
                Raylib.DrawTextureEx(freeze, freezepicpos2, 0, 2.1f, Color.White);
            }
            else
            {
                Raylib.DrawTextureEx(freeze, freezepicpos2, 0, 2.1f, Color.Gray);
                Raylib.DrawText($"{p2.cooldownFreezep2:F1}", (int)freezepicpos2.X + 8, (int)freezepicpos2.Y + 13, 25, Color.White);
            }
            if (p2.cooldownBarrierp2 <= 0)
            {
                Raylib.DrawTextureEx(barrier, barrierpicpos2, 0, 2.1f, Color.White);
            }
            else
            {
                Raylib.DrawTextureEx(barrier, barrierpicpos2, 0, 2.1f, Color.Gray);
                Raylib.DrawText($"{p2.cooldownBarrierp2:F1}", (int)barrierpicpos2.X + 5, (int)barrierpicpos2.Y + 11, 25, Color.White);
            }
            if (p2.cooldownTurn <= 0)
            {
                Raylib.DrawTextureEx(turnaround, turnaroundpicpos2, 0, 2.1f, Color.White);
            }
            else
            {
                Raylib.DrawTextureEx(turnaround, turnaroundpicpos2, 0, 2.1f, Color.Gray);
                Raylib.DrawText($"{p2.cooldownTurn:F1}", (int)turnaroundpicpos2.X + 2, (int)turnaroundpicpos2.Y + 6, 25, Color.White);
            }
        }
    }
}
