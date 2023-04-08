using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScene : MonoBehaviour
{
    public PlayerHealth PlayerHealth;

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        PlayerHealth.isDead = false;
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        PlayerHealth.isDead = false;
    }
}
