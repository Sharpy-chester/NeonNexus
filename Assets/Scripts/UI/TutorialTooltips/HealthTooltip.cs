using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Health", menuName = "Tooltips/Health", order = 4)]
public class HealthTooltip : TutorialTooltip
{
    public override event StopShowing stopShowing;
    public float timeToRemove = 10f;

    public override void OnShow()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeToRemove)
        {
            stopShowing?.Invoke();
        }
    }
}
