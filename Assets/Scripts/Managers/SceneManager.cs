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
        [Tooltip("The game manager prefab. In case of the manager not being instantiated, the scene manager can instantiate a copy")]
        public GameManager gameManagerPrefab;

        [Tooltip("This is the list win conditions. When this list is empty, the scene is complete")]
        public GameObjectRunTimeList winConditions;

        // This event is invoked when all the conditions in the scene have been met
        public event Action OnSceneComplete;

        // This event is invoked when a scene is failed
        public event Action OnSceneFailed;

		private void Awake()
		{
			if(!GameManager.IsInstantiated)
			{
                Instantiate(gameManagerPrefab);
			}
		}

		private void OnEnable()
		{
            if (winConditions != null)
            {
                winConditions.OnEmpty += WinConditionsMet;
            }
		}

		private void OnDisable()
		{
            if (winConditions != null)
            {
                winConditions.OnEmpty -= WinConditionsMet;
            }
		}

        /// <summary>
        /// This method 
        /// </summary>
		private void WinConditionsMet()
		{
            OnSceneComplete?.Invoke();
		}
	}
}
