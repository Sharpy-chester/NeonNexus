using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tooltipTxt;
    [SerializeField] Image bgImage;
    [SerializeField] RectTransform bgTransform;
    [SerializeField] float tooltipHeight = 65.0f;
    Camera cam;

    void Start()
    {
        bgImage = GetComponent<Image>();
        cam = Camera.main;
    }

    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void ShowTooltip(string tooltiptext)
    {
        print("Show");
        bgTransform.gameObject.SetActive(true);
        tooltipTxt.text = tooltiptext;
        Vector2 backgroundSize = new(tooltipTxt.preferredWidth, tooltipHeight);
        bgTransform.sizeDelta = backgroundSize;
    }

    public void HideTooltip()
    {
        bgTransform.gameObject.SetActive(false);
    }
}
