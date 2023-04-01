using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScreen : MonoBehaviour
{
    CanvasGroup cg;
    [SerializeField] GameManager gm;
    [SerializeField] float fadeTime = 1f;
    [SerializeField] TextMeshProUGUI finalScoreTxt, airtimeScoreTxt, enemyScoreTxt, wallrunScoreTxt, speedScoreTxt, highscoreTxt, bonusTxt;

    private void Start()
    {
        cg = GetComponent<CanvasGroup>();
        SetScores();
    }

    public void SetScores()
    {
        airtimeScoreTxt.text = "Airtime Score: " + gm.airtimeScore;
        enemyScoreTxt.text = "Enemy Score: " + gm.enemyScore;
        wallrunScoreTxt.text = "Wallrun Score: " + gm.wallrunScore;
        speedScoreTxt.text = "Speed Score: " + gm.speedScore;
        if (bonusTxt)
        {
            bonusTxt.text = "Win Bonus: " + gm.winScore;
            gm.finalScore += gm.winScore;
        }
        finalScoreTxt.text = "Final Score: " + gm.finalScore;
        if (gm.finalScore > PlayerPrefs.GetInt("HighScore"))
        {
            highscoreTxt.gameObject.SetActive(true);
            PlayerPrefs.SetInt("HighScore", gm.finalScore);
        }
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        while (cg.alpha < 1)
        {
            cg.alpha += fadeTime * Time.unscaledDeltaTime;
            yield return null;
        }
    }
}
