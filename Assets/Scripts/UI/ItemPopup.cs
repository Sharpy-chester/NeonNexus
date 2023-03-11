using UnityEngine;

namespace UIElements
{
    public class ItemPopup : MonoBehaviour
    {
        CanvasGroup cGroup;
        [SerializeField] float fadeTime = 1.0f;
        [SerializeField] float activeTime = 3.0f;
        float currentTimer = 0;
        bool fadeOut = false;

        void Start()
        {
        
        }

        void OnEnable()
        {
            cGroup = GetComponent<CanvasGroup>();
            cGroup.alpha = 0;
            currentTimer = 0;
            fadeOut = false;
        }

        void Update()
        {
            if (fadeOut)
            {
                cGroup.alpha -= Time.deltaTime / fadeTime;
                if (cGroup.alpha <= 0)
                {
                    fadeOut = false;
                    gameObject.SetActive(false);
                }
                return;
            }
            if (cGroup.alpha < 1)
            {
                cGroup.alpha += Time.deltaTime / fadeTime;
                return;
            }
            currentTimer += Time.deltaTime;
            if (currentTimer > activeTime)
            {
                fadeOut = true;
            }
        }
    }

}
