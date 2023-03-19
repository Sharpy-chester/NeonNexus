using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    UIManager uiManager;
    [SerializeField] GameObject player;
    public int money { get; private set; }

    public delegate void OnMoneyChanged();
    public event OnMoneyChanged onMoneyChanged;

    public delegate void EnemyDeath();
    public event EnemyDeath enemyDeath;

    public delegate void GameEnd();
    public event GameEnd gameEnd;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public void EndPointReached()
    {
        gameEnd?.Invoke();
        uiManager.EnableWinScreen();
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
