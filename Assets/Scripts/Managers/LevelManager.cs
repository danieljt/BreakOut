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

        [Tooltip("The number of win conditions to satisfy before the level is complete")]
        public int winConditionsToWin;

        [Tooltip("This is the list of fail conditions. When this list is empty, the scene ends with game over")]
        public GameObjectRunTimeList failConditions;

        [Tooltip("This is the amount of winconsitions to satisfy before the level is failed")]
        public int failConditionsToFail;

        // This event is invoked when all the conditions in the scene have been met
        public event Action OnLevelComplete;

        // This event is invoked when a scene is failed
        public event Action OnLevelFailed;

        // Use these conters to count win and fail conditions when they are called
        private int winCounter;
        private int failCounter;

		private void Awake()
		{
			if(!GameManager.IsInstantiated)
			{
                Instantiate(gameManagerPrefab);
			}

            winCounter = 0;
            failCounter = 0;
		}

		private void OnEnable()
		{
            if (winConditions != null)
            {
                winConditions.OnEmpty += WinConditionMet ;
            }

            if(failConditions != null)
			{
                failConditions.OnEmpty += FailConditionMet;
			}

            OnLevelComplete += GameManager.Instance.LoadNextLevel;
		}

		private void OnDisable()
		{
            if (winConditions != null)
            {
                winConditions.OnEmpty -= WinConditionMet;
            }

            if(failConditions != null)
			{
                failConditions.OnEmpty -= FailConditionMet;
			}

            OnLevelComplete -= GameManager.Instance.LoadNextLevel;

		}

        /// <summary>
        /// Called everytime a win condition is met. When enough win conditions are met
        /// the level managers calls the LevelComplete event.
        /// </summary>
        private void WinConditionMet()
		{
            winCounter++;
            if(winCounter >= winConditionsToWin)
			{
                OnLevelComplete?.Invoke();
			}
		}

        /// <summary>
        /// Called everytime a fail condition is met. When enough fail conditions are met
        /// the level manager calls the OnLevelFailed event. 
        /// </summary>
        private void FailConditionMet()
		{
            failCounter++;
            if(failCounter >= failConditionsToFail)
			{
                OnLevelFailed?.Invoke();
			}
		}
	}
}
