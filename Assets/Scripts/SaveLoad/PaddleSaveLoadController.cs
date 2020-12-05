using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StupidGirlGames.Patterns.Mediator;
using StupidGirlGames.ScoreSystem;
using StupidGirlGames.HealthSystem;
using UnityEngine.SceneManagement;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// This component is responsible for loading and saving the player data to a saveData file.
    /// </summary>
    public class PaddleSaveLoadController : MonoBehaviour
    {
        [Tooltip("Mediator asset for recieving the ")]
        public SaveDataMediatorAsset saveDataMediator;

        private SaveData saveData;

        private IScoreReciever scoreReciever;
        private IHealth health;
        private SceneManager sceneManager;

		private void Awake()
		{
            scoreReciever = GetComponent<IScoreReciever>();
            health = GetComponent<IHealth>();
		}

		private void OnEnable()
		{
			
		}

		private void OnDisable()
		{
			
		}

        private void SendSaveData(SaveData newSaveData)
		{

		}

		private void RecieveSaveData(SaveData newSaveData)
		{

		}
	}
}
