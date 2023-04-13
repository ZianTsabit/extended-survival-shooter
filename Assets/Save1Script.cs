using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Save1Script : MonoBehaviour
{
    public TMPro.TMP_Text date1;
    string filename = "save1.json";


    private void Start()
    {
        date1.text = PlayerPrefs.GetString("Save1");
    }

    public void setSave1()
    {
        DateTime dateCurrent = DateTime.Now;
        date1.text = dateCurrent.ToString();

        int levelIndex = SceneManager.GetActiveScene().buildIndex + 1;

        saveItem toSave = new saveItem(
            levelIndex,
            PlayerPrefs.GetString("PlayerName"),
            TimeManager.prevSecond,
            MoneyManager.prevMoney,
            ShopManager.isHavePet,
            ShopManager.isHaveAttacker,
            ShopManager.isHaveBuffAura,
            ShopManager.isHaveHealer,
            PlayerBow.isEquipped,
            PlayerShotgun.isEquipped,
            PlayerMelee.isEquipped
            ) ;
        FileHandler.SaveToJSON<saveItem>(toSave, filename);
        PlayerPrefs.SetString("Save1", date1.text);
    }
}
