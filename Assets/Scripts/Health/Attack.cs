using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StupidGirlGames.AttackSystem
{
	/// <summary>
	/// Struct for an attack. An attack involves different values for the attack and an owner
	/// of the attack. For now, we just have an int value for the damage given. Consider
	/// extending to more interesting attack variables(fire damage, ice damage, etc)
	/// </summary>
    public struct Attack
	{
		public int value;
		public GameObject owner;

		public Attack(GameObject owner, int value)
		{
			this.owner = owner;
			this.value = value;
		}
	}
}
