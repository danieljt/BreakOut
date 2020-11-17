using UnityEngine;
using UnityEngine.SceneManagement;

namespace StupidGirlGames.BreakOut
{
    /// <summary>
    /// A main menu controller controls the flow of the main menu. It is different than the normal
    /// menu controller, but in many ways the same. Consider merging them into one script if possible
    /// </summary>
    public class MainMenuController : MonoBehaviour
    {
        [Tooltip("The game manager prefab")]
        public GameObject gameManagerPrefab;

		[Tooltip("This is the main menu canvas")]
		public Canvas mainMenuCanvas;

		[Tooltip("This is the Load Game menu")]
		public Canvas loadGameCanvas;

		[Tooltip("This is the Options menu")]
		public Canvas optionsCanvas;

		private void Awake()
		{
			// We check to see if the game manager is instantiated, and if not we instantiate
			// a new copy. Make sure to add a reference to it in the MainMenu prefab.
			if (!GameManager.IsInstantiated)
			{
				Instantiate(gameManagerPrefab);
			}

			if (mainMenuCanvas != null)
			{
				mainMenuCanvas.gameObject.SetActive(true);
			}

			if (loadGameCanvas != null)
			{
				loadGameCanvas.gameObject.SetActive(false);
			}

			if (optionsCanvas != null)
			{
				optionsCanvas.gameObject.SetActive(false);
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
	}
}
