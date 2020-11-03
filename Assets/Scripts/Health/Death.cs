using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StupidGirlGames.HealthSystem
{
    /// <summary>
    /// Class for handling the death of a gameobject. This component communicates directly with
    /// an Ihealth interface if added, but does not require it to function.
    /// </summary>
    public class Death : MonoBehaviour, IDeath
    {
        public IHealth healthInterface;

		// Called when this object dies
		public event Action OnDeath;

		private void Awake()
		{
			healthInterface = GetComponent<IHealth>();
		}

		private void OnEnable()
		{
			if(healthInterface != null)
			{
				healthInterface.OnHealthZero += OnDeath;
			}
		}

		private void OnDisable()
		{
			if(healthInterface != null)
			{
				healthInterface.OnHealthZero -= OnDisable;
			}
		}
	
		/// <summary>
		/// Kill the object. By killing the object, we mean disabling it
		/// </summary>
		public void Die()
		{
			OnDeath?.Invoke();
			this.gameObject.SetActive(false);
		}
	}
}
