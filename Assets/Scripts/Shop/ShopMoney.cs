using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopMoney : MonoBehaviour
{
    public static int money;
    Text text;

    void Awake ()
    {
        text = GetComponent <Text> ();
        money = MoneyManager.money;
    }


    void Update ()
    {      
        Debug.Log(money.ToString());
        text.text = money.ToString();
    }
}
