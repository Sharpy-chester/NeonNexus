using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObj : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] MeshRenderer itemImage;
    bool hit = false;

    private void Start()
    {
        itemImage.material = item.IconMat;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player") && collision.transform.GetComponent<PlayerItemManager>() && !hit)
        {
            hit = true;
            collision.transform.GetComponent<PlayerItemManager>().AddItem(item);
            Destroy(gameObject);
        }
    }

    public void SetItem(Item newItem)
    {
        item = newItem;
    }
}
