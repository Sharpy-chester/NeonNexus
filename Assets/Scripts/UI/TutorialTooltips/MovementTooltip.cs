using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Movement", menuName = "Tooltips/Movement", order = 0)]
public class MovementTooltip : TutorialTooltip
{
    public override event StopShowing stopShowing;

    public override void OnShow()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeOnScreen)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                stopShowing?.Invoke();
            }
        }
    }

    
}
