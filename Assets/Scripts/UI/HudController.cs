using StupidGirlGames.Patterns.Mediator;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StupidGirlGames.ScoreSystem;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// This is the controller for the hud. A hud contains lives, health and the score. A hud
    /// controller listens to these values via mediator assets. 
    /// </summary>
    public class HudController : MonoBehaviour
    {
		[Tooltip("This is the score mediator that this script listens to")]
        public ScoreMediatorAsset scoreMediator;

		[Tooltip("This is the image showing the lives")]
		public Image lifeImage;

		[Tooltip("This is the image showing the health")]
		public Image healthImage;

		// This is the text object displaying the score
        private Text scoreText;

        // This is the shown health
        private List<Image> health;

        // This is the shown lives
        private List<Image> lives;

		private void Awake()
		{
            scoreText = GetComponentInChildren<Text>();
            health = new List<Image>();
            lives = new List<Image>();
		}

		private void OnEnable()
		{
			if(scoreMediator != null)
			{
				scoreMediator.OnNotify += UpdateScore;
			}
		}

		private void OnDisable()
		{
			if(scoreMediator != null)
			{
				scoreMediator.OnNotify -= UpdateScore;
			}
		}

		/// <summary>
		/// This method updates the hud score. 
		/// </summary>
		/// <param name="score"></param>
		private void UpdateScore(Score score)
		{
            if(scoreText != null)
			{
                scoreText.text = "Score: " + score.value;
			}
		}

		/// <summary>
		/// This method updates the lives
		/// </summary>
		/// <param name="lives"></param>
		private void UpdateLives(int lives)
		{

		}

		/// <summary>
		/// This method updates the health
		/// </summary>
		/// <param name="health"></param>
		private void UpdateHealth(int health)
		{

		}
	}
}
