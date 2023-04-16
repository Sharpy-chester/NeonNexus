using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Jumping", menuName = "Tooltips/Jumping", order = 1)]
public class JumpingTooltip : TutorialTooltip
{
    public override event StopShowing stopShowing;

    public override void OnShow()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeOnScreen)
        {
            if (Input.GetButtonDown("Jump"))
            {
                stopShowing?.Invoke();
            }
        }
    }

}
