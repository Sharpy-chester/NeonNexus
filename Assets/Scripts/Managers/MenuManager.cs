using UnityEngine;

namespace LevelManagement
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] string optionsMenuName, mainMenuName, gameSceneName;
        [SerializeField] GameObject mainMenu, characterMenu, optionsMenu;

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

        public void ToggleMainMenu()
        {
            mainMenu.SetActive(!mainMenu.activeSelf);
        }

        public void ToggleCharacterMenu()
        {
            characterMenu.SetActive(!characterMenu.activeSelf);
        }

        public void ToggleOptionsMenu()
        {
            optionsMenu.SetActive(!optionsMenu.activeSelf);
        }
    }
}

