using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

[CreateAssetMenu(fileName = "Wallrun", menuName = "Tooltips/Wallrun", order = 2)]
public class WallrunTooltip : TutorialTooltip
{
    public override event StopShowing stopShowing;
    Transform player;

    public override void OnShow()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeOnScreen)
        {
            if (gm.player.GetComponent<PlayerWallRun>().isWallRunning)
            {
                stopShowing?.Invoke();
            }
        }
    }
}
