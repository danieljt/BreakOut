using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StupidGirlGames.HealthSystem
{
	/// <summary>
	/// The health component is a script that can be added to a gameobject to apply a health.
	/// The script implements the IHealth interface.
	/// </summary>
	public class HealthController : MonoBehaviour, IHealth
	{
		[Tooltip("The maximum health for this component")]
		public int maxHealth;
		private int health;
		public event Action<int> OnHealthChanged;
		public event Action OnHealthZero;

		private void Awake()
		{
			health = maxHealth;
		}

		/// <summary>
		/// Change the health by the given value. This can be used for both health gains and health losses. The health
		/// gain will never exceed max health, and will never go below zero.
		/// </summary>
		/// <param name="value"></param>
		public void TakeDamage(int value)
		{
			if(health + value > maxHealth)
			{
				value = maxHealth - health;
			}

			health += value;

			OnHealthChanged?.Invoke(value);

			// In the case of the health going down to zero
			if(health <= 0)
			{
				health = 0;
				OnHealthZero?.Invoke();
			}
		}
	}
}
