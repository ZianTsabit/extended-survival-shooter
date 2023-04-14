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
    bool isSpeedCheat = false;
    bool isDamageCheat = false;

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
            
            if (Mathf.Abs(player.position.x - shopkeeperTransform.position.x) < 1.0  && Mathf.Abs(player.position.y - shopkeeperTransform.position.y) < 1.0 && Input.GetKeyDown(KeyCode.B))
            {
                shopUI.SetActive(true);
            } else if (Mathf.Abs(player.position.x - shopkeeperTransform.position.x) > 1.0  && Mathf.Abs(player.position.y - shopkeeperTransform.position.y) < 1.0 && Input.GetKeyDown(KeyCode.B)){
                ShopError.SetActive(true);
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

        // Cheat Code
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Cheat Code Activated");
            if (ShopManager.isHavePet == true && ShopManager.isHaveHealer == true)
            {
                ShopManager.isHavePet = false;
                HealerPet.currentHealth = 0;
            }
            else if (ShopManager.isHavePet == true && ShopManager.isHaveAttacker == true)
            {
                ShopManager.isHavePet = false;
                AttackPet.currentHealth = 0;
            }
            else if (ShopManager.isHavePet == true && ShopManager.isHaveBuffAura == true)
            {
                ShopManager.isHavePet = false;
                BuffPet.currentHealth = 0;
            }
        } else if (Input.GetKeyDown(KeyCode.U)){
            Debug.Log("Cheat Code Activated");
            if(isSpeedCheat == false){
                PlayerMovement.speed = 12f;
                isSpeedCheat = true;
            } else if (isSpeedCheat == true){
                PlayerMovement.speed = 6f;
                isSpeedCheat = false;
            }
        } else if (Input.GetKeyDown(KeyCode.F)){
            Debug.Log("Cheat Code Activated");
            if (ShopManager.isHavePet == true && ShopManager.isHaveHealer == true)
            {
                HealerPet.currentHealth = 150;
            }
            else if (ShopManager.isHavePet == true && ShopManager.isHaveAttacker == true)
            {
                AttackPet.currentHealth = 150;
            }
            else if (ShopManager.isHavePet == true && ShopManager.isHaveBuffAura == true)
            {
                BuffPet.currentHealth = 150;
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha9)){
            Debug.Log("Cheat Code Activated");
            MoneyManager.money += 999999;
        } else if (Input.GetKeyDown(KeyCode.N)){
            Debug.Log("Cheat Code Activated");
            if (isDamageCheat == false){
                EnemyAttack.attackDamage = 0;
                isDamageCheat = true;
            } else if (isDamageCheat == true){
                EnemyAttack.attackDamage = 10;
                isDamageCheat = false;
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
