using StupidGirlGames.Patterns.Mediator;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StupidGirlGames.ScoreSystem
{
	/// <summary>
	/// Attach to any gameobject to let it keep a score. This way, anytime it interacts
	/// with score giving gameobjects it will be able to recieve scores.
	/// </summary>
	public class ScoreController : MonoBehaviour, IScoreReciever
	{
		[Tooltip("The mediator this controller communicates with")]
		public ScoreMediatorAsset scoreMediator;

		public event Action<Score> OnScoreRecieved;

		// The current score of the script
		private int score;

		private void Awake()
		{
			score = 0;
		}

		private void OnEnable()
		{
			if (scoreMediator != null)
			{
				OnScoreRecieved += scoreMediator.Notify;
			}
		}

		private void OnDisable()
		{
			if (scoreMediator != null)
			{
				OnScoreRecieved -= scoreMediator.Notify;
			}
		}

		/// <summary>
		/// Called upon recieving a score.
		/// </summary>
		/// <param name="addedScore"></param>
		public void RecieveScore(Score addedScore)
		{
			score += addedScore.value;
			OnScoreRecieved?.Invoke(addedScore);
		}
	}
}

