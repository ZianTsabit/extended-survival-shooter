using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int money;
    public TMP_Text moneyUI;
    public ShopItemSO[] shopItems;
    public ShopTemplate[] shopPanels;

    // Start is called before the first frame update
    void Start()
    {  
        money = MoneyManager.money;
        Debug.Log("Money : " + money);
        moneyUI.text = "Money : " + money.ToString();
        LoadPanels();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void LoadPanels(){
        for (int i = 0; i < shopItems.Length; i++)
        {
            shopPanels[i].itemName.text = shopItems[i].itemName;
            shopPanels[i].itemPrice.text = shopItems[i].itemPrice.ToString();
            shopPanels[i].itemDescription.text = shopItems[i].itemDescription;
        }
    }
}
