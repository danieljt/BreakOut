using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace StupidGirlGames.BreakOut
{
	/// <summary>
	/// This component contains methods for the UI when 
	/// </summary>
	public class LevelFailedUIController : MonoBehaviour
	{
		private void Awake()
		{
			this.gameObject.SetActive(false);
		}
	}
}
