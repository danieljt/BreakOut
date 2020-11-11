using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// Class holder for important methods for any object containing a menu. Be it main menu, pause menu,
    /// game over menu or any other. This class can become a bit of a monolith, so be careful and think before
    /// adding more functionality
    /// </summary>
    public class MenuController : MonoBehaviour
    {
        public GameObject firstSelected;

		private void Start()
		{
            EventSystem.current.SetSelectedGameObject(firstSelected);
		}

		/// <summary>
		/// Quit the game
		/// </summary>
		public void QuitGame()
		{
            Application.Quit();
		}

        /// <summary>
        /// Load the next level as long as a next level exists. If not, load the first level
        /// </summary>
        public void LoadNextLevel()
		{
            if(SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
			{
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
            else
			{
                SceneManager.LoadScene(0);
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
