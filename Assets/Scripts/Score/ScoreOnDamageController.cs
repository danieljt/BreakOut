using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StupidGirlGames.HealthSystem;
using StupidGirlGames.AttackSystem;

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
				healthInterface.OnHealthChanged += GiveScore;
			}
		}

		private void OnDisable()
		{
			if(healthInterface != null)
			{
				healthInterface.OnHealthChanged -= GiveScore;
			}
		}

		/// <summary>
		/// Gives the score to the attacker
		/// </summary>
		private void GiveScore(Attack attack)
		{
			GameObject scoreReciever = attack.owner;
			if(scoreReciever != null)
			{
				IScoreReciever recieverInterface = scoreReciever.GetComponent<IScoreReciever>();
				if(recieverInterface != null)
				{
					recieverInterface.RecieveScore(new Score(scoreReciever, score * attack.value));
				}
			}
		}
	}
}
