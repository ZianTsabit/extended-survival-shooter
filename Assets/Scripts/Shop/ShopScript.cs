using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
    public static bool afterQuestShopping;
    public static float shoppingTime;
    public GameObject shopkeeper;
    public GameObject shopUI;
    Transform player;
    Transform shopkeeperTransform;

    // Start is called before the first frame update
    void Start()
    {
        shoppingTime = 10f;
        afterQuestShopping = false;
        shopkeeperTransform = shopkeeper.GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shopkeeper.SetActive(false);
        shopUI.SetActive(false);
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
            
            if (shopUI.activeSelf == false){
                shoppingTime -= Time.deltaTime;
                if (shoppingTime <= 0f){
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
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
