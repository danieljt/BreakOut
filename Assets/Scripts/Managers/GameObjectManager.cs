using StupidGirlGames.HealthSystem;
using StupidGirlGames.Patterns.Mediator;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// This is a manager for gameobjects in a game object run time list. When the runtimelist
    /// is empty, this class wil either disable or destroy itself depending on the chosen
    /// deathbehaviour.
    /// </summary>
    public class GameObjectManager : MonoBehaviour
    {
        [Tooltip("The runtimelist that this manager listens to")]
        public GameObjectRunTimeList runTimeList;
        public DeathBehaviour deathBehaviour;

        public enum DeathBehaviour
		{
            DestroyObject,
            DisableObject
        }

		private void OnEnable()
		{
            if(runTimeList != null)
			{
                runTimeList.OnEmpty += Empty;
			}
		}

		private void OnDisable()
		{
            if (runTimeList != null)
            {
                runTimeList.OnEmpty -= Empty;
            }
        }

        private void Empty()
        {
            switch (deathBehaviour)
            {
                case DeathBehaviour.DestroyObject:
                    Destroy(this.gameObject);
                    break;
                case (DeathBehaviour.DisableObject):
                    this.gameObject.SetActive(false);
                    break;
            }
        }
	}
}
