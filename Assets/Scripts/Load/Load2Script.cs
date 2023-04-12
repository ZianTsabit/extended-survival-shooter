using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load2Script : MonoBehaviour
{
    public TMPro.TMP_Text load2;
    string filename = "save2.json";

    private void Start()
    {
        load2.text = PlayerPrefs.GetString("Save2");
    }

    public void setLoad2()
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
