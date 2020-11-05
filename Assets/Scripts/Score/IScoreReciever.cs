using System;

namespace StupidGirlGames.ScoreSystem
{
    /// <summary>
    /// Interface for any object that can recieve scores
    /// </summary>
    public interface IScoreReciever
    {
        event Action<Score> OnScoreRecieved;
        void RecieveScore(Score score);      
    }
}
