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
    public class LevelManager : MonoBehaviour
    {
        [Tooltip("The game manager prefab. In case of the manager not being instantiated, the scene manager can instantiate a copy")]
        public GameManager gameManagerPrefab;

        [Tooltip("This is the list of win conditions. When this list is empty, the scene is complete")]
        public GameObjectRunTimeList winConditions;

        [Tooltip("This is the list of fail conditions. When this list is empty, the scene ends with game over")]
        public GameObjectRunTimeList failConditions;

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
                winConditions.OnEmpty += LevelCompleted;
            }

            if(failConditions != null)
			{
                failConditions.OnEmpty += LevelFailed;
			}

            OnSceneComplete += GameManager.Instance.LoadNextLevel;
		}

		private void OnDisable()
		{
            if (winConditions != null)
            {
                winConditions.OnEmpty -= LevelCompleted;
            }

            if(failConditions != null)
			{
                failConditions.OnEmpty -= LevelFailed;
			}

            OnSceneComplete -= GameManager.Instance.LoadNextLevel;

		}

        /// <summary>
        /// This method is invoked when all win conditions are met and the level has been completed
        /// </summary>
		private void LevelCompleted()
		{
            OnSceneComplete?.Invoke();
		}

        /// <summary>
        /// This method is invoked when a fail condition is met
        /// </summary>
        private void LevelFailed()
		{
            OnSceneFailed?.Invoke();
		}
	}
}
