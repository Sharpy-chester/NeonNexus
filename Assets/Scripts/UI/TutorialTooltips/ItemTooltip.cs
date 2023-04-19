using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

[CreateAssetMenu(fileName = "Item", menuName = "Tooltips/Item", order = 6)]
public class ItemTooltip : TutorialTooltip
{
    public override event StopShowing stopShowing;
    

    public override void OnShow()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeOnScreen)
        {
            if (gm.player.GetComponent<PlayerItemManager>().items.Count > 0)
            {
                stopShowing?.Invoke();
            }
        }
    }
}
