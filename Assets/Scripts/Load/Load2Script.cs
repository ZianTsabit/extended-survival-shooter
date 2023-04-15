using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load2Script : MonoBehaviour
{
    public TMPro.TMP_Text load2;
    public Button button2;
    string filename = "save2.json";

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Save2"))
        {
            button2.enabled = false;
        }
        load2.text = PlayerPrefs.GetString("Save2");
    }

    public void setLoad2()
    {
        saveItem savedItem = FileHandler.ReadFromJSON<saveItem>(filename);
        if (savedItem != null)
        {
            PlayerHealth.isDead = false;
            TimeManager.prevSecond = savedItem.save_time;
            MoneyManager.prevMoney = savedItem.save_money;
            PlayerPrefs.SetString("PlayerName", savedItem.save_name);
            ShopManager.isHavePet = savedItem.save_isHavePet;
            ShopManager.isHaveAttacker = savedItem.save_isHaveAttacker;
            ShopManager.isHaveBuffAura = savedItem.save_isHaveBuffAura;
            ShopManager.isHaveHealer = savedItem.save_isHaveHealer;
            PlayerBow.isEquipped = savedItem.save_bow;
            PlayerShotgun.isEquipped = savedItem.save_shotgun;
            PlayerMelee.isEquipped = savedItem.save_melee;
            SceneManager.LoadScene(savedItem.level_index);
        }

    }
}
