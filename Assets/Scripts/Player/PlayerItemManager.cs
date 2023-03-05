using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemManager : MonoBehaviour
{
    [SerializeField] List<Item> items;
    UIManager uiManager;
    
    void Start()
    {
        foreach (Item i in items)
        {
            i.OnAdd(gameObject);
        }
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        foreach (Item i in items)
        {
            i.OnUpdate();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (Item i in items)
        {
            i.OnCollision(collision);
        }
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        item.OnAdd(gameObject);
        uiManager.DisplayItemPopup(item);
    }
}
