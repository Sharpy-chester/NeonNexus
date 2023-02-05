using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;
    GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        currentHealth = maxHealth;
    }

    public void ReduceHealth(int damage)
    {
        currentHealth -= damage;
        CheckHealth();
    }

    void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            KillObject();
        }
    }

    void KillObject()
    {
        if (GetComponent<PlayerMovement>() && gm)
        {
            gm.Lose();
        }
        else
        {
            Destroy(gameObject);
        }
    }    
}
