using StupidGirlGames.Patterns.Mediator;
using System;
using UnityEngine;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// This is a manager class for gameobjects in a gameObject runtime list. When the runtimelist
    /// is empty, this manager will call the corresponding GameObject mediator asset.
    /// </summary>
    public class GameObjectManager : MonoBehaviour
    {
        [Tooltip("The runtimelist that this manager listens to")]
        public GameObjectRunTimeList runTimeList;

        [Tooltip("The manager sends events to this mediator when it's runtime list is empty")]
        public GameObjectMediatorAsset mediator;

        [Tooltip("Set to true if the Manager should only invoke the event the first time the runtime list is empty")]
        public bool invokeOnce;

        // This event is called when the runtimelist is empty
        public event Action<GameObject> OnRunTimeListEmpty;

        // This bool signifies that the runtimelist has already been emptied one time
        private bool alreadyEmpty;

		private void Awake()
		{
            alreadyEmpty = !alreadyEmpty;
		}

		private void OnEnable()
		{
            if(runTimeList != null)
			{
                runTimeList.OnEmpty += Empty;
			}

            if(mediator != null)
			{
                OnRunTimeListEmpty += mediator.CallNotify;
			}
		}

		private void OnDisable()
		{
            if (runTimeList != null)
            {
                runTimeList.OnEmpty -= Empty;
            }

            if(mediator != null)
			{
                OnRunTimeListEmpty -= mediator.CallNotify;
			}
        }

        /// <summary>
        /// This function is called when the runtimelist is empty. This method will
        /// call the OnRunTimeListEmpty event. That method is called if:
        /// - invokeOnce is false
        /// - invokeOnce is true and alreadyEmpty is false
        /// 
        /// In all other cases the onRunTimeListEmpty evet is NOT called.
        /// </summary>
        private void Empty()
        {
            if (invokeOnce)
            {
                if (!alreadyEmpty)
                {
                    alreadyEmpty = !alreadyEmpty;
                    OnRunTimeListEmpty?.Invoke(gameObject);
                }
            }

            else
			{
                OnRunTimeListEmpty?.Invoke(gameObject);
			}
        }
	}
}
