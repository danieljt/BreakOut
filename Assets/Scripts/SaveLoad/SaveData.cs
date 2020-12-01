using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StupidGirlGames.BreakOut
{
	/// <summary>
	/// Contains the save data for the game.
	/// </summary>
	[System.Serializable]
	public struct SaveData
	{
		public string name;
		public int levelNumber;
		public int score;
	}
}
