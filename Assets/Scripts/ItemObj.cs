using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObj : MonoBehaviour
{
    [SerializeField] Item item;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player") && collision.transform.GetComponent<PlayerItemManager>())
        {
            collision.transform.GetComponent<PlayerItemManager>().AddItem(item);
            Destroy(gameObject);
        }
    }
}
