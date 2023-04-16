using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletTime", menuName = "Tooltips/BulletTime", order = 3)]
public class SlowMotionTooltip : TutorialTooltip
{
    public override event StopShowing stopShowing;

    public override void OnShow()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeOnScreen)
        {
            if (Input.GetButtonDown("BulletTime"))
            {
                stopShowing?.Invoke();
            }
        }
    }
}
