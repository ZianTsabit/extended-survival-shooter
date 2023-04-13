using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOverScene : MonoBehaviour
{
    public TMPro.TMP_Text text;
    public static float countdownTime;
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void Start()
    {
        countdownTime = 5f;
    }

    public void Update()
    {
        text.text = "Back To Main Menu in " + Math.Floor(countdownTime).ToString() + " sec";
        countdownTime -= Time.deltaTime;
        if (countdownTime <= 0f)
        {
            SceneManager.LoadScene(0);
        }
    }


    public void RestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        PlayerHealth.isDead = false;
        MoneyManager.money = 0;

    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        PlayerHealth.isDead = false;
    }
}
 