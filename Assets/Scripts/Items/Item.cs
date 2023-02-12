using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public string ItemName;
    public Material IconMat;
    [Tooltip("1-Low, 4-High")]
    public int Rarity;

    public abstract void OnUpdate();
    public abstract void OnAdd(GameObject playerGO);
    public abstract void OnCollision(Collision collision);
    
}
