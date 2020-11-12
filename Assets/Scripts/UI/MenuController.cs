using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using StupidGirlGames.Patterns.Mediator;

namespace StupidGirlGames.BreakOut
{
	/// <summary>
	/// Class holder for important methods for any object containing a menu. Be it main menu, pause menu,
	/// game over menu or any other. This class can become a bit of a monolith, so be careful and think before
	/// adding more functionality
	/// </summary>
	public class MenuController : MonoBehaviour
	{
		public MediatorAsset onPauseMediatorAsset;
		public MediatorAsset onLevelCompleteMediatorAsset;
		public MediatorAsset onLevelFailedMediatorAsset;

		public Canvas pauseMenu;
		public Canvas levelCompleteMenu;
		public Canvas levelFailedMenu;

		private void OnEnable()
		{
			if (onPauseMediatorAsset != null)
			{
				onPauseMediatorAsset.OnNotify += ShowPausedMenu;
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
				onPauseMediatorAsset.OnNotify -= ShowPausedMenu;
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

		private void Start()
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
		/// Show the pause menu
		/// </summary>
		private void ShowPausedMenu()
		{
			if (pauseMenu != null)
			{
				pauseMenu.gameObject.SetActive(true);
			}
		}

		/// <summary>
		/// Show level complete menu
		/// </summary>
		private void ShowLevelCompleteMenu()
		{
			if (levelCompleteMenu != null)
			{
				levelCompleteMenu.gameObject.SetActive(true);
			}
		}

		/// <summary>
		/// Show level failed menu
		/// </summary>
		private void ShowLevelFailedMenu()
		{
			if (levelFailedMenu != null)
			{
				levelFailedMenu.gameObject.SetActive(true);
			}
		}

		/// <summary>
		/// Quit the game
		/// </summary>
		public void QuitGame()
		{
			Application.Quit();
		}

		/// <summary>
		/// Load the next level as long as a next level exists. If not, load the main menu
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
		/// Restart the scene bu reloading it
		/// </summary>
		public void RestartLevel()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		/// <summary>
		/// Load the main menu
		/// </summary>
		public void LoadMainMenu()
		{
			SceneManager.LoadScene("MainMenu");
		}
	}
}
