using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StupidGirlGames.ScoreSystem
{
    /// <summary>
    /// Interface for any object that can recieve scores
    /// </summary>
    public interface IScoreReciever
    {
        void RecieveScore(Score score);      
    }
}
