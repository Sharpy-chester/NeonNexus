using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;

    public void EnableWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void EnableLoseScreen()
    {
        loseScreen.SetActive(true);
    }
}
