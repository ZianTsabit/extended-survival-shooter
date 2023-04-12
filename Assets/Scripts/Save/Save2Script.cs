using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

        saveItem toSave = new saveItem(4, "Ayam", 23.0, 70);
        FileHandler.SaveToJSON<saveItem>(toSave, filename);
        PlayerPrefs.SetString("Save2", date2.text);
    }
}
