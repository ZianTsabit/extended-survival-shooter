using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
    public static bool afterQuestShopping;
    //[SerializeField]
    public static float shoppingTime = 10f;
    public GameObject shopkeeper;
    //private float timeElapsed;
    Transform player;
    Transform shopkeeperTransform;

    // Start is called before the first frame update
    void Start()
    {
        afterQuestShopping = false;
        shopkeeper = GameObject.Find("ShopkeeperRDY");
        shopkeeperTransform = shopkeeper.GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shopkeeper.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (afterQuestShopping)
        {
            
            shopkeeper.SetActive(true);
            
            if (Mathf.Abs(player.position.x - shopkeeperTransform.position.x) < 1.0  && Mathf.Abs(player.position.y - shopkeeperTransform.position.y) < 1.0 && Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("B pressed!");
                SceneManager.LoadScene(8);
            }else{
                Debug.Log(Mathf.Abs(player.position.x - shopkeeperTransform.position.x));
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
