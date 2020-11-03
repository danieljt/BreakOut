using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StupidGirlGames.ScoreSystem
{
	/// <summary>
	/// Structure for a score. A score has a reciever and a value
	/// </summary>
    public struct Score
	{
		public GameObject reciever;
		public int value;

		public Score(GameObject reciever, int value)
		{
			this.reciever = reciever;
			this.value = value;
		}
	}
}
