using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StupidGirlGames.Patterns.Mediator
{
    /// <summary>
    /// This component adds and removes a gameobject a runtimelist. This component secures
	/// that an object is always removed before a scene load and added before start.
    /// </summary>
    public class GameObjectRunTimeListSetter : MonoBehaviour
    {
		[Tooltip("This is the runtimelist to add to")]
        public GameObjectRunTimeList runTimeList;

		private void OnEnable()
		{
            runTimeList.Add(this.gameObject);
		}

		private void OnDisable()
		{
			runTimeList.Remove(this.gameObject);
		}
	}
}
