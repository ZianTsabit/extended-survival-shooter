using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameDisplay : MonoBehaviour
{
    public TMPro.TMP_Text text;
    public TMPro.TMP_InputField display;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            text.text = "Hello " + PlayerPrefs.GetString("PlayerName");
        }
        else
        {
            text.text = "Hello Player1";
        }
        display.characterLimit = 8;
        display.placeholder.GetComponent<TMPro.TMP_Text>().text = PlayerPrefs.GetString("PlayerName");
        
    }

    public void SetPlayerName()
    {
        text.text = "Hello " + display.text;
        display.placeholder.GetComponent<TMPro.TMP_Text>().text = display.text;
        PlayerPrefs.SetString("PlayerName", display.text);
        PlayerPrefs.Save();
    }
}
