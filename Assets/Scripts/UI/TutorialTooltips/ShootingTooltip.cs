using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shooting", menuName = "Tooltips/Shooting", order = 5)]
public class ShootingTooltip : TutorialTooltip
{
    public override event StopShowing stopShowing;

    public override void OnShow()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeOnScreen)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                stopShowing?.Invoke();
            }
        }
    }
}
