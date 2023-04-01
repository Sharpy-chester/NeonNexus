using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBulletTime : MonoBehaviour
{
    [Range(0.05f, 1)]
    [SerializeField] float btScale = 0.2f;
    [SerializeField] float maxTime = 3f;
    [SerializeField] float minAmt = 0.2f;
    [SerializeField] float increaseMultiplier = 0.3f;
    [SerializeField] Slider slider;
    float fixedDelta;
    float timeLeft;
    bool isBt = false;

    void Start()
    {
        timeLeft = maxTime;
        fixedDelta = Time.fixedDeltaTime;
    }

    void Update()
    {
        if (timeLeft < maxTime && !isBt)
        {
            timeLeft += Time.deltaTime * increaseMultiplier;
            UpdateSlider();
        }
        else if (isBt && timeLeft > 0)
        {
            timeLeft -= Time.unscaledDeltaTime;
            UpdateSlider();
        }
        if (Input.GetButtonDown("BulletTime") && timeLeft > minAmt)
        {
            SlowTime();
        }
        if (Input.GetButtonUp("BulletTime") || timeLeft <= 0)
        {
            NormalTime();
        }
    }

    void SlowTime()
    {
        Time.timeScale = btScale;
        Time.fixedDeltaTime = fixedDelta * btScale;
        isBt = true;
    }

    void NormalTime()
    {
        isBt = false;
        Time.timeScale = 1;
        Time.fixedDeltaTime = fixedDelta;
    }

    void UpdateSlider()
    {
        slider.value = timeLeft / maxTime;
    }
}
