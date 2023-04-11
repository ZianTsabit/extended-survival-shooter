using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public static bool isHavePet;
    public int money;
    public TMP_Text moneyUI;
    public ShopItemSO[] shopItems;
    public ShopTemplate[] shopPanels;
    public Button[] buyButton;
    public GameObject successPanel;
    
    void Start()
    {  
        money = MoneyManager.money + MoneyManager.prevMoney;
        Debug.Log("Money : " + money);
        moneyUI.text = "Money : " + money.ToString();
        successPanel = GameObject.Find("Success");
        successPanel.SetActive(false);
        isHavePet = false;
        LoadPanels();
        CheckPurhaseable();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void purchaseItem(int itemIndex){
        
        if (money >= shopItems[itemIndex].itemPrice){
            
            if(shopItems[itemIndex].isPet == true){
                shopItems[itemIndex].isPurchased = true;
                successPanel.SetActive(true);
                isHavePet = true;
            } else if (shopItems[itemIndex].isPet == false && shopItems[itemIndex].itemName == "Gun Level 2"){
                shopItems[itemIndex].isPurchased = true;
                successPanel.SetActive(true);
                PlayerShooting.damagePerShot += 10;    
            } else if (shopItems[itemIndex].isPet == false && shopItems[itemIndex].itemName == "Shotgun"){
                shopItems[itemIndex].isPurchased = true;
                successPanel.SetActive(true);
                PlayerShotgun.isEquipped = true;    
            } else if (shopItems[itemIndex].isPet == false && shopItems[itemIndex].itemName == "Sword"){
                shopItems[itemIndex].isPurchased = true;
                successPanel.SetActive(true);
                PlayerMelee.isEquipped = true;
                Debug.Log("Sword Purchased"); 
            } else if (shopItems[itemIndex].isPet == false && shopItems[itemIndex].itemName == "Bow"){
                shopItems[itemIndex].isPurchased = true;
                successPanel.SetActive(true);
                PlayerBow.isEquipped = true; 
            }

            money -= shopItems[itemIndex].itemPrice;
            moneyUI.text = "Money : " + money.ToString();
            CheckPurhaseable();
        }
        
    }

    public void CheckPurhaseable(){

        for (int i = 0; i < shopItems.Length; i++)
        {
            if (money >= shopItems[i].itemPrice && shopItems[i].isPurchased == false)
            {   
                if(shopItems[i].isPet == true && isHavePet == false){
                    buyButton[i].interactable = true;
                } else if(shopItems[i].isPet == false){
                    buyButton[i].interactable = true;
                } else{
                    buyButton[i].interactable = false;
                }
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
            shopPanels[i].SetItem(shopItems[i]);
        }
    }
    
    public void QuitShop(){
        SceneManager.LoadScene(2);
    }

    public void Continue(){
        successPanel.SetActive(false);
    }
}
