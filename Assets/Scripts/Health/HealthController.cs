using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using StupidGirlGames.AttackSystem;

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
		public event Action<Attack> OnHealthChanged;
		public event Action<GameObject> OnHealthZero;

		private void Awake()
		{
			health = maxHealth;
		}

		/// <summary>
		/// Lose health. The health loss is never more than zero
		/// </summary>
		/// <param name="value"></param>
		public void LoseHealth(Attack attack)
		{
			if(health - attack.value < 0)
			{
				attack.value = health;
			}

			health -= attack.value;
			OnHealthChanged?.Invoke(attack);

			// In the case of the health going down to zero
			if(health <= 0)
			{
				OnHealthZero?.Invoke(attack.owner);
			}
		}

		/// <summary>
		/// Gain health. The gain is never larger than the max health.
		/// </summary>
		/// <param name="attack"></param>
		public void GainHealth(Attack attack)
		{
			if(health + attack.value > maxHealth)
			{
				health = maxHealth;
			}
			else
			{
				health += attack.value;
			}
		}
	}
}
