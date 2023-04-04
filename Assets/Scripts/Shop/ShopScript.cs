using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour{
    
    
    void Awake ()
    {
        
    }

    void Update ()
    {
        
    }

    public void QuitShop()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
