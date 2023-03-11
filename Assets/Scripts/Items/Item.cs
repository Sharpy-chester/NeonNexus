using UnityEngine;

public abstract class Item : ScriptableObject
{
    public string ItemName;
    public string Description;
    public Material IconMat;
    public Sprite IconSprite;
    [Tooltip("1-Low, 4-High")]
    public int Rarity;
    public bool removeFromPool = false;

    public abstract void OnUpdate();
    public abstract void OnAdd(GameObject playerGO);
    public abstract void OnCollision(Collision collision);
    
}
