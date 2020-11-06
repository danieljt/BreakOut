using StupidGirlGames.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// A scenemanager is the main manager for each scene. This script holds important information about the
    /// blocks, enemies and other important entities required to beat a level. A scenemanager communicates
    /// directly with the gamemanager singleton.
    /// </summary>
    public class SceneManager : MonoBehaviour
    {
        [Tooltip("This is the list of blocks in the scene")]
        public GameObjectRunTimeList blocks;

        [Tooltip("This is the list of enemies in the scene")]
        public GameObjectRunTimeList enemies;

        // This event is invoked when all the conditions in the scene have been met
        public event Action OnSceneComplete;

		private void OnEnable()
		{
			
		}
	}
}
