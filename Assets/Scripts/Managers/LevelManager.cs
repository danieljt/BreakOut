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

		[Tooltip("The gameobjects that this scenemanager can affect")]
		public GameObjectRunTimeList sceneObjects;

		[Tooltip("The number of win conditions to satisfy before the level is complete")]
		public int winConditionsToWin;

		[Tooltip("This level manager recieves win events from this mediator")]
		public GameObjectMediatorAsset winConditionMet;

		[Tooltip("When enough win conditions are satisfied, notify this mediator")]
		public MediatorAsset notifyOnWin;

		[Tooltip("This is the amount of winconsitions to satisfy before the level is failed")]
		public int failConditionsToFail;

		[Tooltip("The levelmanager recieves fail events from this mediator")]
		public GameObjectMediatorAsset failConditionMet;

		[Tooltip("When the level manager has failed, notify this mediator")]
		public MediatorAsset notifyOnFail;

		// This event is invoked when all the conditions in the scene have been met
		public event Action OnLevelComplete;

		// This event is invoked when a scene is failed
		public event Action OnLevelFailed;

		// Use these conters to count win and fail conditions when they are called
		private int winCounter;
		private int failCounter;

		// These lists hold the win and fail conditions when they are called
		private List<GameObject> winConditionsList;
		private List<GameObject> failConditionsList;

		// These booleans are for when a level is already completed or failed. An object can be sendt by the
		// mediators even after the level has been flagged as complete. We use these booleans to stop any events
		// from occuring after the level is complete.
		private bool levelAlreadyEnded;

		private void Awake()
		{

			// We check to see if the game manager is instantiated, and if not we instantiate
			// a new copy. Make sure to add a reference to it in the Level manager prefab.
			if (!GameManager.IsInstantiated)
			{
				Instantiate(gameManagerPrefab);
			}

			winCounter = 0;
			failCounter = 0;
			winConditionsList = new List<GameObject>();
			failConditionsList = new List<GameObject>();
			levelAlreadyEnded = false;
		}

		private void OnEnable()
		{
			if (winConditionMet != null)
			{
				winConditionMet.Notify += WinConditionMet;
			}

			if (notifyOnWin != null)
			{
				OnLevelComplete += notifyOnWin.CallNotify;
			}

			if (failConditionMet != null)
			{
				failConditionMet.Notify += FailConditionMet;
			}

			if (notifyOnFail != null)
			{
				OnLevelFailed += notifyOnFail.CallNotify;
			}
		}


		private void OnDisable()
		{
			if (winConditionMet != null)
			{
				winConditionMet.Notify -= WinConditionMet;
			}

			if (notifyOnWin != null)
			{
				OnLevelComplete -= notifyOnWin.CallNotify;
			}

			if (failConditionMet != null)
			{
				failConditionMet.Notify -= FailConditionMet;
			}

			if (notifyOnFail != null)
			{
				OnLevelFailed -= notifyOnFail.CallNotify;
			}
		}

		/// <summary>
		/// Called everytime a win condition is met. The condition GameObject is added to a list.
		/// When enough win conditions are met the level managers calls the LevelComplete event.
		/// A gameobject can only have one appearance in each list.
		/// </summary>
		private void WinConditionMet(GameObject condition)
		{
			if (!winConditionsList.Contains(condition))
			{
				winCounter++;
				winConditionsList.Add(condition);
				if (winCounter >= winConditionsToWin)
				{
					if (!levelAlreadyEnded)
					{
						levelAlreadyEnded = true;
						OnLevelComplete?.Invoke();
						DestroyAllObjectsInScene(sceneObjects);
					}
				}
			}
		}

		/// <summary>
		/// Called everytime a fail condition is met. The condition gameobject is added to a list.
		/// When enough fail conditions are met the level manager calls the OnLevelFailed event. 
		/// A gameobject can only have one appearance in each list.
		/// </summary>
		private void FailConditionMet(GameObject condition)
		{
			if (!failConditionsList.Contains(condition))
			{
				failCounter++;
				failConditionsList.Add(condition);
				if (failCounter >= failConditionsToFail)
				{
					if (!levelAlreadyEnded)
					{
						levelAlreadyEnded = true;
						OnLevelFailed?.Invoke();
						DestroyAllObjectsInScene(sceneObjects);
					}
				}
			}
		}

		/// <summary>
		/// Destroy all gameobjects in the scene that are added to the runtimeList. Great for destroying things 
		/// that can have an effect on the game while menues are showing. A typical example is the player losing 
		/// a life because the ball hits the ground while the victory message is showing.
		/// </summary>
		/// <param name="runtimeList"></param>
		private void DestroyAllObjectsInScene(GameObjectRunTimeList runtimeList)
		{
			if(runtimeList != null)
			{
				for(int i=runtimeList.Objects.Count - 1; i >= 0; i--)
				{
					Destroy(runtimeList.Objects[i]);
				}
			}
		}
	}
}
