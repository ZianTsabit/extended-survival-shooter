using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "Shop Item", order = 1)]
public class ShopItemSO : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public int itemPrice;
    public bool isPet;
}

