using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    UIManager uiManager;
    [SerializeField] GameObject player;
    public int money { get; private set; }

    public delegate void OnMoneyChanged();
    public event OnMoneyChanged onMoneyChanged;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public void EndPointReached()
    {
        uiManager.EnableWinScreen();
        Destroy(player);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Lose()
    {
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
}
