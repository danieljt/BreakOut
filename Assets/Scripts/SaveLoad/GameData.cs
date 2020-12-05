using System.Collections.Generic;

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
        // This is the list that holds the save datas. 
        public List<SaveData> saveFiles;
        
        /// <summary>
        /// This method adds the new save data to the game data list. The method sorts the savedata files
        /// with respect to the score, setting the saveData with the highest scores first.
        /// </summary>
        /// <param name="newSaveData"></param>
        public void Add(SaveData newSaveData)
		{
            if(!saveFiles.Contains(newSaveData))
			{
                saveFiles.Add(newSaveData);
			} 

            else
			{
                for(int i=0; i<saveFiles.Count; i++)
				{
                    if(newSaveData.Equals(saveFiles[i]))
					{
                        saveFiles[i] = newSaveData;
                        
                    }
				}
			}

            saveFiles.Sort((x, y) => x.score.CompareTo(y.score));
        }
    }
}
