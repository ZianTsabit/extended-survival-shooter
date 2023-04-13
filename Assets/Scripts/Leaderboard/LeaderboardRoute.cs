using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardRoute: MonoBehaviour
{
    public GameObject saveUI;
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void GoToLoad()
    {
        SceneManager.LoadScene("Load");
    }

    public void GoToSave()
    {
        saveUI.SetActive(true);
    }

    public void ContinueGame()
    {
        saveUI.SetActive(false);
    }
}
