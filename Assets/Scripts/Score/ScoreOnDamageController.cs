using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StupidGirlGames.HealthSystem;

namespace StupidGirlGames.ScoreSystem
{
    /// <summary>
    /// Component give scores when losing damage. This component communicates with an IHealth
    /// interface
    /// </summary>
    public class ScoreOnDamageController : MonoBehaviour
    {
        [Tooltip("The score given when damaged")]
        public int score;

        public IHealth healthInterface;

		private void Awake()
		{
			healthInterface = GetComponent<IHealth>();
		}

		private void OnEnable()
		{
			if(healthInterface != null)
			{
                //healthInterface.OnHealthChanged
			}
		}

		/// <summary>
		/// Gives the score to the attacker
		/// </summary>
		private void GiveScore()
		{

		}
	}
}
