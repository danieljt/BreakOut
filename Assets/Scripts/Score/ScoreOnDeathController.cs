using StupidGirlGames.HealthSystem;
using UnityEngine;

namespace StupidGirlGames.ScoreSystem
{
    /// <summary>
    /// Component for giving a score on death. this component communicates with the IDeath interface,
    /// and requires this to work properly. It will work without it as well, but no scores will be given.
    /// </summary>
    public class ScoreOnDeathController : MonoBehaviour
    {
        [Tooltip("The score this component gives when it dies")]
        public int score;
        private IDeath deathInterface;

		private void Awake()
		{
            deathInterface = GetComponent<IDeath>();
		}

		private void OnEnable()
		{
			if(deathInterface != null)
			{
				deathInterface.OnDeath += GiveScore;
			}
		}

		private void OnDisable()
		{
			if(deathInterface != null)
			{
				deathInterface.OnDeath -= GiveScore;
			}
		}

		/// <summary>
		/// Gives the score to the killer, if the killer is not null and has a IScoreReciever interface. 
		/// If the killer is null then nothing will happen
		/// </summary>
		private void GiveScore(GameObject killer)
		{
			GameObject scoreReciever = killer;
			if (scoreReciever != null)
			{
				IScoreReciever recieverInterface = scoreReciever.GetComponent<IScoreReciever>();
				if (recieverInterface != null)
				{
					recieverInterface.RecieveScore(new Score(scoreReciever, score));
				}
			}
		}
    }
}

