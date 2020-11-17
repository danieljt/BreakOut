using UnityEngine;
using UnityEngine.SceneManagement;
using StupidGirlGames.Patterns.Mediator;
using System;

namespace StupidGirlGames.BreakOut
{
	/// <summary>
	/// Class holder for important methods for any object containing a menu. Be it main menu, pause menu,
	/// game over menu or any other. This class can become a bit of a monolith, so be careful and think before
	/// adding more functionality
	/// </summary>
	public class MenuController : MonoBehaviour
	{
		[Tooltip("Used to recieve pause events")]
		public MediatorAsset onPauseMediatorAsset;

		[Tooltip("Used to recieve the level complete event")]
		public MediatorAsset onLevelCompleteMediatorAsset;

		[Tooltip("Used to recieve the level failed event")]
		public MediatorAsset onLevelFailedMediatorAsset;

		[Tooltip("Canvas for the pause menu")]
		public Canvas pauseMenu;

		[Tooltip("Canvas for the Level Completed menu")]
		public Canvas levelCompleteMenu;

		[Tooltip("Canvas for the level failed menu")]
		public Canvas levelFailedMenu;

		public event Action OnResumeGame;

		private void OnEnable()
		{
			if (onPauseMediatorAsset != null)
			{
				onPauseMediatorAsset.OnNotify += TogglePausedMenu;
				OnResumeGame += onPauseMediatorAsset.CallNotify;
			}

			if (onLevelCompleteMediatorAsset != null)
			{
				onLevelCompleteMediatorAsset.OnNotify += ShowLevelCompleteMenu;
			}

			if (onLevelFailedMediatorAsset != null)
			{
				onLevelFailedMediatorAsset.OnNotify += ShowLevelFailedMenu;
			}
		}

		private void OnDisable()
		{
			if (onPauseMediatorAsset != null)
			{
				onPauseMediatorAsset.OnNotify -= TogglePausedMenu;
				OnResumeGame -= onPauseMediatorAsset.CallNotify;
			}

			if (onLevelCompleteMediatorAsset != null)
			{
				onLevelCompleteMediatorAsset.OnNotify -= ShowLevelCompleteMenu;
			}

			if (onLevelFailedMediatorAsset != null)
			{
				onLevelFailedMediatorAsset.OnNotify -= ShowLevelFailedMenu;
			}
		}

		private void Awake()
		{
			if (pauseMenu != null)
			{
				pauseMenu.gameObject.SetActive(false);
			}

			if (levelCompleteMenu != null)
			{
				levelCompleteMenu.gameObject.SetActive(false);
			}

			if (levelFailedMenu != null)
			{
				levelFailedMenu.gameObject.SetActive(false);
			}
		}

		/// <summary>
		/// Toogle the pause menu. If the menu is not enabled, enable it. If it is enabled, then disable it.
		/// The menu is always set to disabled at scene start. If the toggling is out of sync, this can create issues,
		/// so consider making a mediatorasset with a boolean to force enabled or disabled.
		/// </summary>
		private void TogglePausedMenu()
		{
			if (pauseMenu != null)
			{
				if (pauseMenu.gameObject.activeSelf == true)
				{
					pauseMenu.gameObject.SetActive(false);
				}

				else
				{
					pauseMenu.gameObject.SetActive(true);
				}
			}
		}

		/// <summary>
		/// Show level complete menu. It is assumed that this menu is always disabled in the beginning of a scene, and
		/// that it traverses to another scene from here. This can cause problems down the line, so consider adding a 
		/// bool mediator asset for safer toggling of the menu.
		/// </summary>
		private void ShowLevelCompleteMenu()
		{
			if (levelCompleteMenu != null)
			{
				levelCompleteMenu.gameObject.SetActive(true);
			}
		}

		/// <summary>
		/// Show level failed menu. It is assumed that this menu is always disabled in the beginning of a scene, and
		/// that it traverses to another scene from here. This can cause problems down the line, so consider adding a 
		/// bool mediator asset for safer toggling of the menu.
		/// </summary>
		private void ShowLevelFailedMenu()
		{
			if (levelFailedMenu != null)
			{
				levelFailedMenu.gameObject.SetActive(true);
			}
		}

		/// <summary>
		/// Quit the game. This method quits directly without doing any saving or other useful things. It just 
		/// quits. Consider using another method later in development.
		/// </summary>
		public void QuitGame()
		{
			Application.Quit();
		}

		/// <summary>
		/// Load the next level as long as a next level exists. If not, load the main menu. Remember, if you change
		/// the name of the scene you must also change the string in this method. Consider using the build index
		/// later in development.
		/// </summary>
		public void LoadNextLevel()
		{
			if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
			else
			{
				SceneManager.LoadScene("MainMenu");
			}
		}

		/// <summary>
		/// Restart the scene by reloading it
		/// </summary>
		public void RestartLevel()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		/// <summary>
		/// Load the main menu. Remember, if you changethe name of the scene you must also change the string 
		/// in this method. Consider using the build index later in development.
		/// </summary>
		public void LoadMainMenu()
		{
			SceneManager.LoadScene("MainMenu");
		}

		/// <summary>
		/// Resume the game. 
		/// </summary>
		public void ResumeGame()
		{
			OnResumeGame?.Invoke();
		}
	}
}
