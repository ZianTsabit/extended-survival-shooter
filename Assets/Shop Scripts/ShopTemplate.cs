using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopTemplate : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text itemPrice;
    public TMP_Text itemDescription;
    public Image itemImageUI;

    public void SetItem(ShopItemSO item){
        itemName.text = item.itemName;
        itemPrice.text = item.itemPrice.ToString();
        itemDescription.text = item.itemDescription;
        itemImageUI.sprite = item.itemImage;
    }
}
