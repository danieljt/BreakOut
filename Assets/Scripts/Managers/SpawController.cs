using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// A spawner is a script that can spawn a gameobjects to the scene. This script is added
    /// to a game object, and objects are spawned at the transform of the spawner.
    /// </summary>
    public class SpawController : MonoBehaviour
    {
		[Tooltip("The gameobject to be spawned")]
        public GameObject objectToSpawn;
		private GameObject spawnedObject;

		private void Awake()
		{
			if(objectToSpawn)
			{
				spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
			}
		}
	}
}
