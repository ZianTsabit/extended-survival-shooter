using UnityEngine;
using UnityEngine.UI;

public class Zombunny_1 : MonoBehaviour
{
    public static int enemyKilled;
    public static int targetKill;
    public int enemyCount;

    Text text;
    // Start is called before the first frame update
    void Awake ()
    {
        MoneyManager.money = 0; // Since this is the first quest, initiate score to 0 hence it will be used later on further
        MoneyManager.prevMoney = 0;
        TimeManager.totalSecond = 0f;

        text = GetComponent<Text>();
        enemyKilled = 0;
        targetKill = enemyCount;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = enemyKilled + " / " + targetKill;
        if (enemyKilled >= targetKill)
        {
            text.color = Color.green;
        }
    }
}
