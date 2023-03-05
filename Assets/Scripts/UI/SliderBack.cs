using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBack : MonoBehaviour
{
    [SerializeField] Slider slider;
    float startingWidth, currentWidth, desiredWidth;
    [SerializeField] float lerpTime;
    float currentLerp = 0.0f;
    RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startingWidth = rectTransform.sizeDelta.x;
        currentWidth = rectTransform.sizeDelta.x;
        desiredWidth = rectTransform.sizeDelta.x;
    }

    void Update()
    {
        if (desiredWidth != currentWidth)
        {
            rectTransform.sizeDelta = new Vector2(Mathf.Lerp(currentWidth, desiredWidth, currentLerp), rectTransform.sizeDelta.y);
            currentLerp += lerpTime * Time.unscaledDeltaTime;
            
            if (currentLerp >= 1.0f)
            {
                currentWidth = desiredWidth;
                currentLerp = 0.0f;
            }
        }
    }

    public void OnValueChanged()
    {
        desiredWidth = slider.value * startingWidth;
    }
}
