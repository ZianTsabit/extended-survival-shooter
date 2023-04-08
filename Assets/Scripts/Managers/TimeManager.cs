using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TimeManager : MonoBehaviour
{
    public static double prevSecond;
    public static double currentSecond;
    public EnemyHealth EnemyHealth;

    Text text;
    void Awake ()
    {
        text = GetComponent <Text> ();
        // shoppingTimeElapsed = 0f;
    }


    void Update ()
    {
        prevSecond = EnemyHealth.prevTime;
        if (!PlayerHealth.isDead && !ShopScript.afterQuestShopping)
        {
            currentSecond = Math.Floor(Time.timeSinceLevelLoad);

            int min, sec;
            min = Math.DivRem((int)(prevSecond + currentSecond), 60, out sec);
            text.text = min + " : " + sec;
        }

        if (ShopScript.afterQuestShopping)
        {
            text.text = Math.Floor(ShopScript.getTime()).ToString();
        }
    }
}
