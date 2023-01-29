using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject winScreen;


    public void EnableWinScreen()
    {
        winScreen.SetActive(true);
    }
}
