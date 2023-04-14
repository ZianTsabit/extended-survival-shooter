using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    public void Newgame()
    {
        TimeManager.prevSecond = 0;
        MoneyManager.prevMoney = 0;
        ShopManager.isHavePet = false;
        ShopManager.isHaveAttacker = false;
        ShopManager.isHaveBuffAura = false;
        ShopManager.isHaveHealer = false;
        PlayerBow.isEquipped = false;
        PlayerShotgun.isEquipped = false;
        PlayerMelee.isEquipped = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        EditorApplication.isPlaying = false;
    }
}

