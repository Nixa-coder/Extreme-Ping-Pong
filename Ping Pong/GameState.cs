using System;
using System.Collections.Generic;
using System.Text;

namespace Ping_Pong
{
    public enum GameState
    {
        MainMenu,
        ModeSelect,
        Playing
    }

    public interface IPowers
    {
        void FireBall(Ball b, float deltaTime, Recket2 re, Reckets r);
        

        void FreezeBall(Ball b, float deltaTime, Recket2 re, Reckets r);
        
        
        void Barrier(Ball b, float deltaTime);
        
        void DrawBarrier();
        void TurnAround(Ball b, float deltaTime);
        
        

    }
}
