using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using StupidGirlGames.Patterns.Singleton;
using StupidGirlGames.Patterns.Mediator;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// A game manager controls the flow of the game state and the save/load functionality. Game state is
    /// defined as a state machine. The game manager is a singleton as it needs to work from any scene. 
    /// Limit the amount of objects communicating directly with this class. 
    /// with the game manager 
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        [Tooltip("This is the mediator where savedata can be recieved and sent")]
        public SaveDataMediatorAsset saveMediator;

        // This is the GameData 
        private GameData gameData;

        // This is the gameData name path. The application only has one data file. this file is holy. It is
        // not to be touched, changed or in any way fiddled with unless you REALLY KNOW WHAT YOU ARE
        // DOING.
        private const string gameDataName = "gameData.sggsf";

        // This is the current saveData file.
        private SaveData currentSaveData;

        /// <summary>
        /// Return the current save data
        /// </summary>
        public SaveData GetCurrentSaveData
		{
			get { return currentSaveData; }
		}

        private void OnEnable()
		{
            gameData = LoadGameData();
		}

		private void Start()
		{
            DontDestroyOnLoad(this);
		}

		private void OnDisable()
		{
            SaveGameData(gameData, Application.persistentDataPath + gameDataName);
		}

		/// <summary>
		/// Method loads the gameData file from disk. If no gameData file exists in the persistent
        /// dataPath then this metho will create a new gameData file.
		/// </summary>
		/// <returns></returns>
		private GameData LoadGameData()
		{
            string filePath = Application.persistentDataPath + gameDataName;
            if(File.Exists(filePath))
			{
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(filePath, FileMode.Open);
                GameData newGameData = (GameData)bf.Deserialize(file);
                file.Close();
                return newGameData;
			}

            else
			{
                return new GameData();
			}
		}

        /// <summary>
        /// Method saves the gameData file to disk. This method will always overwrite the current
        /// gameData file.
        /// </summary>
        private void SaveGameData(GameData newGameData, string filePath)
		{
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Create);
            bf.Serialize(file, newGameData);
            file.Close();
		}
	}
}
