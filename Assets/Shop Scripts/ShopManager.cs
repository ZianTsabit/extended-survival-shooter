using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public static bool afterQuestShopping;
    //[SerializeField]
    private static float shoppingTime = 10f;
    //[SerializeField]
    public GameObject shopkeeper;
    //private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        afterQuestShopping = false;
        shopkeeper = GameObject.Find("ShopkeeperRDY");
        shopkeeper.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (afterQuestShopping)
        {
            
            shopkeeper.SetActive(true);
            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("B pressed!");
                SceneManager.LoadScene(8);
            }

            shoppingTime -= Time.deltaTime;
            if (shoppingTime <= 0f)
            {
                Debug.Log("Time is up!");
                afterQuestShopping = false;
                shopkeeper.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public static float getTime()
    {
        return shoppingTime;
    }
}
