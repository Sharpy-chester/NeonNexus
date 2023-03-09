using UnityEngine;

namespace LevelManagement
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] string optionsMenuName, mainMenuName, gameSceneName;

        public void LoadOptionsMenu()
        {

        }

        public void LoadGame()
        {
            StartCoroutine(LevelManager.Instance.SwitchLevel(gameSceneName));
        }

        public void LoadMainMenu()
        {
            StartCoroutine(LevelManager.Instance.SwitchLevel(mainMenuName));
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}

