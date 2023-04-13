using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Save2Script : MonoBehaviour
{
    public TMPro.TMP_Text date2;
    string filename = "save2.json";

    private void Start()
    {
        date2.text = PlayerPrefs.GetString("Save2");
    }

    public void setSave2()
    {
        DateTime dateCurrent = DateTime.Now;
        date2.text = dateCurrent.ToString();

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
            PlayerMelee.isEquipped);
        FileHandler.SaveToJSON<saveItem>(toSave, filename);
        PlayerPrefs.SetString("Save2", date2.text);
    }
}
