using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Load1Script : MonoBehaviour
{
    public TMPro.TMP_Text load1;
    string filename = "save1.json";

    private void Start()
    {
        load1.text = PlayerPrefs.GetString("Save1");
    }

    public void setLoad1()
    {
        saveItem savedItem = FileHandler.ReadFromJSON<saveItem>(filename);
        if (savedItem != null) {
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