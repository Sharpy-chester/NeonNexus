using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHandler : MonoBehaviour
{
    public List<Item> skills { get; private set; } = new List<Item>();

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void AddItems(Item item)
    {
        skills.Add(item);
    }

    public void AddItems(List<Item> items)
    {
        skills.AddRange(items);
    }
}
