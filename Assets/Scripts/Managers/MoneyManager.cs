using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyManager : MonoBehaviour
{
    public static int prevMoney;
    public static int money;

    Text text;


    void Awake ()
    {
        text = GetComponent <Text> ();
    }


    void Update ()
    {
        text.text = "Money : " + (money + prevMoney);
    }
}
