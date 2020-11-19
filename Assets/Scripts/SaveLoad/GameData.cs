
namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// This is the main save game file. This class holds all the dataclasses for each scene in the game. The game data is stored
    /// hierarchical with the GameData holding sceneData for each scene and the sceneData holding save data for each object in the 
    /// scene.
    /// </summary>
    [System.Serializable]
    public class GameData
    {
        public string gameName;
        public SceneData[] sceneData;

        public GameData(string newGameName, SceneData[] newSceneData)
		{
            this.gameName = newGameName;
            this.sceneData = newSceneData;
		}
    }
}
