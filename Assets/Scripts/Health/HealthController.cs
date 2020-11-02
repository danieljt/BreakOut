using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StupidGirlGames.Health
{
	/// <summary>
	/// The health component is a script that can be added to a gameobject to apply a health.
	/// The script implements the IHealth interface.
	/// </summary>
	public class HealthController : MonoBehaviour, IHealth
	{
		public int maxHealth;
		private int health;
		public event Action<int> OnHealthChanged;
		public event Action OnHealthZero;

		private void Awake()
		{
			health = maxHealth;
		}

		public void ChangeHealth(int value)
		{
			health += value;
			CallOnHealthChanged(health);
			if(health <= 0)
			{
				CallOnHealthZero();
			}
		}

		/// <summary>
		/// Helper method for calling the Onhealthchanged event
		/// </summary>
		/// <param name="value"></param>
		private void CallOnHealthChanged(int value)
		{
			if(OnHealthChanged != null)
			{
				OnHealthChanged(value);
			}
		}

		/// <summary>
		/// Helper method for calling the OnHealthzero event
		/// </summary>
		private void CallOnHealthZero()
		{
			if(OnHealthZero != null)
			{
				OnHealthZero();
			}
		}
	}

	/// <summary>
	/// Structure for keeping 
	/// </summary>
	public struct Health
	{
        int value;
        public Health(int value)
		{
            this.value = value;
		}
	}
}
