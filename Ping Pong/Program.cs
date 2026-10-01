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
            ShowCD s = new ShowCD();
            

            

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
                        s.ShowCDP1(p1);

                        

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
            Raylib.UnloadTexture(s.fire);
            Raylib.UnloadTexture(s.freeze);
            Raylib.UnloadTexture(s.barrier);
            Raylib.UnloadTexture(s.turnaround);
            Raylib.UnloadTexture(b.ball);
            Raylib.CloseWindow();
        }

        
    }
}
