using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load3Script : MonoBehaviour
{
    public TMPro.TMP_Text load3;
    string filename = "save3.json";

    private void Start()
    {
        load3.text = PlayerPrefs.GetString("Save3");
    }

    public void setLoad3()
    {
        saveItem savedItem = FileHandler.ReadFromJSON<saveItem>(filename);
        if (savedItem != null)
        {
            TimeManager.prevSecond = savedItem.save_time;
            MoneyManager.prevMoney = savedItem.save_money;
            PlayerPrefs.SetString("PlayerName", savedItem.save_name);
            SceneManager.LoadScene(savedItem.level_index);
        }
        else
        {
            SceneManager.LoadScene(1);
        }

    }
}
