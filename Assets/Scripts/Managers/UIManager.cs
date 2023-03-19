using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] Slider healthSlider;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject itemPopup;
    [SerializeField] TextMeshProUGUI itemPopupTitle, itemPopupDescription;
    GameManager gameManager;
    float timer;
    bool runTimer = true;

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

    public void StopTimer()
    {
        runTimer = false;
    }

    public void EnableWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void EnableLoseScreen()
    {
        loseScreen.SetActive(true);
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
