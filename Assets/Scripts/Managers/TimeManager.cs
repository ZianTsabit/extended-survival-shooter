using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TimeManager : MonoBehaviour
{
    public static double totalSecond;
    public double currentSecond;

    Text text;
    void Awake ()
    {
        text = GetComponent <Text> ();
    }


    void Update ()
    {
        if (!PlayerHealth.isDead)
        {
            currentSecond = Math.Floor(Time.timeSinceLevelLoad);

            int min, sec;
            min = Math.DivRem((int)(totalSecond + currentSecond), 60, out sec);
            text.text = min + " : " + sec;
        }
    }

    private void OnDestroy()
    {
        totalSecond += currentSecond;
    }
}
