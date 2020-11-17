
namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// Contains important game data. All data that needs to be saved is stored in this class.
    /// Objects can read their data from this class on scene loads if they have the appropriate 
    /// classes or interfaces.
    /// </summary>
    [System.Serializable]
    public class GameData
    {
        public string gameName;
        public int levelNumber;
        public int score;
        public int lives;
        public int health;
    }
}
