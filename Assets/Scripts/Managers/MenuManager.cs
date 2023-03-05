using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] string optionsMenuName, mainMenuName, gameSceneName;

    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene(optionsMenuName);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
