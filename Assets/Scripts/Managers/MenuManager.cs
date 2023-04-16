using UnityEngine;
using TMPro;

namespace LevelManagement
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] string mainMenuName, gameSceneName, tutorialSceneName;
        [SerializeField] GameObject mainMenu, characterMenu, optionsMenu;
        [SerializeField] TextMeshProUGUI highscoreTxt;

        private void Start()
        {
            highscoreTxt.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        }

        public void LoadGame()
        {
            if(PlayerPrefs.GetInt("TutorialComplete") == 1)
            {
                StartCoroutine(LevelManager.Instance.SwitchLevel(gameSceneName));
            }
            else
            {
                StartCoroutine(LevelManager.Instance.SwitchLevel(tutorialSceneName));
            }
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

