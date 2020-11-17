using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using StupidGirlGames.Patterns.Singleton;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// A game manager controls the flow of the game state and the save/load functionality. Game state is
    /// defined as a state machine. The game manager is a singleton as it needs to work from any scene. 
    /// Limit the amount of objects communicating directly with this class. 
    /// with the game manager 
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
		private void Start()
		{
            DontDestroyOnLoad(this);
		}
	}
}
