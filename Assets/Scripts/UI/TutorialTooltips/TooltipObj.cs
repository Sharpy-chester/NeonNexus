using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipObj : MonoBehaviour
{
    [SerializeField] TutorialTooltip tooltip;
    [SerializeField] TMP_Text tooltipTxt;
    [SerializeField] GameObject tooltipPanel;
    [SerializeField] GameManager gm;
    bool showing = false;

    private void Start()
    {
        tooltip.stopShowing += DisableTooltip;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") && showing == false)
        {
            showing = true;
            tooltip.gm = gm;
            tooltip.currentTime = 0;
            tooltipPanel.gameObject.SetActive(true);
            tooltipTxt.text = tooltip.title + "\n" + tooltip.description;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            tooltip.OnShow();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            DisableTooltip();
        }
    }

    void DisableTooltip()
    {
        showing = false;
        tooltipPanel.gameObject.SetActive(false);
    }
}
