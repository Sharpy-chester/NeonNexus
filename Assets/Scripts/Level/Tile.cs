using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    ItemList itemList;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] List<ItemPoint> itemPoints;
    public Transform endPoint;

    void Start()
    {
        itemList = FindObjectOfType<ItemList>();
        //choose random item point
        int rand = Random.Range(0, itemPoints.Count);
        GameObject newItem = Instantiate(itemPrefab, itemPoints[rand].transform);
        //choose random item
        rand = Random.Range(0, itemList.itemList.Count);
        newItem.GetComponent<ItemObj>().SetItem(itemList.itemList[rand]);
    }

    void Update()
    {
        
    }
}
