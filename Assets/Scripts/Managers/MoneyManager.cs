using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyManager : MonoBehaviour
{
    public static int prevMoney;
    public static int money;
    public EnemyHealth EnemyHealth;


    Text text;


    void Awake ()
    {
        text = GetComponent <Text> ();
    }


    void Update ()
    {
        text.text = "Money : " + money;
    }
}
