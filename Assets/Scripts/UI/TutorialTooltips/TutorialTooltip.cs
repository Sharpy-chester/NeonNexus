using UnityEngine;

public abstract class TutorialTooltip : ScriptableObject
{
    public string title;
    public string description;
    [HideInInspector] public float timeOnScreen = 5f;
    [HideInInspector] public float currentTime = 0f;
    public GameManager gm;

    public abstract void OnShow();
    public delegate void StopShowing();
    public abstract event StopShowing stopShowing;
}
