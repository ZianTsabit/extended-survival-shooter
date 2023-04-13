using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
    public static bool afterQuestShopping;
    public static float shoppingTime;
    public static float errorTime;
    public GameObject shopkeeper;
    public GameObject shopUI;
    public GameObject ShopError;
    public GameObject saveUI;
    Transform player;
    Transform shopkeeperTransform;

    // Start is called before the first frame update
    void Start()
    {
        shoppingTime = 10f;
        errorTime = 3f;
        afterQuestShopping = false;
        shopkeeperTransform = shopkeeper.GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shopkeeper.SetActive(false);
        shopUI.SetActive(false);
        ShopError.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (afterQuestShopping)
        {
            
            shopkeeper.SetActive(true);
            
            if (Mathf.Abs(player.position.x - shopkeeperTransform.position.x) < 1.5  && Mathf.Abs(player.position.y - shopkeeperTransform.position.y) < 1.5 && Input.GetKeyDown(KeyCode.B))
            {
                //Debug.Log("B pressed!");
                shopUI.SetActive(true);
            }
            
            if (shopUI.activeSelf == false && saveUI.activeSelf == false){
                shoppingTime -= Time.deltaTime;
                if (shoppingTime <= 0f){
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }

        //dissapear after 3 seconds
        if (afterQuestShopping == false && Input.GetKeyDown(KeyCode.B)){
            ShopError.SetActive(true);
        }

        if (ShopError.activeSelf == true)
        {
            errorTime -= Time.deltaTime;
            if (errorTime <= 0f)
            {
                ShopError.SetActive(false);
                errorTime = 3f;
            }
        }
    }

    public static float getTime()
    {
        return shoppingTime;
    }

    public void QuitShop()
    {
        shopUI.SetActive(false);
    }

    private void OnDestroy()
    {
        afterQuestShopping = false;
    }

}
