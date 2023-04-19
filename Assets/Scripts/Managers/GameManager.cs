using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    UIManager uiManager;
    public GameObject player;
    public int money { get; private set; }
    public bool paused = false;

    public delegate void OnMoneyChanged();
    public event OnMoneyChanged onMoneyChanged;

    public delegate void EnemyDeath();
    public event EnemyDeath enemyDeath;

    public delegate void GameEnd();
    public event GameEnd gameEnd;
    [HideInInspector] public int finalScore, airtimeScore, enemyScore, wallrunScore, speedScore, winScore;
    [SerializeField] int winBonus = 10000;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public void EndPointReached()
    {
        winScore = winBonus;
        uiManager.EnableWinScreen();
        gameEnd?.Invoke();

        Destroy(player);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Lose()
    {
        gameEnd?.Invoke();
        uiManager.EnableLoseScreen();
        Destroy(player);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        onMoneyChanged?.Invoke();
    }

    public void TriggerEnemyDeathEvent()
    {
        enemyDeath?.Invoke();
    }
}
