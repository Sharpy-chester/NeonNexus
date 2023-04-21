using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;
    GameManager gm;
    public delegate void OnDeath();
    public event OnDeath onDeath;
    [SerializeField] AudioClip hitSound;    

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        currentHealth = maxHealth;
    }

    public void ReduceHealth(int damage)
    {
        currentHealth -= damage;
        AudioManager.Instance.SpawnAudio(hitSound, transform);
        CheckHealth();
    }

    public void IncreaseHealth(int amt)
    {
        if(currentHealth + amt < maxHealth)
        {
            currentHealth += amt;
        }
        else
        {
            currentHealth = maxHealth;
        }
        CheckHealth();
    }

    public void IncreaseMaxHealth(int amt)
    {
        maxHealth += amt;
        currentHealth += amt;
        CheckHealth();
    }

    void CheckHealth()
    {
        if (gameObject.CompareTag("Player"))
        {
            FindObjectOfType<UIManager>().SetHealthSlider(currentHealth, maxHealth);
        }
        if (currentHealth <= 0)
        {
            KillObject();
        }
    }

    void KillObject()
    {
        onDeath?.Invoke();
        if (gameObject.CompareTag("Player") && gm)
        {
            gm.Lose();
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            gm.TriggerEnemyDeathEvent();
        }
        else if (!gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }    
}
