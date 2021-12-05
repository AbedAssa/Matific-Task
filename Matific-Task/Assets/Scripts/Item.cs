using UnityEngine;
using System;

[Serializable]
public class Item
{
    public string resourceName;
    [Range(0, 1000)]
    public int price;
    [Range(0, 100)]
    public int minLevel;
    public bool isPurchased;
    public Sprite itemCustomIcon;
    public Sprite itemCustom;
}
