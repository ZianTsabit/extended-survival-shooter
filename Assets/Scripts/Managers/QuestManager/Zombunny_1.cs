using UnityEngine;
using UnityEngine.UI;

public class Zombunny_1 : MonoBehaviour
{
    public static int enemyKilled;
    public static int targetKill = 10;

    Text text;
    // Start is called before the first frame update
    void Awake ()
    {
        MoneyManager.money = 0; // Since this is the first quest, initiate score to 0 hence it will be used later on further
        TimeManager.totalSecond = 0f;

        text = GetComponent<Text>();
        enemyKilled = 0;
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
