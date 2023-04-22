using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] Slider healthSlider;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject itemPopup;
    [SerializeField] TextMeshProUGUI itemPopupTitle, itemPopupDescription, scoreTxt;
    [SerializeField] float winLoseScreenFadeTime = 1f;
    GameManager gameManager;
    float timer;
    bool runTimer = true;
    int score;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.onMoneyChanged += UpdateMoneyText;
        moneyText.text = gameManager.money.ToString();
    }

    void FixedUpdate()
    {
        if(runTimer)
        {
            timer += Time.fixedDeltaTime;
            timerText.text = (timer / 100).ToString("00.00");
            timerText.text = Mathf.Floor(timer / 60).ToString("00") + ":" + Mathf.Floor(timer % 60).ToString("00");
        }
    }


    public void AddScore(int amt)
    {
        score += amt;
        scoreTxt.text = score.ToString();
    }

    public void StopTimer()
    {
        runTimer = false;
    }

    public void EnableWinScreen()
    {
        winScreen.SetActive(true);
        CanvasGroup c = winScreen.GetComponent<CanvasGroup>();
        StartCoroutine(FadeScreenIn(c));
    }

    public void EnableLoseScreen()
    {
        loseScreen.SetActive(true);
        CanvasGroup c = loseScreen.GetComponent<CanvasGroup>();
        StartCoroutine(FadeScreenIn(c));
    }

    IEnumerator FadeScreenIn(CanvasGroup cg)
    {
        while (cg.alpha < 1)
        {
            cg.alpha += winLoseScreenFadeTime * Time.deltaTime;
            yield return null;
        }
    }

    public void SetHealthSlider(int health, int maxHealth)
    {
        healthSlider.value = (float)health / (float)maxHealth;
    }

    void UpdateMoneyText()
    {
        moneyText.text = gameManager.money.ToString();
    }

    
}
