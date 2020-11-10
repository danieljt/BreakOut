using StupidGirlGames.Patterns.Mediator;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// A scenemanager is the main manager for each scene. This script holds important information about the
    /// blocks, enemies and other important entities required to beat a level. A scenemanager instantiates a 
    /// Game manager singleton if it is not present, and sends communications to many runtime lists and mediators
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        [Tooltip("The game manager prefab. In case of the manager not being instantiated, the scene manager can instantiate a copy")]
        public GameManager gameManagerPrefab;

        [Tooltip("This is the list of win conditions game objects. When enough winconditions are satisfied, the level completes")]
        public GameObjectRunTimeList winConditions;

        [Tooltip("The number of win conditions to satisfy before the level is complete")]
        public int winConditionsToWin;

        [Tooltip("When the levelmanager is completed, these objects are instantiated")]
        public List<GameObject> winObjectsToActivate;

        [Tooltip("When the level manager is completed, notify this mediator")]
        public MediatorAsset notifyOnWin;

        [Tooltip("This is the list of fail condition game objects. When enough failconditions are satisfied, the level failes")]
        public GameObjectRunTimeList failConditions;

        [Tooltip("This is the amount of winconsitions to satisfy before the level is failed")]
        public int failConditionsToFail;

        [Tooltip("When the levelmanager is failed, these objects are activated")]
        public List<GameObject> failObjectsToActivate;

        [Tooltip("When the level manager has failed, notify this mediator")]
        public MediatorAsset notifyOnFail;

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

            if(notifyOnWin != null)
			{
                OnLevelComplete += notifyOnWin.Notify;
			}

            if(notifyOnFail != null)
			{
                OnLevelFailed += notifyOnFail.Notify;
			}
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

            if (notifyOnWin != null)
            {
                OnLevelComplete -= notifyOnWin.Notify;
            }

            if (notifyOnFail != null)
            {
                OnLevelFailed -= notifyOnFail.Notify;
            }
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
                InstantiateObjects(winObjectsToActivate);
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
                InstantiateObjects(failObjectsToActivate);
            }
		}

        /// <summary>
        /// Instantiate all the objects in the list given that the list exists
        /// </summary>
        /// <param name="list"></param>
        private void InstantiateObjects(List<GameObject> list)
		{
            if(list != null)
			{
                foreach(GameObject gameObject in list)
				{
                    Instantiate(gameObject, Vector3.zero, Quaternion.identity);
				}
			}
		}
	}
}
