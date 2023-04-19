using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevelManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] CanvasGroup cg;
    bool paused = false;
    [SerializeField] GameObject pauseScreen, optionsScreen, confirmScreen;
    [SerializeField] Button confirmYesBtn;
    [SerializeField] TextMeshProUGUI confirmText;
    [SerializeField] string quitToMenuTxt = "Quit to main menu?", quitToDesktopTxt = "Quit to desktop?";
    [SerializeField] string mainMenuName = "MainMenu";
    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        paused = !paused;
        gm.paused = paused;
        Time.timeScale = paused ? 0 : 1;
        cg.alpha = paused ? 1 : 0;
        cg.interactable = paused;
        cg.blocksRaycasts = paused;
        Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = paused;
        pauseScreen.SetActive(true);
        optionsScreen.SetActive(false);
        confirmScreen.SetActive(false);
    }

    public void TogglePauseScreen()
    {
        pauseScreen.SetActive(!pauseScreen.activeSelf);
    }

    public void ToggleOptionsScreen()
    {
        if (optionsScreen.activeSelf)
        {
            AudioManager.Instance.SaveAudio();
        }
        optionsScreen.SetActive(!optionsScreen.activeSelf);
    }

    public void ToggleConfirmScreen(int quitType)
    {
        confirmScreen.SetActive(!confirmScreen.activeSelf);
        switch (quitType)
        {
            case 0:
                confirmYesBtn.onClick.RemoveAllListeners();
                confirmYesBtn.onClick.AddListener(() => QuitGame());
                confirmText.text = quitToDesktopTxt;
                break;
            case 1:
                confirmYesBtn.onClick.RemoveAllListeners();
                confirmYesBtn.onClick.AddListener(() => QuitToMenu());
                confirmText.text = quitToMenuTxt;
                break;
        }
    }

    public void ToggleConfirmScreen()
    {
        confirmScreen.SetActive(!confirmScreen.activeSelf);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void QuitToMenu()
    {
        StartCoroutine(LevelManager.Instance.SwitchLevel(mainMenuName));
    }

    private void OnDestroy()
    {
        confirmYesBtn.onClick.RemoveAllListeners();
    }
}