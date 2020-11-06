using System;
using UnityEngine;
using StupidGirlGames.AttackSystem;

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
		public event Action<Attack> OnDeath;
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
		/// TODO:
		/// Consider adding calls to this method when the gameobject is disabled or destroyed
		/// outside of this method
		/// </summary>
		public void Die(Attack attack)
		{
			OnDeath?.Invoke(attack);

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
