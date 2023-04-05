using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public int money;
    public TMP_Text moneyUI;
    public ShopItemSO[] shopItems;
    public ShopTemplate[] shopPanels;
    public Button[] buyButton;

    // Start is called before the first frame update
    void Start()
    {  
        money = MoneyManager.money;
        Debug.Log("Money : " + money);
        moneyUI.text = "Money : " + money.ToString();
        LoadPanels();
        CheckPurhaseable();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void purchaseItem(int itemIndex){
        
        if (money >= shopItems[itemIndex].itemPrice){
            money -= shopItems[itemIndex].itemPrice;
            moneyUI.text = "Money : " + money.ToString();
            CheckPurhaseable();
        }
        
    }

    public void CheckPurhaseable(){

        for (int i = 0; i < shopItems.Length; i++)
        {
            if (money >= shopItems[i].itemPrice)
            {
                buyButton[i].interactable = true;
            }
            else
            {
                buyButton[i].interactable = false;
            }
        }
    }

    public void LoadPanels(){
        for (int i = 0; i < shopItems.Length; i++)
        {
            shopPanels[i].itemName.text = shopItems[i].itemName;
            shopPanels[i].itemPrice.text = shopItems[i].itemPrice.ToString();
            shopPanels[i].itemDescription.text = shopItems[i].itemDescription;
        }
    }
    
    public void QuitShop(){
        SceneManager.LoadScene(2);
    }
}
