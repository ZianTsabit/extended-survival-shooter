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
    //private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        afterQuestShopping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (afterQuestShopping)
        {
            //timeElapsed += Time.deltaTime;
            //if(timeElapsed > shoppingTime)
            //{
            //    afterQuestShopping = false;
            //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //}
            shoppingTime -= Time.deltaTime;
            if (shoppingTime <= 0f)
            {
                afterQuestShopping = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public static float getTime()
    {
        return shoppingTime;
    }
}
