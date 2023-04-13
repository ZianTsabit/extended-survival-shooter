using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Save3Script : MonoBehaviour
{
    public TMPro.TMP_Text date3;
    string filename = "save3.json";

    private void Start()
    {
        date3.text = PlayerPrefs.GetString("Save3");
    }

    public void setSave3()
    {
        DateTime dateCurrent = DateTime.Now;
        date3.text = dateCurrent.ToString();

        int levelIndex = SceneManager.GetActiveScene().buildIndex + 1;

        saveItem toSave = new saveItem(
            levelIndex,
            PlayerPrefs.GetString("PlayerName"),
            TimeManager.prevSecond,
            MoneyManager.prevMoney);
        FileHandler.SaveToJSON<saveItem>(toSave, filename);
        PlayerPrefs.SetString("Save3", date3.text);
    }
}