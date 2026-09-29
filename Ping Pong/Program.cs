using Raylib_cs;
using System.Numerics;

namespace Ping_Pong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Raylib.InitWindow(900, 450, "Ping Pong");
            Raylib.SetTargetFPS(60);
            Reckets p1 = new Reckets();
            Recket2 p2 = new Recket2();
            Ball b = new Ball();
            Collisions c = new Collisions();
            Points point = new Points();
            AIReket ai = new AIReket();
            

            Vector2 firepicpos = new Vector2(20, 400);
            Texture2D fire = Raylib.LoadTexture("Fire.png");
            Raylib.SetTextureFilter(fire, TextureFilter.Point);


            Vector2 freezepicpos = new Vector2(65, 395);
            Texture2D freeze = Raylib.LoadTexture("Freeze.png");
            Raylib.SetTextureFilter(freeze, TextureFilter.Point);


            Vector2 barrierpicpos = new Vector2(115, 395);
            Texture2D barrier = Raylib.LoadTexture("Barrier.png");
            Raylib.SetTextureFilter(barrier, TextureFilter.Point);

            Vector2 turnaroundpicpos = new Vector2(160, 400);
            Texture2D turnaround = Raylib.LoadTexture("TurnAround.png");
            Raylib.SetTextureFilter(turnaround, TextureFilter.Point);

            GameState currentState = GameState.MainMenu;
            bool isVSbot = false;

            while (!Raylib.WindowShouldClose())
            {
                float fps = Raylib.GetFrameTime();
                

                //Game Menu and entering it, also with game mechanics   
                switch (currentState)
                {
                    case GameState.MainMenu:
                        if(Raylib.IsKeyPressed(KeyboardKey.Enter) || Raylib.IsKeyPressed(KeyboardKey.Space))
                        {
                            currentState = GameState.ModeSelect;
                        }
                        break;

                    case GameState.ModeSelect:
                        if (Raylib.IsKeyPressed(KeyboardKey.One))
                        {
                            isVSbot = false;
                            currentState = GameState.Playing;
                        }
                        else if (Raylib.IsKeyPressed(KeyboardKey.Two))
                        {
                            isVSbot = true;
                            currentState = GameState.Playing;
                        }
                        break;

                    case GameState.Playing:
                        p1.Move(fps);
                        b.Moving(fps);
                        p1.FireBall(b,fps, p2, p1);
                        p1.FreezeBall(b, fps, p2, p1);
                        p1.Barrier(b, fps);
                        p1.TurnAround(b, fps);
                        

                        if (isVSbot)
                        {
                            ai.Moving(b, fps);
                        }
                        else
                        {
                            p2.Move(fps);
                            p2.FireBall(b, fps, p2, p1);
                            p2.FreezeBall(b, fps, p2, p1);
                            p2.Barrier(b, fps);
                            p2.TurnAround(b, fps);
                        }

                        c.Collision(p1, b, p2, ai, isVSbot);
                        point.Point(b, p1, p2, ai);
                        
                        break;

                }
                
                //Now starts drawing
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                switch (currentState)
                {
                    case GameState.MainMenu:
                        Raylib.DrawText("Extreme Ping Pong", 250, 150, 40, Color.Red);
                        Raylib.DrawText("Press [ENTER] or [SPACE] to PLAY", 250, 250, 20, Color.White);
                        Raylib.DrawText("Commands for P1: [E]FireBall [Q]FreezeBall [R]Barrier [F]TurnBall", 115, 300, 20, Color.Orange);
                        Raylib.DrawText("Commands for P2: [Left]FireBall [Right]FreezeBall [R.Shift]Barrier [Enter]TurnBall", 30, 330, 20, Color.Green);
                        break;

                    case GameState.ModeSelect:
                        Raylib.DrawText("Choose Mode", 280, 120, 30, Color.White);
                        Raylib.DrawText("(1) PVP", 270, 210, 20, Color.Blue);
                        Raylib.DrawText("(2) PVSAi", 270, 260, 20, Color.Red);
                        break;

                    case GameState.Playing:
                        p1.Draw();
                        Raylib.DrawLine(0, 380, 900, 380, Color.White);
                        if(p1.cooldown <= 0)
                        {
                            Raylib.DrawTextureEx(fire, firepicpos, 0, 2f, Color.White);
                        }
                        else
                        {
                            Raylib.DrawTextureEx(fire, firepicpos, 0, 2f, Color.Gray);
                            Raylib.DrawText($"{p1.cooldown:F1}", (int)firepicpos.X + 5, (int)firepicpos.Y + 6, 15, Color.White);
                        }
                        if(p1.cooldownFreeze <= 0)
                        {
                            Raylib.DrawTextureEx(freeze, freezepicpos, 0, 1.5f, Color.White);
                        }
                        else
                        {
                            Raylib.DrawTextureEx(freeze, freezepicpos, 0, 1.5f, Color.Gray);
                            Raylib.DrawText($"{p1.cooldownFreeze:F1}", (int)freezepicpos.X + 7, (int)freezepicpos.Y + 9, 15, Color.White);
                        }
                        if(p1.cooldownBarrier <= 0)
                        {
                            Raylib.DrawTextureEx(barrier, barrierpicpos, 0, 1.5f, Color.White);
                        }
                        else
                        {
                            Raylib.DrawTextureEx(barrier, barrierpicpos, 0, 1.5f, Color.Gray);
                            Raylib.DrawText($"{p1.cooldownBarrier:F1}", (int)barrierpicpos.X + 5, (int)barrierpicpos.Y + 7, 15, Color.White);
                        }
                        if(p1.cooldownTurn <= 0)
                        {
                            Raylib.DrawTextureEx(turnaround, turnaroundpicpos, 0, 1.5f, Color.White);
                        }
                        else
                        {
                            Raylib.DrawTextureEx(turnaround, turnaroundpicpos, 0, 1.5f, Color.Gray);
                            Raylib.DrawText($"{p1.cooldownTurn:F1}", (int)turnaroundpicpos.X + 5, (int)turnaroundpicpos.Y + 6, 15, Color.White);
                        }

                        

                        if (isVSbot)
                        {
                            ai.DrawAI();
                        }
                        else
                        {
                            p2.Draw();
                            p2.DrawBarrier();
                        }

                        b.Draw();
                        point.DrawPoints();
                        p1.DrawBarrier();
                        
                        break;

                }
                

                Raylib.EndDrawing();
            }

            Raylib.UnloadTexture(p1.Reket);
            Raylib.UnloadTexture(p2.Reket);
            Raylib.UnloadTexture(fire);
            Raylib.UnloadTexture(freeze);
            Raylib.UnloadTexture(barrier);
            Raylib.UnloadTexture(turnaround);
            Raylib.UnloadTexture(b.ball);
            Raylib.CloseWindow();
        }

        
    }
}
