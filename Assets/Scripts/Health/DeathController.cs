using System;
using UnityEngine;

namespace StupidGirlGames.HealthSystem
{
    /// <summary>
    /// Class for handling the death of a gameobject. This component communicates directly with
    /// an Ihealth interface if added, but does not require it to function.
    /// </summary>
    public class DeathController : MonoBehaviour, IDeath
    {
		public DeathBehaviour deathBehaviour;

		// Called when this object dies
		public event Action<GameObject> OnDeath;
		public IHealth healthInterface;

		/// <summary>
		/// The behaviour when this gameobject dies. Decides if the game object is destroyed or disabled on death.
		/// It is advised to use DisableObject when many objects are spawned and killed.
		/// </summary>
		public enum DeathBehaviour
		{
			DestroyObject,
			DisableObject
		}

		private void Awake()
		{
			healthInterface = GetComponent<IHealth>();
		}

		private void OnEnable()
		{
			if(healthInterface != null)
			{
				healthInterface.OnHealthZero += Die;
			}
		}

		private void OnDisable()
		{
			if(healthInterface != null)
			{
				healthInterface.OnHealthZero -= Die;
			}
		}
	
		/// <summary>
		/// Kill the object. The object is killed according to how the deathBehaviour selected. It is important to
		/// note that this method or the OnDeath event are not called when the object is destroyed or disabled out of this scope.
		/// 
		/// </summary>
		public void Die(GameObject killer)
		{
			OnDeath?.Invoke(killer);

			switch(deathBehaviour)
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
