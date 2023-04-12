using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

        saveItem toSave = new saveItem(3, "Bebek", 12.0, 30);
        FileHandler.SaveToJSON<saveItem>(toSave, filename);
        PlayerPrefs.SetString("Save1", date1.text);
    }
}
